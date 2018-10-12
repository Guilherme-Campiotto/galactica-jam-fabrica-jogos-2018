using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameOverPanel;
    public GameObject pointsPanel;
    public Text scoreNumbers;
	
	void Update () {
        scoreNumbers.text = GameController.points.ToString();
    }

    /**
     * Reinicia o jogo.
     */
    public void Restart()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("Main Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
