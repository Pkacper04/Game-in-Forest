using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using Game.SaveLoadSystem;

public class GameOverScript : MonoBehaviour
{

    [SerializeField, BoxGroup("GameOver")] private Canvas gameOverCanvas;
    [SerializeField, BoxGroup("GameOver")] private GraphicRaycaster gameOverRaycaster;

    [SerializeField, BoxGroup("PlayerHud")] private Canvas playerHud;
    [SerializeField, BoxGroup("PlayerHud")] private GraphicRaycaster playerRaycaster;


    public static GameOverScript Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        disableGameOver();
        enablePlayerHud();
    }


    public static void enablePlayerHud()
    {
        GameOverScript.Instance.playerHud.enabled = true;
        GameOverScript.Instance.playerRaycaster.enabled = true;
    }

    public static void disablePlayerHud()
    {
        GameOverScript.Instance.playerHud.enabled = false;
        GameOverScript.Instance.playerRaycaster.enabled = false;
    }
    
    public static void enableGameOver()
    {
        GameOverScript.Instance.gameOverCanvas.enabled = true;
        GameOverScript.Instance.gameOverRaycaster.enabled = true;
    }

    public static void disableGameOver()
    {
        GameOverScript.Instance.gameOverCanvas.enabled = false;
        GameOverScript.Instance.gameOverCanvas.enabled = false;
    }

    public static void GameOver()
    {
        enableGameOver();
        disablePlayerHud();
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
