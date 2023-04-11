using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParentManager : MonoBehaviour
{

    public GameObject[] cards;   // The parent object to spawn like berry bush
    private float spawnRange = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // press F1 to spawn a card
        // if (Input.GetKeyDown(KeyCode.F1))
        // {
        //     SpawnRandomCard(cards[0]);
        // } else if (Input.GetKeyDown(KeyCode.F2))
        // {
        //     SpawnRandomCard(cards[1]);
        // }
    }

    void SpawnRandomCard(GameObject card)
    {
        float spawnDir  = Random.Range(0,180f);
        float xoffset = spawnRange * Mathf.Sin(spawnDir);
        float zoffset = spawnRange * -Mathf.Cos(spawnDir);
        Vector3 spawnPos = new Vector3(card.transform.position.x+xoffset, card.transform.position.y,card.transform.position.z+zoffset);
        Instantiate(card, spawnPos, card.transform.rotation);
    }
}
