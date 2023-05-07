using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    float groudStateHeight;
    public static string[] stackableListVillager = new string[]{"Berry","Villager","BerryBush"};
    public static string[] stackableListBerry = new string[] { "Berry", "Villager" };
    public static string[] stackableListBerryBush = new string[] {"Villager" };

    public string[] stackableList;

    private Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Villager" || gameObject.name == "Villager(Clone)")
        {
            stackableList = stackableListVillager;
        }

        else if (gameObject.name == "Berry" || gameObject.name == "Berry(Clone)")
        {
            stackableList = stackableListBerry;
        }


        else if (gameObject.name == "BerryBush" || gameObject.name == "BerryBush(clone)")
        {
            stackableList = stackableListBerryBush;
        }

        else
        {
            //not stackable with any other card
            stackableList = new string[] { };
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



}
