using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChildManager : MonoBehaviour
{
    // Start is called before the first frame update

    // public GameObject workerPrefab;
    public GameObject childPrefab;
    private float spawnRangeX = 1.0f;
    private float spawnRangeZ = 1.0f;
    private float spawnInterval = 2.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // void OnTriggerEnter(Collider collision)
    // {
    //     // TODO: Change the name to a gameobject tag
    //     if (collision.gameObject.name == "Villager(Clone)")
    //     {
    //         // Spawn every 15 seconds
    //         Debug.Log("Collision detected");
    //         Invoke("SpawnChild", spawnInterval);
    //     }
    // }

    public void SpawnChild(Vector3 cardPos)
    {
        float parentPosX = cardPos.x;
        float parentPosZ = cardPos.z;
        Instantiate(childPrefab, new Vector3(Random.Range(-spawnRangeX + parentPosX,
         spawnRangeX + parentPosX), 0, Random.Range(-spawnRangeZ + parentPosZ,
         spawnRangeZ + parentPosZ)), Quaternion.identity);
    }
}
