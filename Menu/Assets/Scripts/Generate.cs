using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{

    public GameObject Villiager;
    public GameObject Berry;
    public GameObject BerryBush;
    private int stackSize = 5;
    private float stackDisplayOffset = Stack.stackDisplayOffset;

    // Start is called before the first frame update
    void Start()
    {
        stackSize = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {


            if (Input.GetKeyDown(KeyCode.V))
            {
                GenerateStacks(Villiager);
            }


            if (Input.GetKeyDown(KeyCode.B))
            {
                GenerateStacks(Berry);
                Debug.Log("SPACE DOWN + B");
            }


            if (Input.GetKeyDown(KeyCode.H))
            {
                GenerateStacks(BerryBush);
            }

        }

        else
        {

            if (Input.GetKeyDown(KeyCode.V))
            {
                Instantiate(Villiager, Villiager.transform.position, Villiager.transform.rotation).name = "Villager";
                gameObject.GetComponent<SoundUtility>().playSpawnCardSound();
            }


            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("B");
                Instantiate(Berry, Berry.transform.position, Berry.transform.rotation).name = "Berry";
                gameObject.GetComponent<SoundUtility>().playSpawnCardSound();
            }


            if (Input.GetKeyDown(KeyCode.H))
            {
                Instantiate(BerryBush, BerryBush.transform.position, BerryBush.transform.rotation).name = "BerryBush";
                gameObject.GetComponent<SoundUtility>().playSpawnCardSound();
            }

        }


    }




    private void _Stack(GameObject parent, GameObject child)
    {
        child.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y +
            parent.transform.lossyScale.y, parent.transform.position.z - stackDisplayOffset);
        child.transform.parent = parent.gameObject.transform;
        parent.gameObject.tag = "stack";
    }


    private void GenerateStacks(GameObject cardToGenerate)
    {
        GameObject parent;
        GameObject child;

        parent = Instantiate(cardToGenerate, cardToGenerate.transform.position,
            cardToGenerate.transform.rotation);
        //remove the (clone)
        parent.name = cardToGenerate.name;


        for (int i = 0; i < stackSize; i++)
        {
            child = Instantiate(cardToGenerate, cardToGenerate.transform.position,
            cardToGenerate.transform.rotation);
            child.name = cardToGenerate.name;

            //stack child on its parents.
            _Stack(parent, child);
            parent = child;
        }
    }
}
