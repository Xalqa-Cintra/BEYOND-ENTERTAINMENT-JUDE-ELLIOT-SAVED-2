using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaperCode : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject[] buttonChildren;
    public Sprite[] newspaperImgs;
    public RawImage[] imgLocations;
    public RawImage[] finalLocation;
    public Text requirementsText, paperHeader;
    public List<string> keywords;
    bool toggle, toggle1, canGoNextDay;
    public string input;
    public int keywordUsed;
    private void Awake()
    {
        gameManager = GameObject.Find("gamemanager");
        gameManager.GetComponent<GameManager>().MoveScene();
        
        if (gameManager.GetComponent<GameManager>().moralStatus > 0 && (gameManager.GetComponent<GameManager>().missionSucceed1 == false || gameManager.GetComponent<GameManager>().missionSucceed2 == false || gameManager.GetComponent<GameManager>().missionSucceed3 == false))
        {
            buttonChildren[4].SetActive(true);
        }




        if (gameManager.GetComponent<GameManager>().Day == 0) 
        {
            newspaperImgs[0] = gameManager.GetComponent<GameManager>().newspaperSprites[0];
            newspaperImgs[1] = gameManager.GetComponent<GameManager>().newspaperSprites[1];
            imgLocations[0].texture = newspaperImgs[0].texture;
            imgLocations[1].texture = newspaperImgs[1].texture;
        }
        if (gameManager.GetComponent<GameManager>().Day == 1)
        {
            newspaperImgs[2] = gameManager.GetComponent<GameManager>().newspaperSprites[2];
            newspaperImgs[3] = gameManager.GetComponent<GameManager>().newspaperSprites[3];
            imgLocations[0].texture = newspaperImgs[2].texture;
            imgLocations[1].texture = newspaperImgs[3].texture;
        }
        if (gameManager.GetComponent<GameManager>().Day == 2)
        {
            newspaperImgs[4] = gameManager.GetComponent<GameManager>().newspaperSprites[4];
            newspaperImgs[5] = gameManager.GetComponent<GameManager>().newspaperSprites[5];
            imgLocations[0].texture = newspaperImgs[4].texture;
            imgLocations[1].texture = newspaperImgs[5].texture;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (gameManager.GetComponent<GameManager>().moralStatus == 3)
        {
            requirementsText.text = "We want the keywords: " + keywords[0] + "," + keywords[1] + "," + keywords[2];
        }
        if(gameManager.GetComponent<GameManager>().moralStatus == 2)
        {
           requirementsText.text = "We want the keywords: " + keywords[3] + "," + keywords[4] + "," + keywords[5];
        }
        if(gameManager.GetComponent<GameManager>().moralStatus == 1)
        {
           requirementsText.text = "We want the keywords: " + keywords[6] + "," + keywords[7] + "," + keywords[8];
        }
    }


    public void TRButton()
    {
        buttonChildren[0].SetActive(toggle);
        buttonChildren[1].SetActive(toggle);
        toggle= !toggle;
    }
    public void BRButton()
    {
        buttonChildren[2].SetActive(toggle1);
        buttonChildren[3].SetActive(toggle1);
        toggle1= !toggle1;
    }
    public void TRButton1()
    {
        finalLocation[0].texture = imgLocations[0].texture;

    }
    public void TRButton2()
    {
        finalLocation[0].texture = imgLocations[1].texture;
    }
    public void BRButton1()
    {
        finalLocation[1].texture = imgLocations[0].texture;
    }
    public void BRButton2()
    {
        finalLocation[1].texture = imgLocations[1].texture;
    }

    public void Next()
    {
        if (keywordUsed == 0) { canGoNextDay = false; } else { canGoNextDay = true; }
        gameManager.GetComponent<GameManager>().GetNewsInfo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ReadStringInput(string s)
    {
        
        input = s;
        paperHeader.text = s;
        string[] inputArray = input.Split(' ');

        for (int i = 0; i < inputArray.Length; i++)
        {
            if (keywords.Find(keyword => keyword == inputArray[i]) != null)
            {
                keywordUsed++;
            }
        }
    }


}
