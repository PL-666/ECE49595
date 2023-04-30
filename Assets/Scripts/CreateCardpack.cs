using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCardpack : MonoBehaviour
{
    // Start is called before the first frame update
    private int num = 5;
    private static List<string> cardPack1 = new List<string>()
    {
        "BerryBush", "Stone", "Wood",
        "LumberCamp", "Quarry", "Villager"
    };
    private List<float> spawnAngle = new List<float>()
    {
        0f,Mathf.PI/4,Mathf.PI/2,Mathf.PI*3/4,Mathf.PI, Mathf.PI *5 / 4
    };
    private Quaternion defaultRotation = new Quaternion(0.0f,1.0f,0.0f,0.0f);
    private float genDist = 2.0f;
    // Update is called once per frame
    void Update()
    {
        
    }
    // 25%  Berrybush
    // 25%  Stone
    // 25%  Wood
    // 12.5%  LumberCamp
    // 12.5% Quarry
    public void Pack1Gen()
    {
        int genidx;
        if(num == 5)
        {
            genidx = 5;
        }
        else
        {
            int randidx = Random.Range(1,50);
            genidx = 0;
            if(randidx >= 41)
            {
                genidx = 5;
            }
            if( randidx >= 31)
            {
                genidx = 0;
            }
            else if(randidx >= 21)
            {
                genidx = 1;
            }
            else if(randidx >= 11)
            {
                genidx = 2;
            }
            else if (randidx >= 6)
            {
                genidx = 3;
            }
            else if (randidx >= 1)
            {
                genidx = 4;
            }
        }
        num--;
        Vector3 spawnPosition = new Vector3(0,0.0f,0);
        spawnPosition.x = transform.position.x + (genDist * Mathf.Cos(spawnAngle[genidx]));
        spawnPosition.z = transform.position.z + (genDist * -Mathf.Sin(spawnAngle[genidx]));
        Debug.Log(spawnPosition.ToString());
        GameObject tmp = Instantiate(Resources.Load(cardPack1[genidx]) as GameObject, spawnPosition , defaultRotation);
        tmp.GetComponent<Drag>().generate = true;
    }
}
