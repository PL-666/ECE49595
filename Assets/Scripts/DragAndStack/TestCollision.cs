using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TestCollision : MonoBehaviour
{

    public float stackDisplayOffset = 0.5f;
    public Slider selfSlider;
   //  private Rigidbody myRigidbody;
    //private Card card;
    // Start is called before the first frame update
    void Start()
    {
        // selfSlider = gameObject.GetComponent<Canvas>();
        if(selfSlider != null)
        {
            selfSlider.gameObject.SetActive(false);
        }
        else
        {
            // Debug.Log("slider not found");
        }
        
        //card = GetComponent<Card>();
        if (transform.parent)
        {
           // Debug.Log(gameObject.name + " has parent " + transform.parent);
        }

        if (transform.parent == null)
        {
           // Debug.Log(gameObject.name + " has parent null ");
        }

       // myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (selfSlider != null)
                    {
                        selfSlider.gameObject.SetActive(true);
                        // selfSlider.enabled = !selfSlider.enabled;
                    }
                    else{
                    }
        }
    }



    private void OnMouseDown()
    {
        if(transform.parent != null)
        {
            transform.parent.tag = "card";
            transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

 
         if (gameObject.CompareTag("card") && other.gameObject.CompareTag("card"))
        {
            if (gameObject.GetComponent<TestPreviewSelectDrag>().selected == true)
            {
                // if (card.stackableList.Contains(collision.gameObject.name))
                {
                    Stack(other);
                    gameObject.GetComponent<TestPreviewSelectDrag>().selected = false;
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
                if((gameObject.name == "BerryBush" && other.gameObject.name == "Villager") || (gameObject.name == "Villager" && other.gameObject.name == "BerryBush"))
                {
                    // spawnManager.SpawnChild(gameObject.transform.position);
                    if (selfSlider != null)
                    {
                        selfSlider.gameObject.SetActive(true);
                    }
                }
                
            }
        }



        else if (gameObject.CompareTag("card") && other.gameObject.CompareTag("land"))
        {
            // Debug.Log(gameObject.name + "collide with land");
            gameObject.GetComponent<TestPreviewSelectDrag>().selected = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;

        }
    }




   

    private void OnCollisionExit(Collision collision)
    {
    }


    private void Stack(Collider other)
    {
        transform.position = new Vector3(other.transform.position.x, other.transform.position.y +
            other.transform.lossyScale.y, other.transform.position.z - stackDisplayOffset);
        transform.parent = other.gameObject.transform;
        other.gameObject.tag = "stack";
    }
}
