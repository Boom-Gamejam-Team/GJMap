using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveDataManager : MonoBehaviour
{
    public Inventory myBag;
    public void SaveData()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/game_saveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_saveData");
        }

        //���ݶ�����ת��
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/game_saveData/myBag.txt");
        //ת��js�ļ�
        var js = JsonUtility.ToJson(myBag);
        formatter.Serialize(file, js);
        file.Close();
    }
    public void LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "/game_saveData/myBag.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_saveData/myBag.txt",FileMode.Open);

            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(file), myBag);

            file.Close();
        }
    }
}
