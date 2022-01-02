using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.PlayerInfo;


namespace Game.Collections
{
    public class Berry : MonoBehaviour
    {
        [SerializeField] private float addedHunger = 20f;

        static bool done = false;
        static int ids = 0;


        public int id = 0;


        private void Awake()
        {
            if (!done)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag("Berry");
                foreach (GameObject item in objects)
                {
                    item.GetComponent<Berry>().id = ids;
                    ids++;
                }
                done = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Player>().UpdateTime(addedHunger);
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            done = false;
            ids = 0;
        }

    }
}
