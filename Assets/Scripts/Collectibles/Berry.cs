using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Collections
{
    public class Berry : MonoBehaviour
    {
        [SerializeField] private float addedHunger = 20f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<LowerHunger>().UpdateTime(addedHunger);
                Destroy(gameObject);
            }
        }
    }
}
