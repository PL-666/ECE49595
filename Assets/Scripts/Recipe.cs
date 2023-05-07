using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    static public int maxRecipeLength = 5;
    public static List<List<string>> recipes = new List<List<string>>()
    {
        new List<string>() { "Villager", "Villager" },
        new List<string>() { "Villager", "BerryBush"},
        new List<string>() { "Villager", "Stone","Stone","Wood"},
        new List<string>() { "Villager", "Wood","Wood","Stone"},
        new List<string>() { "Villager", "Quarry"},
        new List<string>() { "Villager", "LumberCamp"}
    };

     
    public static  List<float> recipesTargetTime  = new List<float>()
    {
        6f,
        1f,
        3f,
        3f,
        2f,
        2f,
    };

    public static List<GameObject> recipesTarget = new List<GameObject>();



    void Start()
    {
        recipesTarget.Add(Resources.Load("Villager") as GameObject);
        recipesTarget.Add(Resources.Load("Berry") as GameObject);
        recipesTarget.Add(Resources.Load("Quarry") as GameObject);
        recipesTarget.Add(Resources.Load("LumberCamp") as GameObject);
        recipesTarget.Add(Resources.Load("Stone") as GameObject);
        recipesTarget.Add(Resources.Load("Wood") as GameObject);

        /*
        Debug.Log("1");
        for (int i = 0; i < recipes.Count; i ++)
        {
            for(int j = 0; j <recipes[i].Count; j++)
            {
                Debug.Log(recipes[i][j]);
              
            }
            Debug.Log("\n\n");
        }*/
    }
}



