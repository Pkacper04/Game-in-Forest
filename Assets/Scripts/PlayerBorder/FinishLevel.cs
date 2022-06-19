using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

namespace Game.Core
{
    public class FinishLevel : MonoBehaviour
    {
        [SerializeField,Scene] private string levelName;
        [SerializeField, Tag] private string playerTag;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == playerTag)
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }
}
