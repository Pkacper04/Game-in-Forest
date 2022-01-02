using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Core;
using Game.SaveLoadSystem;
using Game.Collections;

namespace Game.PlayerInfo
{
    public class Player : MonoBehaviour
    {

        [SerializeField] private Image hungerImage;
        [SerializeField, Tooltip("1 value is equal to 1 minute")] private float hungerTime = 5f;

        internal float time;
        private KillPlayer gameover;


        private void OnEnable()
        {
            gameover = GameObject.FindWithTag("GameOver").GetComponent<KillPlayer>();
            hungerImage.fillAmount = 1;
            hungerTime *= 60f;
            time = hungerTime;
        }

        // Start is called before the first frame update
        void Start()
        {
            PlayerData data = SaveSystem.LoadPlayer();
            if (data != null)
            {
                time = data.hungerTime;
                transform.position = new Vector2(data.positionX, data.positionY);

            }

        }

        // Update is called once per frame
        void Update()
        {
            time -= Time.deltaTime;
            hungerImage.fillAmount = time / hungerTime;

            if (time <= 0)
                gameover.GameOver();
        }


        public void UpdateTime(float duration)
        {
            if (time + duration <= hungerTime)
                time += duration;
            else
                time = hungerTime;
        }
    }
}




