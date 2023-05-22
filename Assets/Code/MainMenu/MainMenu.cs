using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LOADING 2");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }

    public void Liam()
    {
        SceneManager.LoadScene("Liam");
    }

    public void Alex()
    {
        SceneManager.LoadScene("Alex");
    }
    public void Elliot()
    {
        SceneManager.LoadScene("Elliot");
    }

    public void Jude()
    {
        SceneManager.LoadScene("Jude");
    }

    public void Jeremiah()
    {
        SceneManager.LoadScene("Jeremiah");
    }

    public void OpenURL()
    {
        Application.OpenURL("https://youtu.be/3GKNwz9vUeE");
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
    public void LiamURL()
    {
        Application.OpenURL("https://youtu.be/ndEEbMPCyOo");
    }
    public void JudeURL()   
    {
        Application.OpenURL("https://www.youtube.com/watch?v=te6rMsNJR-g");
    }
    public void AlexURL()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=fTczCpIaLAU");
    }
    public void ElliotURL()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=WIRK_pGdIdA");
    }
    public void BackCredits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
}