using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Game.SaveLoadSystem
{
    public class SaveCheckpoint : MonoBehaviour
    {

        [SerializeField]
        private CheckpointController controller;

        [SerializeField, Tag]
        private string playerTag;
        
        public bool visited = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!visited && collision.gameObject.tag == playerTag)
            {
                visited = true;
                controller.Visited(this);
                controller.SaveGame();
            }
        }
    }
}
