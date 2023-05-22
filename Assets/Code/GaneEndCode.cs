using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GaneEndCode : MonoBehaviour
{
    GameObject gameManager;
    public RawImage[] photos;
    public Text[] headers;

    public Text[] missions;
    public Text[] score;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("gamemanager");
        if (gameManager.GetComponent<GameManager>().missionSucceed1) { missions[0].text = "QUOTA MET"; } else { missions[0].text = "QUOTA FAILED"; }
        if (gameManager.GetComponent<GameManager>().missionSucceed2) { missions[1].text = "QUOTA MET"; } else { missions[1].text = "QUOTA FAILED"; }
        if (gameManager.GetComponent<GameManager>().missionSucceed3) { missions[2].text = "QUOTA MET"; } else { missions[2].text = "QUOTA FAILED"; }

        score[0].text = "Score:" + (gameManager.GetComponent<GameManager>().day1Value + (gameManager.GetComponent<GameManager>().day1Value * gameManager.GetComponent<GameManager>().keywordsUsedStorage1));
        score[1].text = "Score:" + (gameManager.GetComponent<GameManager>().day2Value + (gameManager.GetComponent<GameManager>().day2Value * gameManager.GetComponent<GameManager>().keywordsUsedStorage2));
        score[2].text = "Score:" + (gameManager.GetComponent<GameManager>().day3Value + (gameManager.GetComponent<GameManager>().day1Value * gameManager.GetComponent<GameManager>().keywordsUsedStorage3));

        photos[0].texture = gameManager.GetComponent<GameManager>().paper1[0];
        photos[1].texture = gameManager.GetComponent<GameManager>().paper1[1];
        photos[2].texture = gameManager.GetComponent<GameManager>().paper2[0];
        photos[3].texture = gameManager.GetComponent<GameManager>().paper2[1];
        photos[4].texture = gameManager.GetComponent<GameManager>().paper3[0];
        photos[5].texture = gameManager.GetComponent<GameManager>().paper3[1];

        headers[0].text = gameManager.GetComponent<GameManager>().paper1Header;
        headers[1].text = gameManager.GetComponent<GameManager>().paper2Header;
        headers[2].text = gameManager.GetComponent<GameManager>().paper3Header;
    }
}
