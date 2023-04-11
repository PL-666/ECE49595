using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestCollision : MonoBehaviour
{

    public float stackDisplayOffset = 0.5f;
    public SpawnChildManager spawnManager;
   //  private Rigidbody myRigidbody;
    //private Card card;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnChildManager>();
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
                    Debug.Log(gameObject.name + " stack on " + other.gameObject.name);
                    Debug.Log(gameObject.name + "collide with " + other.gameObject.name);
                    gameObject.GetComponent<TestPreviewSelectDrag>().selected = false;
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
                if((gameObject.name == "BerryBush" && other.gameObject.name == "Villager") || (gameObject.name == "Villager" && other.gameObject.name == "BerryBush"))
                {
                    spawnManager.SpawnChild(gameObject.transform.position);
                }
                
            }
        }



        else if (gameObject.CompareTag("card") && other.gameObject.CompareTag("land"))
        {
            Debug.Log(gameObject.name + "collide with land");
            gameObject.GetComponent<TestPreviewSelectDrag>().selected = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;

        }
    }




   /* private void OnCollisionStay(Collision collision)
    {

        if (gameObject.CompareTag("card") && collision.gameObject.CompareTag("card"))
        {
            if (!(card.stackableList.Contains(collision.gameObject.name)))
            {
                GameObject myObject = gameObject;
                GameObject collider = collision.gameObject;
                Vector3 myObject2collier = gameObject.transform.position - collision.transform.position;
                Vector3 distanceToCollider2D = new Vector3(myObject2collier.x, 0, myObject2collier.z);
                gameObject.transform.Translate(distanceToCollider2D * Time.deltaTime);
            }
            // Debug.Log(gameObject + "still collide with " + collision.gameObject);
        }
    }*/

    private void OnCollisionExit(Collision collision)
    {
       // Debug.Log(gameObject + "stop collide with " + collision.gameObject);
    }


    private void Stack(Collider other)
    {
        transform.position = new Vector3(other.transform.position.x, other.transform.position.y +
            other.transform.lossyScale.y, other.transform.position.z - stackDisplayOffset);
        transform.parent = other.gameObject.transform;
        other.gameObject.tag = "stack";
    }
}
