using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.PlayerInfo;
using NaughtyAttributes;

namespace Game.Collections
{
    public class Berry : MonoBehaviour
    {
        [SerializeField] private float addedHunger = 20f;
        [SerializeField] private PlayerHunger playerHunger;
        [SerializeField, Tag] private string playerTag;
        [SerializeField, Tag] private string bodyTag;

        [SerializeField]
        private CollectiblesLoading controller;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == playerTag || collision.tag == bodyTag)
            {
                playerHunger.UpdateTime(addedHunger);
                gameObject.SetActive(false);
                controller.PickUp(this);
            }
        }

        public void Collected() => gameObject.SetActive(false);

    }
}
