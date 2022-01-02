using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game.PlayerInfo;
using Game.Collections;
using Game.SaveLoadSystem;

[System.Serializable]
public class PlayerData
{
    public int level;
    public float hungerTime;
    public float positionX;
    public float positionY;
    public float positionZ;
    public int[] berryIDS = new int[0];
    public float[] checkpointX = new float[0];

        
    public PlayerData(Player player)
    {
        level = SceneManager.GetActiveScene().buildIndex;
        hungerTime = player.time;
        positionX = player.transform.position.x;
        positionY = player.transform.position.y;

        GameObject[] berrys = GameObject.FindGameObjectsWithTag("Berry");

        for (int i = 0; i < berrys.Length; i++)
        {
            Array.Resize<int>(ref berryIDS, berryIDS.Length + 1);
            berryIDS[i] = berrys[i].GetComponent<Berry>().id; 
        }

        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Respawn");

        
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (checkpoints[i].GetComponent<SaveCheckpoint>().visited)
            {
                
                Array.Resize<float>(ref checkpointX, checkpointX.Length + 1);
                Debug.Log(checkpointX.Length);
                checkpointX[i] = checkpoints[i].transform.position.x;
            }
        }
        




    }


    }

