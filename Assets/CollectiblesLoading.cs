using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Collections;

namespace Game.SaveLoadSystem
{
    public class CollectiblesLoading : MonoBehaviour
    {
        private void Start()
        {
            PlayerData data = SaveSystem.LoadPlayer();

            if (data != null)
            {
                #region BerryLoading
                List<int> berryid = new List<int>(data.berryIDS);

                GameObject[] Berrys = GameObject.FindGameObjectsWithTag("Berry");

                List<int> Berryid = new List<int>();

                for (int i = 0; i < Berrys.Length; i++)
                    Berryid.Add(Berrys[i].GetComponent<Berry>().id);

                for (int i = 0; i < Berryid.Capacity; i++)
                {
                    if (!berryid.Contains(Berryid[i]))
                    {
                        Destroy(Berrys[i]);
                    }
                }
                #endregion BerryLoading

                #region CheckpointLoading

                List<float> checkpointX = new List<float>(data.checkpointX);

                GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Respawn");

                foreach (var item in checkpoints)
                {
                    if(checkpointX.Contains(item.transform.position.x))
                        item.GetComponent<SaveCheckpoint>().visited = true;
                }

                #endregion CheckpointLoading


            }
        }
    }
}
