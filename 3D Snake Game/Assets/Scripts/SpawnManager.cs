using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject food;
    public GameObject body;
    public GameObject head;
    public float spawnDelay = 2f;

    private Vector3 maxSpawnLimit;
    private Vector3 minSpawnLimit;

    private Vector3 spawnLocation;

    private GameObject ground;
    private GameObject newBody;

    public List<GameObject> bodyParts = new List<GameObject>();


    private void Start()
    {
        ground = GameObject.Find("Ground");

        maxSpawnLimit = ground.transform.lossyScale / 2 + new Vector3(-1, 1, -1);
        minSpawnLimit = -ground.transform.lossyScale / 2 + new Vector3(1, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnBody()
    {
        spawnLocation = new Vector3(0, 5, 0);
        newBody = Instantiate(body, spawnLocation, Quaternion.identity);
        head.GetComponent<PlayerMovement>().bodyParts.Add(newBody);
    }

    void SpawnFood()
    {
        spawnLocation = new Vector3(Random.Range(minSpawnLimit[0], maxSpawnLimit[0]), 0, Random.Range(minSpawnLimit[2], maxSpawnLimit[2])) + new Vector3(0, 5, 0);
        Instantiate(food, spawnLocation, Quaternion.identity);
    }

    public void CallSpawnFood()
    {
        Invoke("SpawnFood", spawnDelay);
    }
}
