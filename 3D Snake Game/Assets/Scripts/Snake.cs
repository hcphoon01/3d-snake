using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{

    public GameObject tail;

    private GameObject newTail;
    private Vector3 spawnLocation;


    private void Start()
    {
        spawnLocation = new Vector3(-2, 1, 0);
        newTail = Instantiate(tail, spawnLocation, Quaternion.identity);
        GetComponent<PlayerMovement>().bodyParts.Add(newTail);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Food")
        {
            FindObjectOfType<SpawnManager>().CallSpawnFood();
            FindObjectOfType<SpawnManager>().SpawnBody();
            Destroy(other.gameObject);
        }
        if (other.tag == "Body")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
