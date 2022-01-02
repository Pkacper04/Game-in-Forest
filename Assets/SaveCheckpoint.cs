using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.PlayerInfo;

namespace Game.SaveLoadSystem
{
    public class SaveCheckpoint : MonoBehaviour
    {
        internal bool visited = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && !visited)
            {
                visited = true;
                SaveSystem.SavePlayer(collision.GetComponent<Player>());
            }
        }
    }
}
