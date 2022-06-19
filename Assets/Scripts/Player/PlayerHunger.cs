
using UnityEngine;
using UnityEngine.UI;
using Game.Core;
using Game.SaveLoadSystem;
using NaughtyAttributes; 

namespace Game.PlayerInfo
{
    public class PlayerHunger : MonoBehaviour
    {

        [SerializeField]
        private HungerUI hungerUI;

        [SerializeField, InfoBox("HungerTime = 1 value is equal 1 minute")] private float hungerTime = 5f;

        internal float time;


        // Start is called before the first frame update
        void Start()
        {
            hungerTime *= 60f;
            time = hungerTime;
            LoadData();
            hungerUI.SetStartingTime(hungerTime);
        }

        private void LoadData()
        {
            PlayerData data = SaveSystem.LoadPlayer();
            if (data != null)
                time = data.hungerTime;
        }

        // Update is called once per frame
        void Update()
        {
            time -= Time.deltaTime;
            hungerUI.UpdateHungerUI(time);
            if (time <= 0)
                GameOverScript.GameOver();
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




