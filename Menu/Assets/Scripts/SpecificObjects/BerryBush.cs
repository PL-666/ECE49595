using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBush : SaveableObject
{
    [SerializeField]
    private int strength;
    [SerializeField]
    private int health; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            DestroySaveable();
        }
    }
     
    public override void Save(int id)
    {
        saveStats = strength.ToString() + "_" + health.ToString();
        base.Save(id);
    }

    public override void Load(string[] values)
    {
        strength  = int.Parse(values[4]);
        health  = int.Parse(values[5]);
        base.Load(values); 
    }

}
