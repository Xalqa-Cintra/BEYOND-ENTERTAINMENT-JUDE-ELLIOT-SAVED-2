using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;
    public  static bool isPaused;
    public CharacterController Playerwcam1;

    void Start() {
        pauseMenu = GameObject.Find("PauseMenuUI");
        pauseMenu.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Playerwcam1.enabled = false;
    }

    public void ResumeGame() {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Playerwcam1.enabled = true;
    }

    public void GoToMainMenu() {
        Time.timeScale = 0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting Game ...");
    }
}