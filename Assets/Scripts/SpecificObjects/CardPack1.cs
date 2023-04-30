using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPack1 : SaveableObject
{
    [SerializeField]
    private int strength;
    [SerializeField]
    private int health;


<<<<<<< Updated upstream:Assets/Scripts/SpecificObjects/CardPack1.cs
    public static string[] stackableListPack1 = new string[] {};


    protected override void Start()
    {
        base.Start();
        GetComponent<Stack>().stackableList = stackableListPack1;
        objectType = ObjectType.Pack;
    }
=======

    private void Start()
    {

    }

>>>>>>> Stashed changes:Menu/Assets/Scripts/SpecificObjects/Villager.cs

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DestroySaveable();
        }
        if(health <=0)
        {
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
        strength = int.Parse(values[4]);
        health = int.Parse(values[5]);
        base.Load(values);
    }
<<<<<<< Updated upstream:Assets/Scripts/SpecificObjects/CardPack1.cs

    public override void TakeDamage(int damage)
    {
        health -= damage;
    }

=======
>>>>>>> Stashed changes:Menu/Assets/Scripts/SpecificObjects/Villager.cs
}
