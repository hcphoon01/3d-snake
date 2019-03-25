using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float rotationMultiplier = 1f;
    public float minDistance = 1f;

    public List<GameObject> bodyParts = new List<GameObject>();

    private Vector3 bodyOffset;
    private Quaternion rotationOffset;

    private GameObject currBodyPart;
    private GameObject prevBodyPart;

    private float dis;

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

        /*int i = 0;

        foreach (GameObject body in bodyParts)
        {
            
            if (i == 0)
            {
                prevBodyPart = rb.transform.gameObject;
            }
            ++i;

            bodyOffset = new Vector3(GetXComponent(-bodySeparation), 0, GetZComponent(bodySeparation));
            rotationOffset = Quaternion.Euler(GetXComponent(1), 0, GetZComponent(1));

            body.transform.position = prevBodyPart.transform.position + bodyOffset;
            body.transform.rotation = prevBodyPart.transform.rotation * rotationOffset;

            prevBodyPart = body;
        }*/

        for (int i = 0; i < bodyParts.Count; i++)
        {
            currBodyPart = bodyParts[i];

            if ( i == 0 )
            {
                prevBodyPart = rb.transform.gameObject;
            }
            else
            {
                prevBodyPart = bodyParts[i - 1];
            }
            

            dis = Vector3.Distance(prevBodyPart.transform.position, currBodyPart.transform.position);

            Vector3 newPos = prevBodyPart.transform.position;

            newPos.y = rb.position.y;

            float T = Time.deltaTime * dis / minDistance;

            if ( T > 0.5f)
            {
                T = 0.5f;
            }
            currBodyPart.transform.position = Vector3.Slerp(currBodyPart.transform.position, newPos, T);
            currBodyPart.transform.rotation = Quaternion.Slerp(currBodyPart.transform.rotation, prevBodyPart.transform.rotation, T);
        }
        
    }

    private float GetXComponent(float multiplier)
    {
        return (multiplier * Mathf.Cos(rb.transform.eulerAngles.y * Mathf.Deg2Rad));
    }

    private float GetZComponent(float multiplier, float addend = 0)
    {
        return (multiplier * Mathf.Sin(rb.transform.eulerAngles.y * Mathf.Deg2Rad));
    }
}
