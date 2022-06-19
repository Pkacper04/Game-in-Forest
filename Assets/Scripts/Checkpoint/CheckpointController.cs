using System.Collections.Generic;
using UnityEngine;
using Game.SaveLoadSystem;
using Game.Collections;
using Game.PlayerInfo;
using NaughtyAttributes;
public class CheckpointController : MonoBehaviour
{
    [ReorderableList]
    public List<SaveCheckpoint> checkpoints = new List<SaveCheckpoint>();

    [SerializeField]
    private CollectiblesLoading collectibles;

    [SerializeField]
    private Player player;



    [HideInInspector]
    public List<bool> visitedCheckpoints = new List<bool>();


    // Start is called before the first frame update
    void Start()
    {

        LevelData data = SaveSystem.LoadLevel();

        if (data != null)
        {
            for(int i=0;i<data.checkpoints.Count;i++)
            {
                checkpoints[i].visited = data.checkpoints[i];
                visitedCheckpoints.Add(data.checkpoints[i]);
            }
        }
        else
        {
            for(int i=0;i<checkpoints.Count;i++)
            {
                visitedCheckpoints.Add(false);
            }
        }

    }

    public void Visited(SaveCheckpoint checkpoint)
    {
        visitedCheckpoints[checkpoints.IndexOf(checkpoint)] = true;
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(player, collectibles, this);
    }
}
