using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static int points;
    public static int lives;
    public static int currentLevel;
    public Text pointsScreen;
    public Text livesScreen;

    public bool isPaused;
    public GameObject pausePanel;

    public AudioSource audioSource;

	void Start () {
        audioSource.time = 60.0f;
        audioSource.Play();
        isPaused = false;
        lives = 2;
        points = 0;
        currentLevel = 1;
    }

    void Update () {
        RefreshInterfaceInfos();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseStatus();
        }

        livesScreen.text = lives.ToString();

    }

    /**
     * Pausa e continua o jogo, através do botão no menu ou do botão no teclado
     */
    public void ChangePauseStatus()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
        }

    }

    /**
     * Atualiza a pontuação na tela.
     */
    void RefreshInterfaceInfos()
    {
        pointsScreen.text = points.ToString();
    }

}
