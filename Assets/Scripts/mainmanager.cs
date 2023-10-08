using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class mainmanager : MonoBehaviour
{
    public static mainmanager data { get; private set; }
    public Color gamecolor;
    private void Awake()
    {
        if (data != null)
        {
            Destroy(gameObject);
            return;
        }
        data = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    [System.Serializable]
    class Savedata
    {
        public Color Savecolor;

    }
    public void Save()
    {
        Savedata data = new Savedata();
        data.Savecolor = gamecolor;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string filepath = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            Savedata data = JsonUtility.FromJson<Savedata>(json);
            gamecolor = data.Savecolor;
        }
    }
    
}
