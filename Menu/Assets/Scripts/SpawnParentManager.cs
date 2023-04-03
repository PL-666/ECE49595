using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParentManager : MonoBehaviour
{

    public GameObject[] cards;   // The parent object to spawn like berry bush
    private float spawnRangeX = 3.0f;
    private float spawnRangeZ = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // press F1 to spawn a card
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SpawnRandomCard(cards[0]);
        } else if (Input.GetKeyDown(KeyCode.F2))
        {
            SpawnRandomCard(cards[1]);
        }
    }

    void SpawnRandomCard(GameObject card)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 
        Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(card, spawnPos, gameObject.transform.rotation);
    }
}
