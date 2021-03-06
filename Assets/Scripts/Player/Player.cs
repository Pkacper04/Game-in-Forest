using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Core;
using Game.SaveLoadSystem;
using Game.Collections;
using System;
using NaughtyAttributes; 

namespace Game.PlayerInfo
{
    public class Player : MonoBehaviour
    {

        [SerializeField] private Image hungerImage;
        [SerializeField, InfoBox("HungerTime = 1 value is equal 1 minute")] private float hungerTime = 5f;

        internal float time;
        private KillPlayer gameover;


        // Start is called before the first frame update
        void Start()
        {
            gameover = GameObject.FindWithTag("GameOver").GetComponent<KillPlayer>();
            hungerImage.fillAmount = 1;
            hungerTime *= 60f;
            time = hungerTime;
            LoadData();
        }

        private void LoadData()
        {
            PlayerData data = SaveSystem.LoadPlayer();
            if (data != null)
            {
                time = data.hungerTime;
                transform.position = new Vector2(data.positionX-2f, data.positionY);
            }
            else
                return;
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

        [ContextMenu("gameOver")]
        public void EndGame()
        {
            gameover.GameOver();
        }
    }
}




