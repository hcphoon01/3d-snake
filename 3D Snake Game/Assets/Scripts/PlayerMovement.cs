using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float rotationMultiplier = 1f;
    public float bodySeparation = 1f;

    public List<GameObject> bodyParts = new List<GameObject>();

    private Vector3 bodyOffset;

    private GameObject prevBodyPart;

    private void Start()
    {
        prevBodyPart = rb.transform.gameObject;
    }

    // Changed to "Fixed" Update to update every physics step
    void FixedUpdate()
    {
        rb.AddForce(GetXComponent(forwardForce) * Time.deltaTime, 0, -GetZComponent(forwardForce) * Time.deltaTime);
        

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.transform.Rotate(0, -rotationMultiplier, 0, Space.Self);
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.transform.Rotate(0, rotationMultiplier, 0, Space.Self);
        }

        foreach (GameObject body in bodyParts)
        {
            
            bodyOffset = new Vector3(GetXComponent(1) + bodySeparation, 0, GetZComponent(1) + bodySeparation);
            Debug.Log(bodyOffset);
            body.transform.position = prevBodyPart.transform.position + bodyOffset;
            if (body != prevBodyPart)
            {
                prevBodyPart = body;
            }
            if (bodyParts.Count <= 1)
            {
                prevBodyPart = rb.transform.gameObject;
            }
            //body.GetComponent<Rigidbody>().AddForce(GetXComponent() * Time.deltaTime, 0, -GetZComponent() * Time.deltaTime);
        }
        
    }

    private float GetXComponent(float multiplier)
    {
        return multiplier * Mathf.Cos(rb.transform.eulerAngles.y * Mathf.Deg2Rad);
    }

    private float GetZComponent(float multiplier)
    {
        return multiplier * Mathf.Sin(rb.transform.eulerAngles.y * Mathf.Deg2Rad);
    }
}
