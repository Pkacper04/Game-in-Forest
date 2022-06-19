using System.Collections.Generic;
using Game.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelData
{
    public int level;
    public List<int> foodID = new List<int>();
    public List<bool> checkpoints = new List<bool>();

    public LevelData(CollectiblesLoading collections, CheckpointController checkpoint)
    {
        level = SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i < collections.pickedUpFood.Count; i++)
            foodID.Add(collections.pickedUpFood[i]);

        foreach (bool value in checkpoint.visitedCheckpoints)
            checkpoints.Add(value);
    }
}
