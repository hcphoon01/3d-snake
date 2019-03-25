using UnityEngine;

public class FollowSnake : MonoBehaviour
{

    public Transform player;
    public Vector3 positionOffset;

    private readonly float distanceBehindSnake = -5f;
    private bool firstPerson;
    
    void FixedUpdate()
    {

        if (Input.GetKey("c"))
        {
            firstPerson = true;
        }

        Quaternion rotationOffset = Quaternion.Euler(0, 90, 0);
        Quaternion rotation = new Quaternion(0, player.rotation.y, 0, player.rotation.w);

        if (firstPerson)
        {
            transform.position = player.position;
            transform.rotation = player.rotation * rotationOffset;
        }
        else
        {
            positionOffset = new Vector3(GetXComponent(), positionOffset[1], -GetZComponent());

            transform.position = player.position + positionOffset;

            transform.rotation = rotation * rotationOffset;
        }
    }

    private float GetXComponent()
    {
        return distanceBehindSnake * Mathf.Cos(Mathf.Deg2Rad * player.transform.eulerAngles.y);
    }
    private float GetZComponent()
    {
        return distanceBehindSnake * Mathf.Sin(Mathf.Deg2Rad * player.transform.eulerAngles.y);
    }
}
