using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPreviewSelectDrag : MonoBehaviour
{



    public float selectHeight = 4;
    public float groudStateHeight;
    public bool selected;

    private float MouseDownX;
    private float MouseDownY;
    private float distanceToCamera;
    


    // Start is called before the first frame update
    void Start()
    {
        groudStateHeight = transform.lossyScale.y * 0.5f;
        selected = false;



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
       // transform.position = new Vector3(temp.x, selectHeight + gr, temp.z);
        distanceToCamera = GetDistanceToCamera();
        Vector3 downMousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        MouseDownX = downMousePosition.x; 
        MouseDownY = downMousePosition.y;
        selected = true;
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }


    private void OnMouseDrag()
    {
        Vector3 temp = new Vector3(Input.mousePosition.x - MouseDownX, Input.mousePosition.y - MouseDownY, distanceToCamera);
        transform.position = Camera.main.ScreenToWorldPoint(temp);
    }

    private void OnMouseUp()
    {
        Vector3 temp = transform.position;
        transform.position = new Vector3(temp.x, groudStateHeight, temp.z);
    }

}
