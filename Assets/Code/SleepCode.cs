using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SleepCode : MonoBehaviour, IInteractable
{
    public GameObject gameManager;
    public void Interact()
    {
        gameManager = GameObject.Find("gamemanager");
        //fadetoblack, wait x seconds
        gameManager.GetComponent<GameManager>().GetInfoFinal();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
