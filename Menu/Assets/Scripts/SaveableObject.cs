using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType {Villager,BerryBush,Berry}

public abstract class SaveableObject : MonoBehaviour
{
    protected string save;
    [SerializeField]
    private ObjectType objectType;
    // Start is called before the first frame update
    private void Start()
    {
        SaveGameManager.Instance.SaveableObjects.Add(this);
        // PlayerPrefs.SetInt("Age",30);
    }

    // Update is called once per frame
    public virtual void Save(int id)
    {
        PlayerPrefs.SetString(id.ToString(), objectType + "_"+ transform.position.ToString());
    }
    public virtual void Load(string[] values)
    {
        // int age = PlayerPrefs.GetInt("Age");
        transform.localPosition = SaveGameManager.Instance.StringToVector(values[1]);
    }
    public void DestroySaveable()
    {

    }

}
