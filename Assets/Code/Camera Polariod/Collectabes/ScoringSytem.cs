using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSytem : MonoBehaviour
{
    public GameObject scoreText;
    public int score;
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        score += 50;
        scoreText.GetComponent<Text>().text = "SCORE: " + score;
        Destroy(gameObject);
    }
}
