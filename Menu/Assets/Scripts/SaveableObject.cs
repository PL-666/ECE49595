using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType {Villager,BerryBush,Berry}

public abstract class SaveableObject : MonoBehaviour
{
    protected string saveStats;
    [SerializeField]
    private ObjectType objectType;
    // Start is called before the first frame update
    private void Start()
    {
        SaveGameManager.Instance.SaveableObjects.Add(this);
        Debug.Log(transform.position.ToString());
        // PlayerPrefs.SetInt("Age",30);
    }

    // Update is called once per frame
    public virtual void Save(int id)
    {
        PlayerPrefs.SetString(Application.loadedLevel.ToString() + "-" + id.ToString(), objectType + "_"+ transform.position.ToString() + "_" + transform.localScale + "_" + transform.localRotation + "_" + saveStats);
    }
    public virtual void Load(string[] values)
    {
        // int age = PlayerPrefs.GetInt("Age");
        transform.localPosition = SaveGameManager.Instance.StringToVector(values[1]);
        transform.localScale  = SaveGameManager.Instance.StringToVector(values[2]);
        transform.localRotation = SaveGameManager.Instance.StringToQuaternion(values[3]);
    }
    public void DestroySaveable()
    {
        SaveGameManager.Instance.SaveableObjects.Remove(this);
        Destroy(gameObject);
    }

}
