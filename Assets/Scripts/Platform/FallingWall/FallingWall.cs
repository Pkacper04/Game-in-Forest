using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
namespace Game.Terrain
{
    public class FallingWall : MonoBehaviour
    {
        [SerializeField] private float logDuration = 2f;
        [SerializeField] private float logRespawnTime = 2f;
        [SerializeField, Tag] private string playerTag;
        [SerializeField] private SpriteRenderer logRenderer;
        [SerializeField] private BoxCollider2D[] logColliders;


        private Coroutine controlCoroutine = null;

        private void RestoreLog()
        {
            logRenderer.enabled = true;
            foreach(BoxCollider2D collider in logColliders)
                collider.enabled = true;
        }

        private void ColapseLog()
        {
            logRenderer.enabled = false;
            foreach (BoxCollider2D collider in logColliders)
                collider.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == playerTag)
            {
                if (controlCoroutine != null)
                    return;
                controlCoroutine = StartCoroutine(LogInteraction());
            }
        }

        private IEnumerator LogInteraction()
        {
            yield return new WaitForSeconds(logDuration);
            ColapseLog();
            yield return new WaitForSeconds(logRespawnTime);
            RestoreLog();
            controlCoroutine = null;
        }

    }
}
