using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Game.PlayerInfo;
using Game.Collections;

namespace Game.SaveLoadSystem
{
    public static class SaveSystem
    {
        public static void SaveGame(PlayerHunger player, CollectiblesLoading collections, CheckpointController controller)
        {
            SavePlayer(player);
            SaveLevel(collections,controller);
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

        public static LevelData LoadLevel()
        {
            string path = Application.persistentDataPath + "/Level.save";
            if (!File.Exists(path))
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            LevelData data = binaryFormatter.Deserialize(fs) as LevelData;
            fs.Close();

            return data;
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




        private static void SavePlayer(PlayerHunger player)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/player.save";
            FileStream fs = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(player);

            formatter.Serialize(fs, data);
            fs.Close();
        }

        private static void SaveLevel(CollectiblesLoading collections, CheckpointController controller)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/Level.save";
            FileStream fs = new FileStream(path, FileMode.Create);

            LevelData data = new LevelData(collections,controller);

            formatter.Serialize(fs, data);
            fs.Close();
        }
    }
}
