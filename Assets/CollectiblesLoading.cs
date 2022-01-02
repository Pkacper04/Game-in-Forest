using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Collections;

namespace Game.SaveLoadSystem
{
    public class CollectiblesLoading : MonoBehaviour
    {
        private List<float> savedPositionX;
        private void Awake()
        {
            PlayerData data = SaveSystem.LoadPlayer();

            if (data != null)
            {
                #region BerryLoading
                List<int> berryid = new List<int>(data.berryIDS);

                GameObject[] Berrys = GameObject.FindGameObjectsWithTag("Berry");

                SortedList<int, int> Berryid = new SortedList<int, int>();

                for (int i = 0; i < Berrys.Length; i++)
                    Berryid.Add(i, Berrys[i].GetComponent<Berry>().id);

                for (int i = 0; i < Berryid.Capacity; i++)
                    if (!berryid.Contains(Berryid[i]))
                        Destroy(Berrys[i]);
                #endregion BerryLoading

                #region CheckpointsLoading

                GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Respawn");
                

                if (data.checkpointX.Length > 0)
                    savedPositionX = new List<float>(data.checkpointX);

                foreach (GameObject value in checkpoints)
                    if (savedPositionX.Contains(value.transform.position.x))
                        value.GetComponent<BoxCollider2D>().enabled = false;

                #endregion CheckpointsLoading

            }
        }
    }
}
