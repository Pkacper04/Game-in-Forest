using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;


namespace Player
{
    public class LowerHunger : MonoBehaviour
    {
        [SerializeField] private Image hungerImage;
        [SerializeField, Tooltip("1 value is equal to 1 minute")] private float hungerTime = 5f;

        private float time;
        private KillPlayer gameover;

        // Start is called before the first frame update
        void Start()
        {
            gameover = GameObject.FindWithTag("GameOver").GetComponent<KillPlayer>();
            hungerImage.fillAmount = 1;
            hungerTime *= 60f;
            time = hungerTime;
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
