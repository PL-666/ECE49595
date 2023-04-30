using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    static public int maxRecipeLength = 3;
    public static List<List<string>> recipes = new List<List<string>>()
    {
        new List<string>() { "Villager", "Berry" },
        new List<string>() { "Villager", "BerryBush"}
    };

    public static List<GameObject> recipesTarget = new List<GameObject>();



    void Start()
    {
        recipesTarget.Add(Resources.Load("Villager") as GameObject);
        recipesTarget.Add(Resources.Load("Berry") as GameObject);
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



