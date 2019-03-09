using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class scr_MasterController : MonoBehaviour
{
    // Static reference
    public static scr_MasterController masterController;

    //=Persistant Data=

    //==================

    void Awake()
    {
        if (masterController == null)
        {
            DontDestroyOnLoad(gameObject);
            masterController = this;
        }
        else if (masterController != this)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        Load();
    }
    void OnDisable()
    {
        Save();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/userData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/userData.dat", FileMode.Open);
            UserData data = (UserData)bf.Deserialize(file);
            file.Close();
        }
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/userData.dat");
        UserData data = new UserData();
        bf.Serialize(file, data);
        file.Close();
    } 
}

[Serializable]
class UserData
{
    public UserData()
    {

    }
}