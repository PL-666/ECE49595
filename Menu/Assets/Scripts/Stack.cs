using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stack : MonoBehaviour
{

    public static float stackDisplayOffset = 0.3f;
    private float repulsion;
    private Vector3 distanceToCollider2D;
    private float selectHeight;

    private SpawnManager spawnManager;



    //  private Rigidbody myRigidbody;
    private Card card;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        card = GetComponent<Card>();
        selectHeight = GetComponent<Drag>().GetSelectedHigh();
        repulsion = 1.0f;



    }


    private void Update()
    {

    }


    private void OnMouseDown()
    {
        if (transform.parent != null)
        {
            transform.parent.tag = "card";
            transform.parent = null;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        //if 
        if ((gameObject.GetComponent<Drag>().selected == true &&
            gameObject.CompareTag("card") && other.gameObject.CompareTag("card")) ||

           (gameObject.GetComponent<Drag>().selected == true &&
           gameObject.CompareTag("stack") && other.gameObject.CompareTag("card")))
        {
            if (gameObject.GetComponent<Drag>().selected == true)
            {
                if (card.stackableList.Contains(other.gameObject.name))
                {
                    _Stack(other);
                    Debug.Log(gameObject.name + " stack on " + other.gameObject.name);
                    Debug.Log(gameObject.name + " collide with " + other.gameObject.name);
                    gameObject.GetComponent<Drag>().selected = false;
                    // gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    gameObject.GetComponent<Drag>().cardDown = false;
                    spawnManager.Spwan(card.transform);
                    return;
                }

                else
                {
                    Debug.Log(gameObject.name + " reject " + other.gameObject.name);
                    GameObject myObject = gameObject;
                    GameObject collider = other.gameObject;
                    Vector3 myObject2collier = gameObject.transform.position - other.transform.position;



                    if (myObject2collier.x > 0 && myObject2collier.z > 0)
                    {
                        distanceToCollider2D = new Vector3(myObject.transform.lossyScale.x * repulsion,
                            selectHeight - transform.position.y, myObject.transform.lossyScale.z * repulsion);
                    }
                    else if (myObject2collier.x > 0 && myObject2collier.z <= 0)
                    {
                        distanceToCollider2D = new Vector3(myObject.transform.lossyScale.x * repulsion,
                           selectHeight - transform.position.y, -myObject.transform.lossyScale.z * repulsion);
                    }

                    else if (myObject2collier.x <= 0 && myObject2collier.z > 0)
                    {
                        distanceToCollider2D = new Vector3(-myObject.transform.lossyScale.x * repulsion,
                            selectHeight - transform.position.y, myObject.transform.lossyScale.z * repulsion);
                    }

                    else if (myObject2collier.x <= 0 && myObject2collier.z <= 0)
                    {
                        distanceToCollider2D = new Vector3(-myObject.transform.lossyScale.x * repulsion,
                            selectHeight - transform.position.y, -myObject.transform.lossyScale.z * repulsion);
                    }
                    gameObject.transform.position += (distanceToCollider2D);

                    // this need to set beacuse may collide with ground first.
                    return;

                }
            }
        }

        //reject if collide with any stack
        if (gameObject.GetComponent<Drag>().selected == true &&
            other.gameObject.CompareTag("stack")
            )
        {
            Debug.Log(gameObject.name + " reject " + other.gameObject.name);
            GameObject myObject = gameObject;
            GameObject collider = other.gameObject;
            Vector3 myObject2collier = gameObject.transform.position - other.transform.position;



            if (myObject2collier.x > 0 && myObject2collier.z > 0)
            {
                distanceToCollider2D = new Vector3(myObject.transform.lossyScale.x * repulsion,
                    selectHeight - transform.position.y, myObject.transform.lossyScale.z * repulsion);
            }
            else if (myObject2collier.x > 0 && myObject2collier.z <= 0)
            {
                distanceToCollider2D = new Vector3(myObject.transform.lossyScale.x * repulsion,
                   selectHeight - transform.position.y, -myObject.transform.lossyScale.z * repulsion);
            }

            else if (myObject2collier.x <= 0 && myObject2collier.z > 0)
            {
                distanceToCollider2D = new Vector3(-myObject.transform.lossyScale.x * repulsion,
                    selectHeight - transform.position.y, myObject.transform.lossyScale.z * repulsion);
            }

            else if (myObject2collier.x <= 0 && myObject2collier.z <= 0)
            {
                distanceToCollider2D = new Vector3(-myObject.transform.lossyScale.x * repulsion,
                    selectHeight - transform.position.y, -myObject.transform.lossyScale.z * repulsion);
            }
            gameObject.transform.position += (distanceToCollider2D);

            // this need to set beacuse may collide with ground first.
            return;


        }


        if (gameObject.CompareTag("card") && other.gameObject.CompareTag("land"))
        {
            Debug.Log(gameObject.name + " collide with land");
            gameObject.GetComponent<Drag>().selected = false;
            gameObject.GetComponent<Drag>().cardDown = false;
            return;

            ///!!!!
           // gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }


        if (gameObject.CompareTag("stack") && other.gameObject.CompareTag("land"))
        {
            Debug.Log(gameObject.name + "stack collide with land");
            gameObject.GetComponent<Drag>().selected = false;
            gameObject.GetComponent<Drag>().cardDown = false;
            return;

            ///!!!!
           // gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }


    }


    /*
    private void OnTriggerStay(Collider other)
     {

        if (!gameObject.CompareTag("land") && !other.gameObject.CompareTag("land"))
        {
            if (!(card.stackableList.Contains(other.gameObject.name)))
             {
                 GameObject myObject = gameObject;
                 GameObject collider = other.gameObject;
                 Vector3 myObject2collier = gameObject.transform.position - other.transform.position;
                 distanceToCollider2D = new Vector3(myObject2collier.x, 0, myObject2collier.z);
                 
             }
             Debug.Log(gameObject + "still collide with " + other.gameObject);
         }
     }
    */



    private void OnCollisionExit(Collision collision)
    {
        // Debug.Log(gameObject + "stop collide with " + collision.gameObject);
    }


    public void _Stack(Collider other)
    {
        transform.position = new Vector3(other.transform.position.x, other.transform.position.y +
            other.transform.lossyScale.y, other.transform.position.z - stackDisplayOffset);
        transform.parent = other.gameObject.transform;
        other.gameObject.tag = "stack";
    }

    public float GetStackDisplayOffset()
    {
        return stackDisplayOffset;
    }
}
