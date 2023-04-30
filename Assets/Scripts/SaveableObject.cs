using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ObjectType {Villager,BerryBush,Berry,Quarry,Stone,LumberCamp,Wood,Pack}

public abstract class SaveableObject : MonoBehaviour
{
    protected string saveStats;
    [SerializeField]
    private string UID;
    [SerializeField]
    protected ObjectType objectType;
    public string parentID;
    private Vector3 cardshape = new Vector3(1f, 0.01f, 1.4f);
    private Quaternion defaultRotation = new Quaternion(0.0f,1.0f,0.0f,0.0f);

    // Start is called before the first frame update
    protected virtual void Start()
    {
        SaveGameManager.Instance.SaveableObjects.Add(this);
        // Debug.Log(objectType + "added");
        // PlayerPrefs.SetInt("Age",30);
    }

    // Update is called once per frame
    public virtual void Save(int id)
    {
        //UID = Guid.NewGuid().ToString();
        if (transform.parent==null)
        {
            parentID = "0";
        }
        else
        {
            parentID = transform.parent.GetComponent<SaveableObject>().GetUID();
        }
        // value[0] = objectTpe, value[1]  = position, value[2] = localScale, value[3] = rotation, value[4,5] = savestats, value[6] = uid, value[7] = parentID
        PlayerPrefs.SetString(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex.ToString() + "-" + 
            id.ToString(), objectType + "_"+ transform.position.ToString() + "_" + transform.localScale + "_" + transform.localRotation + 
            "_" + saveStats + "_" + UID + "_" + parentID);
    }
    public virtual void Load(string[] values)
    {
        transform.localPosition = SaveGameManager.Instance.StringToVector(values[1]);
        transform.localScale  = cardshape;
        // transform.localRotation = SaveGameManager.Instance.StringToQuaternion(values[3]);
        transform.localRotation = defaultRotation;
        UID = values[6];
        parentID = values[7];
    }
    public virtual void TakeDamage(int damage)
    {
        
    }

    public void DestroySaveable()
    {
        SaveGameManager.Instance.SaveableObjects.Remove(this);
        Destroy(gameObject);
    }
    
    public string GetUID()
    {
        return UID;
    }
    public void SetUID(string uid)
    {
        UID = uid;
    }

    public ObjectType GetObjectType()
    {
        return objectType;
    }
}
