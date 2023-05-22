using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierState : MonoBehaviour
{
    // each soldier own values
    public bool moral;
    public bool immoral;
    public bool neutral;

    public int moralValue, minValueI, maxValueI, minValueM, maxValueM, minValueN, maxValueN;

    public bool canSee;
    public bool inView;
    public float camRange;

    public LayerMask npcLayer;
    public GameObject player;
    public GameObject manager;
    public GameObject maxView;

    //set value to bools depending on rng maybe, most likely jus predetermined for now
    private void Start()
    {
        if (moral)
        {
            moralValue = Random.Range(minValueM, maxValueM);
        }
        if (immoral)
        {
            moralValue = Random.Range(minValueI, maxValueI);
        }
        if (neutral)
        {
            moralValue = Random.Range(minValueN, maxValueN);
        }
    }

    private void OnBecameVisible()
    {
        CheckIfSeen();
    }
    private void OnBecameInvisible()
    {
        canSee = false;
    }

    void CheckIfSeen()
    {
        Ray re = new Ray(player.transform.position, this.transform.position);
        if (Physics.Raycast(re, out RaycastHit hitInfo, camRange))
        {
            canSee = false;

        }
        else
        {
            canSee = true;
        }
    }

}
