using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveSystem : MonoBehaviour
{
    public static void SavePlayer(CharacterStats character)
    {
        BinaryFormatter format = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerSaveInfo";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(character);
        format.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerSaveInfo";
        if (File.Exists(path))
        {
            BinaryFormatter format = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = format.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File Could Not Be Found");
            return null;
        }
    }
}
