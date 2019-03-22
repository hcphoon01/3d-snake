using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float rotationMultiplier = 1f;

    // Changed to "Fixed" Update to update every physics step
    void FixedUpdate()
    {
        rb.AddForce(GetXComponent() * Time.deltaTime, 0, -GetZComponent() * Time.deltaTime);
        

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.transform.Rotate(0, -rotationMultiplier, 0, Space.Self);
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.transform.Rotate(0, rotationMultiplier, 0, Space.Self);
        }
        
    }

    private float GetXComponent()
    {
        return Mathf.Round(forwardForce * Mathf.Cos(rb.transform.eulerAngles.y * Mathf.Deg2Rad));
    }

    private float GetZComponent()
    {
        return Mathf.Round(forwardForce * Mathf.Sin(rb.transform.eulerAngles.y * Mathf.Deg2Rad));
    }
}
