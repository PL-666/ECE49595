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


    private Vector3 down;
    private AudioSource audioSource;
    public AudioClip cardClickSound;
    private float clickSoundAmplifier = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        groudStateHeight = transform.lossyScale.y * 0.5f;
        down = new Vector3(0, -transform.lossyScale.y * 0.2f, 0);
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
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
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
        playClickCardSound();
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

    public void playClickCardSound()
    {
        audioSource.PlayOneShot(cardClickSound, clickSoundAmplifier);
    }

}
