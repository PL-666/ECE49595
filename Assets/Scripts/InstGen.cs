using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstGen : MonoBehaviour
{
    // Start is called before the first frame update
    public string packname;
    public void generate()
    {
        Instantiate(Resources.Load(packname) as GameObject,  new Vector3(-7f,0.1f,20.0f), new Quaternion(0.0f,1.0f,0.0f,0.0f));
    }
}
