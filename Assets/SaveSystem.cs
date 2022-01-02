using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Game.PlayerInfo;

namespace Game.SaveLoadSystem
{
    public static class SaveSystem
    {
        public static void SavePlayer(Player player)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/player.save";
            FileStream fs = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(player);

            formatter.Serialize(fs, data);
            fs.Close();

            path = Application.persistentDataPath + "/Level.save";
            fs = new FileStream(path, FileMode.Create);
            formatter.Serialize(fs, data.level);
            fs.Close();

        }

        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.save";
            if (!File.Exists(path))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            PlayerData data = binaryFormatter.Deserialize(fs) as PlayerData;
            fs.Close();

            return data;

        }

        public static int LoadLevel()
        {
            string path = Application.persistentDataPath + "/Level.save";
            if (!File.Exists(path))
                return -1;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            int level = (int)binaryFormatter.Deserialize(fs);
            fs.Close();
            return level;

        }


        public static void DeleteCheckpoint()
        {
            string path = Application.persistentDataPath + "/player.save";
            if (!File.Exists(path))
                return;
            File.Delete(path);
        }

        public static void DeleteAllSave()
        {
            string path = Application.persistentDataPath + "/player.save";
            string path1 = Application.persistentDataPath + "/Level.save";

            if (!File.Exists(path) && !File.Exists(path1))
                return;
            File.Delete(path);
            File.Delete(path1);
        }
    }
}
