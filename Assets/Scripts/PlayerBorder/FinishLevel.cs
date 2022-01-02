using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Game.Core
{
    public class FinishLevel : MonoBehaviour
    {
        [SerializeField] private string levelName = "null";
        [SerializeField] private int levelIndex = -1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (levelName != "null")
                    SceneManager.LoadScene(levelName);
                else if (levelIndex != -1)
                    SceneManager.LoadScene(levelIndex);
                else
                {
                    Debug.LogError("Podaj index sceny albo nazwe poziomu");
                }
            }
        }
    }
}
