using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public int moralStatus; //1 = immoral, 2 = neutral, 3 = moral
    public Sprite[] newspaperSprites;
    public GameObject darkRoomManger, paperManager;
    public int Day;
    bool firstLoad;

    [Header("Mission 1")]
    public bool missionSucceed1;
    public int day1Value, keywordsUsedStorage1;
    public Texture[] paper1;
    public string paper1Header;
    [Header("Mission 2")]
    public bool missionSucceed2;
    public int day2Value, keywordsUsedStorage2;
    public Texture[] paper2;
    public string paper2Header;
    [Header("Mission 3")]
    public bool missionSucceed3;
    public int day3Value, keywordsUsedStorage3;
    public Texture[] paper3;
    public string paper3Header;

    private void Start()
    {
        darkRoomManger = GameObject.Find("DarkRoomManager");
        paperManager = GameObject.Find("PaperManager");

    }
    public void MoveScene()
    {
        darkRoomManger = GameObject.Find("DarkRoomManager");
        paperManager = GameObject.Find("PaperManager");
        
    }
    public void GetInfoFinal()
    {
        darkRoomManger.GetComponent<DarkRoomPhotos>().FinalCheck();
        moralStatus = darkRoomManger.GetComponent<DarkRoomPhotos>().finalMoral;
        
        
        if (Day == 0) 
        { 
            CheckMissionComplete1(); day1Value = darkRoomManger.GetComponent<DarkRoomPhotos>().finalMoral;
            newspaperSprites[0] = darkRoomManger.GetComponent<DarkRoomPhotos>().finalSprite[0].sprite;
            newspaperSprites[1] = darkRoomManger.GetComponent<DarkRoomPhotos>().finalSprite[1].sprite;
        }
        if (Day == 1) 
        { 
            CheckMissionComplete2(); day2Value = darkRoomManger.GetComponent<DarkRoomPhotos>().finalMoral;
            newspaperSprites[2] = darkRoomManger.GetComponent<DarkRoomPhotos>().finalSprite[0].sprite;
            newspaperSprites[3] = darkRoomManger.GetComponent<DarkRoomPhotos>().finalSprite[1].sprite;
        }
        if (Day == 2) 
        { 
            CheckMissionComplete3(); day3Value = darkRoomManger.GetComponent<DarkRoomPhotos>().finalMoral;
            newspaperSprites[4] = darkRoomManger.GetComponent<DarkRoomPhotos>().finalSprite[0].sprite;
            newspaperSprites[5] = darkRoomManger.GetComponent<DarkRoomPhotos>().finalSprite[1].sprite;
        }

    }
    public void CheckMissionComplete1()
    {
        if(darkRoomManger.GetComponent<DarkRoomPhotos>().finalSoldiers==3)
        {
            missionSucceed1= true;
        }
        //check each soldier is in photo, 
    }
    public void CheckMissionComplete2()
    {
        if (darkRoomManger.GetComponent<DarkRoomPhotos>().countedSarge == true)
        {
            missionSucceed2 = true;
        }
        //check each soldier is in photo, 
    }
    public void CheckMissionComplete3()
    {
        if (darkRoomManger.GetComponent<DarkRoomPhotos>().finalMoral >= 3)
        {
            missionSucceed3 = true;
        }
        //check each soldier is in photo, 
    }
    public void GetNewsInfo()
    {
        
        if(Day == 0)
        {
            keywordsUsedStorage1 = paperManager.GetComponent<PaperCode>().keywordUsed;
            paper1[0] = newspaperSprites[0].texture;
            paper1[1] = newspaperSprites[1].texture;
            paper1Header = paperManager.GetComponent<PaperCode>().paperHeader.text;
        }
        if(Day == 1)
        {
            keywordsUsedStorage2 = paperManager.GetComponent<PaperCode>().keywordUsed;
            paper2[0] = newspaperSprites[2].texture;
            paper2[1] = newspaperSprites[3].texture;
            paper2Header = paperManager.GetComponent<PaperCode>().paperHeader.text;
        }
        if(Day == 2) 
        {
            keywordsUsedStorage3 = paperManager.GetComponent<PaperCode>().keywordUsed;
            paper3[0] = newspaperSprites[4].texture;
            paper3[1] = newspaperSprites[5].texture;
            paper3Header = paperManager.GetComponent<PaperCode>().paperHeader.text;
        }
        Day++;
    }

    public void FirstLoad()
    {
        if(firstLoad == false)
        {
            DontDestroyOnLoad(this.gameObject);
            gameObject.GetComponent<AudioSource>().Play();
            firstLoad = true;
        }

    }

}
