using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    private static SaveGameManager instance;
    // [SerializeField]
    public List<SaveableObject> SaveableObjects{get; private set;}  
    public static SaveGameManager Instance
    {
        get 
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<SaveGameManager>(); 
            }
            return instance;
        }
        
    }
    // Start is called before the first frame update
    void Awake ()
    {
        SaveableObjects = new List<SaveableObject>(); 
        // Debug.Log()
    }

    private void OnEnable()
    {
        // int loadsavedlevelYes = PlayerPrefs.GetInt("loadsavedlevelYes") == 1 ?1:0;
        int loadsavedlevelYes = 0;
        Debug.Log(loadsavedlevelYes.ToString());
        if (loadsavedlevelYes == 1)
        {
            Load();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
    }


    public void Save()
    {
        PlayerPrefs.SetInt(Application.loadedLevel.ToString(),SaveableObjects.Count);
        Debug.Log(SaveableObjects.Count.ToString());
        for (int i = 0; i< SaveableObjects.Count; i++)
        {
            SaveableObjects[i].Save(i);
        }
        PlayerPrefs.SetInt("SavedLevel", Application.loadedLevel);
        PlayerPrefs.SetInt("loadsavedlevelYes", 1);
    }
    public void Load()
    {
        foreach(SaveableObject obj in SaveableObjects)
        {
            if (obj != null)
            {
                Destroy(obj.gameObject);

            }
        }

        SaveableObjects.Clear();
        int objectCount = PlayerPrefs.GetInt(Application.loadedLevel.ToString()); 

        for (int i = 0; i< objectCount;i++)
        {
            string[] value = PlayerPrefs.GetString(Application.loadedLevel.ToString() + "-" + i.ToString()).Split('_');
            GameObject tmp = null;
            switch(value[0])
            {
                case "Villager":
                    tmp = Instantiate(Resources.Load("Villager") as GameObject);
                    break;
                case "BerryBush":
                    tmp = Instantiate(Resources.Load("BerryBush") as GameObject);
                    break;
                case "Berry":
                    tmp = Instantiate(Resources.Load("Berry") as GameObject);
                    break;
            }
            Debug.Log(value[0]);
            if (tmp != null)
            {
                tmp.GetComponent<SaveableObject>().Load(value);
            }
            
        }
    }

    public Vector3 StringToVector(string value)
    {
        value = value.Trim(new char []{'(',')'});
        value = value.Replace(" ","");
        string[] pos = value.Split(",");

        return new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2]));
    }
    public Quaternion StringToQuaternion(string value)
    {
        value = value.Trim(new char []{'(',')'});
        value = value.Replace(" ","");
        string[] pos = value.Split(",");

        return new Quaternion(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2]), float.Parse(pos[3]));
    }
}
