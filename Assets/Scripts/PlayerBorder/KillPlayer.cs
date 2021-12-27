using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject gameOverImage;


    private void Start()
    {
        gameOverImage.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            GameOver();
    }

    internal void GameOver()
    {
        GameObject.FindWithTag("Player").SetActive(false);
        gameOverImage.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
