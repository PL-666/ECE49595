using UnityEngine;

public class Drag : MonoBehaviour
{

    public bool generate;

    public static float selectHeight = 0.1f;
    public float scaleY;
    public float groudStateHeight;
    public bool selected;
    public bool cardDown;


    private float MouseDownX;
    private float MouseDownY;
    private float distanceToCamera;

    private SoundUtility soundUtility;


    private Vector3 down;


    // Start is called before the first frame update
    void Start()
    {
        soundUtility = GameObject.Find("SpawnManager").GetComponent<SoundUtility>();
        if(soundUtility == null)
        {
            Debug.Log("not found");
        }
        groudStateHeight = transform.lossyScale.y * 0.5f;
        down = new Vector3(0, -transform.lossyScale.y * 0.5f, 0);
        if (!generate)
        {
            selected = false;
            cardDown = false;
        }

        else
        {
            selected = true;
            cardDown = true;
        }



        //
        gameObject.GetComponent<BoxCollider>().isTrigger = true;


    }


    private void FixedUpdate()
    {
        if (cardDown == true)
        {
            if ((Mathf.Abs(transform.position.y - groudStateHeight * 0.5f) > groudStateHeight * 0.5f))
            {
                transform.Translate(down);
            }

            else
            {
                transform.position = new Vector3(transform.position.x, groudStateHeight, transform.position.z);
                gameObject.GetComponent<Drag>().cardDown = false;
            }
        }



    }


    private float GetDistanceToCamera()
    {
        // Debug.Log(gameObject + "distance to camera is "+ (Camera.main.WorldToScreenPoint(transform.position)).z);
        return (Camera.main.WorldToScreenPoint(transform.position)).z;
    }



    private void OnMouseDown()
    {
        Vector3 temp = transform.position;

        transform.Translate(new Vector3(0, selectHeight, 0));
        distanceToCamera = GetDistanceToCamera();
        Vector3 downMousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        MouseDownX = downMousePosition.x;
        MouseDownY = downMousePosition.y;
        selected = true;
        soundUtility.playClickCardSound();
    }


    private void OnMouseDrag()
    {
        Vector3 temp = new Vector3(Input.mousePosition.x - MouseDownX, Input.mousePosition.y - MouseDownY, distanceToCamera);
        transform.position = Camera.main.ScreenToWorldPoint(temp);
    }

    private void OnMouseUp()
    {
        cardDown = true;
    }

    public float GetSelectedHigh()
    {
        return selectHeight;
    }

    static public void DeleteCards(GameObject cardToDelete)
    {

        if (cardToDelete.CompareTag("card"))
        {
            if (cardToDelete.transform.parent == null)
            {
                Debug.Log("Spwan.cs DeleteCards: delete one seperate card " + cardToDelete.name);
                Destroy(cardToDelete);
            }

            if (cardToDelete.transform.parent != null)
            {

                Debug.Log("Spwan.cs DeleteCards: delete one  " + cardToDelete.name);
                cardToDelete.transform.parent.tag = "card";
                Destroy(cardToDelete);
            }

        }


        if (cardToDelete.CompareTag("stack"))
        {

            if (cardToDelete.transform.parent != null)
            {
                Debug.Log("Spwan.cs DeleteCards: delete one cards in the stack " + cardToDelete.name);
                //change the tag of partent
                cardToDelete.transform.parent.tag = "card";
                // change the parent of children
                Transform child = cardToDelete.transform.GetChild(0);
                child.parent = null;
                child.transform.Translate(new Vector3(0, selectHeight, 0));
                child.gameObject.GetComponent<Drag>().selected = true;
                child.gameObject.GetComponent<Drag>().cardDown = true;
                Destroy(cardToDelete);
            }


            if (cardToDelete.transform.parent == null)
            {
                Debug.Log("Spwan.cs DeleteCards: delete one cards at the top of stack " + cardToDelete.name);
                Transform child = cardToDelete.transform.GetChild(0);
                child.parent = null;
                child.transform.Translate(new Vector3(0, selectHeight, 0));
                child.gameObject.GetComponent<Drag>().selected = true;
                child.gameObject.GetComponent<Drag>().cardDown = true;
                Destroy(cardToDelete);
            }
        }

    }

}
