using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificObject : SaveableObject
{
    private int strength;
    private int health; 

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public override void Save(int id)
    {
        base.Save(id);
    }

    public override void Load(string[] values)
    {
        base.Load(values); 
    }

    
}