using UnityEngine;
using UnityEngine.SceneManagement;
using Game.SaveLoadSystem;


namespace Game.Core
{
    public class KillPlayer : MonoBehaviour
    {

        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject playerHud;

        private void Start()
        {
            gameOverPanel.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
                GameOver();
        }

        internal void GameOver()
        {
            GameObject.FindWithTag("Player").SetActive(false);
            gameOverPanel.SetActive(true);
            playerHud.SetActive(false);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void HardRestart()
        {
            SaveSystem.DeleteAllSave();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        

    }
}
