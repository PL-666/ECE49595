using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : SaveableObject
{
    [SerializeField]
    private int strength;
    [SerializeField]
    private int health;

    public static string[] stackableListBerry = new string[] { "Berry", "Villager", "BerryBush" };

    protected override void Start()
    {
        base.Start();
        GetComponent<Stack>().stackableList = stackableListBerry;
        objectType = ObjectType.Berry;
        health = 1;
        strength = 1;
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            DestroySaveable();
        }

        if (health <= 0)
        {
            Drag.DeleteCards(gameObject);
        }


    }


    public override void TakeDamage(int damage)
    {
        health -= damage;
        base.TakeDamage(damage);
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
