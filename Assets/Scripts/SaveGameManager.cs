using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SaveGameManager : MonoBehaviour
{
    private static SaveGameManager instance;
    // [SerializeField]
    public List<SaveableObject> SaveableObjects{get; private set;}  
    //public int loadedObject = 0;
    private int objectCount = -1;
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
    }

    private void OnEnable()
    {
        Debug.Log("Enabled");
        int loadsavedlevelYes = PlayerPrefs.GetInt("loadsavedlevelYes") == 1 ? 1:0;
        if (loadsavedlevelYes == 1)
        {
            Load();
            PlayerPrefs.SetInt("loadsavedlevelYes", 0);
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
        if(objectCount == SaveableObjects.Count)
        {
            SetParents();
            objectCount = -1;
        }
    }


    public void Save()
    {
        PlayerPrefs.SetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex.ToString(),SaveableObjects.Count);
        Debug.Log("save " + SaveableObjects.Count + "objects");
        //generate guid for every saveable objects
        for (int i = 0; i< SaveableObjects.Count; i++)
        {
            string uid = Guid.NewGuid().ToString();
            SaveableObjects[i].GetComponent<SaveableObject>().SetUID(uid);
        }
        //Save every object
        for (int i = 0; i< SaveableObjects.Count; i++)
        {
            SaveableObjects[i].Save(i);
        }
        //PlayerPrefs.SetInt("SavedLevel", Application.loadedLevel);
        PlayerPrefs.SetInt("SavedLevel", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("loadsavedlevelYes", 1);
    }
    public void Load()
    {
        
        foreach(SaveableObject obj in SaveableObjects)
        {

            Debug.Log("!!!!!!");
            if (obj != null)
            {
                Destroy(obj.gameObject);

            }
        }

        SaveableObjects.Clear();
        objectCount = PlayerPrefs.GetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex.ToString()); 
        Debug.Log("Load " + objectCount + "objects");
        for (int i = 0; i< objectCount;i++)
        {
            string[] value = PlayerPrefs.GetString(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex.ToString() + "-" + i.ToString()).Split('_');
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
                case "Quarry":
                    tmp = Instantiate(Resources.Load("Quarry") as GameObject);
                    break;
                case "LumberCamp":
                    tmp = Instantiate(Resources.Load("lumberCamp") as GameObject);
                    break;
                case "Pack":
                    tmp = Instantiate(Resources.Load("NewWorld") as GameObject);
                    break;
                case "Wood":
                    tmp = Instantiate(Resources.Load("Wood") as GameObject);
                    break;
                case "Stone":
                    tmp = Instantiate(Resources.Load("Stone") as GameObject);
                    break;
            }
            if (tmp != null)
            {
                
                tmp.GetComponent<SaveableObject>().Load(value);
            }
            
        }
        //SetParents();
    }

    public void SetParents()
    {
        //Debug.Log("Set parents");
        // Debug.Log(objectCount.ToString());
        // Debug.Log(SaveableObjects.Count.ToString());
                Dictionary<string, int> tmpDict = 
                       new Dictionary<string, int>();

        for (int i = 0; i< objectCount; i+=1)
        {
            string uid = SaveableObjects[i].GetUID();
            // Debug.Log("uid = "+uid);
            tmpDict.Add(uid,i);
        }
        for (int i = 0; i< objectCount; i+=1)
        {
            // Debug.Log(SaveableObjects[i].parentID);
            if(SaveableObjects[i].parentID != "0")
            {

                Debug.Log(tmpDict[SaveableObjects[i].parentID].ToString());
                SaveableObjects[i].transform.parent = SaveableObjects[tmpDict[SaveableObjects[i].parentID]].transform;
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
