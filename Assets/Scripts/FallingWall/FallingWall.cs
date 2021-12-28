using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    public class FallingWall : MonoBehaviour
    {
        [SerializeField] private float logDuration = 2f;
        [SerializeField] private float logRespawnTime = 2f;

        private bool touched = false;
        private float timer = 0f;

        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider;


        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider = GetComponent<BoxCollider2D>();
        }


        void Update()
        {
            timer -= Time.deltaTime;
            if (touched)
            {
                if (timer <= 0)
                    ColapseLog();
            }
            else if (!boxCollider.enabled)
            {
                if (timer <= 0)
                    RestoreLog();
            }
        }

        private void RestoreLog()
        {
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }

        private void ColapseLog()
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
            WaitForRestor();
        }

        private void WaitForRestor()
        {
            timer = logRespawnTime;
            touched = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                timer = logDuration;
                touched = true;
            }
        }

    }
}
