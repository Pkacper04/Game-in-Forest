using UnityEngine;
using NaughtyAttributes;

namespace Game.Core
{
    public class KillPlayer : MonoBehaviour
    {
        [SerializeField,Tag] private string playerTag;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == playerTag)
                GameOverScript.GameOver();
        }  
    }
}
