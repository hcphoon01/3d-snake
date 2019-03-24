using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Food")
        {
            FindObjectOfType<SpawnManager>().CallSpawnFood();
            FindObjectOfType<SpawnManager>().SpawnBody();
            Destroy(other.gameObject);
        }
    }
}
