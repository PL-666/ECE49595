using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChildManager : MonoBehaviour
{
    // Start is called before the first frame update

    // public GameObject workerPrefab;
    public GameObject childPrefab;
    private float spawnRange = 1.8f;
    // private float spawnInterval = 2.0f;
    // recipe =

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
        float spawnDir  = Random.Range(0,Mathf.PI);
        float xoffset = spawnRange * Mathf.Cos(spawnDir);
        float zoffset = -spawnRange * Mathf.Sin(spawnDir);
        Vector3 spawnPos = new Vector3(cardPos.x+xoffset, cardPos.y,cardPos.z+zoffset);
        Instantiate(childPrefab, spawnPos, gameObject.transform.rotation);
        Debug.Log("???");
    }
}
