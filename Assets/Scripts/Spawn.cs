using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawn : MonoBehaviour
{

    public int curTargetIndex = -1;
    public int prevTargetIndex;
    public Slider selfSlider;
    public Timer timer;
    private GameObject genObject;
    private Vector3 genCardOffset = new Vector3(-2, Drag.selectHeight, 0);


    private SpawnManager spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        timer = selfSlider.GetComponent<Timer>();
        curTargetIndex = -1;
    }



    // Update is called once per frame
    private void FixedUpdate()
    {

        if (gameObject.CompareTag("card"))
        {

            //Debug.Log("Spawn.cs FixedUpdate: try to find recipe");

            if(selfSlider.IsActive() == false)
            {
              //  Debug.Log("Spawn.cs FixedUpdate: no generation in progress");
                curTargetIndex = spawnManager.Spwan(gameObject.transform);
                if(curTargetIndex >= 0)
                {
                    timer.gameTime = Recipe.recipesTargetTime[curTargetIndex];
                    selfSlider.gameObject.SetActive(true);
                 
           
                    prevTargetIndex = curTargetIndex;
                }
            }

            else
            {
               // Debug.Log("Spawn.cs FixedUpdate: have generation in progress");
                curTargetIndex = spawnManager.Spwan(gameObject.transform);
                if(curTargetIndex != prevTargetIndex)
                {
                    selfSlider.gameObject.SetActive(false);
                    if(curTargetIndex >= 0)
                    {
                        timer.gameTime = Recipe.recipesTargetTime[curTargetIndex];
                        selfSlider.gameObject.SetActive(true);                       
                        prevTargetIndex = curTargetIndex;
                    }

                }

            }

            //spawn card
            if (curTargetIndex != -1 && timer.generate == true)
            {

                int recipeLength = Recipe.recipes[curTargetIndex].Count;

                GameObject child = gameObject;
                GameObject parent = child.transform.parent.gameObject;

                genObject = Instantiate(Recipe.recipesTarget[curTargetIndex],
                gameObject.transform.position + genCardOffset
                , Recipe.recipesTarget[curTargetIndex].transform.rotation);

                //decrease the health of the using cards
                for(int i = 0; i < recipeLength; i++)
                {
                    child.GetComponent<SaveableObject>().TakeDamage(1);
                    child = parent;
                    if (child.transform.parent != null)
                    {
                        parent = child.transform.parent.gameObject;
                    }
                }

                timer.generate = false;
                genObject.name = Recipe.recipesTarget[curTargetIndex].name;
                genObject.GetComponent<Drag>().generate = true;
                spawnManager.GetComponent<SoundUtility>().playSpawnCardSound();
            }

        }

        

    }


    //delete the cards





}
