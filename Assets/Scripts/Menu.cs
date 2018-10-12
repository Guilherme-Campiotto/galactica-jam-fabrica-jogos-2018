using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public bool isCreditsActive;
    public bool isTutorialActive;
    public GameObject creditsPanel;
    public GameObject tutorialPanel;

    public void Start()
    {
        isCreditsActive = false;
        isTutorialActive = false;
    }

    public void Update()
    {
        if (isCreditsActive)
        {
            creditsPanel.SetActive(true);
        }

        if (isTutorialActive)
        {
            tutorialPanel.SetActive(true);
        }
    }

    /**
     * Inicia o jogo.
     */
    public void Play()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    /**
     * Ativa/desativa a tela de créditos.
     */
    public void ToggleCredits()
    {
        if (isCreditsActive)
        {
            isCreditsActive = false;
            creditsPanel.SetActive(false);
        } else
        {
            isCreditsActive = true;
            creditsPanel.SetActive(true);
        }
    }

    /**
     * Ativa/desativa a tela do tutorial.
     */
    public void ToggleTutorial()
    {
        if (isTutorialActive)
        {
            isTutorialActive = false;
            tutorialPanel.SetActive(false);
        }
        else
        {
            isTutorialActive = true;
            tutorialPanel.SetActive(true);
        }
    }
}
