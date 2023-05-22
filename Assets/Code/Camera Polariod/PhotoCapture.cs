using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDislayArea;
    [SerializeField] private GameObject photoFrame;
    public Sprite[] photoSprite;

    [Header("Flash Effect")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    public GameObject camHud, darkRoomManager;
    public GameObject[] photoIcons;
    [SerializeField] private Texture2D[] screenCapture;
    public bool viewingPhoto;
    public bool canTakePhoto, photoRemoved, inCamera;

    public AudioSource photoSource;


    public int photoLimit, photoTaken, photoTotal;
    private void Start()
    {
        SetMaxLimit();
       
        
        camHud.SetActive(false);
    }

    private void Update()
    {
        if(canTakePhoto)
        {
            

            camHud.SetActive(true);
        }
        else
        {
            camHud.SetActive(false);
        }
            if (Input.GetMouseButtonDown(0) && canTakePhoto && photoLimit > 0)
            {
                if (!viewingPhoto)
                {
                    StartCoroutine(CapturePhoto());
                    photoRemoved = false;

                }
                else
                {
                    CheckLimit();
                    RemovePhoto();
                    photoRemoved = true;
                    
                }

            }
        if (Input.GetMouseButtonDown(1) && viewingPhoto) { CheckLimit(); RemovePhoto(); photoRemoved = true; }



    }

    IEnumerator CapturePhoto()
    {
        screenCapture[photoTotal] = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        // Camera UI set False
        viewingPhoto = true;
        camHud.SetActive(false);
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture[photoTotal].ReadPixels(regionToRead, 0, 0, false);
        screenCapture[photoTotal].Apply();
        ShowPhoto();
    }

    void ShowPhoto()
    {
        photoSprite[photoTotal] = Sprite.Create(screenCapture[photoTotal], new Rect(0.0f, 0.0f, screenCapture[photoTotal].width, screenCapture[photoTotal].height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDislayArea.sprite = photoSprite[photoTotal];


        photoFrame.SetActive(true);
        StartCoroutine(CameraFlashEffect());
        fadingAnimation.Play("PhotoFade");
    }

    IEnumerator CameraFlashEffect()
    {
        cameraFlash.SetActive(true);
        photoSource.Play();
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }

    void RemovePhoto()
    {
        darkRoomManager.GetComponent<DarkRoomPhotos>().PhotoTaken();
        viewingPhoto = false;
        photoLimit --;
        photoTaken++;
        photoTotal++;
        photoFrame.SetActive(false);
    }

    void CheckLimit()
    {
        photoIcons[photoTaken].SetActive(false);
    }

    public void SetMaxLimit()
    {
        photoIcons[0].SetActive(false);
        photoIcons[1].SetActive(false);
        photoIcons[2].SetActive(false);
        photoIcons[3].SetActive(false);
        photoIcons[4].SetActive(false);
        photoIcons[5].SetActive(false);
        
        for (int i = 0; i < photoLimit; i++)
        {
            photoIcons[i].SetActive(true);
        }
    }



}
