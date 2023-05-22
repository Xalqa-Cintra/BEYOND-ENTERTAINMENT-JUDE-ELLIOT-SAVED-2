using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotosInfo : MonoBehaviour, IInteractable
{
    public GameObject soldierManager;
    public GameObject darkRoomManager;
    public int photoValue;
    public bool[] soldierSeen;
    public bool selected;
    public float moveDistance;

    public void FindInfo()
    {
        photoValue = soldierManager.GetComponent<SoldierCode>().totalMoral;

        soldierSeen[0] = soldierManager.GetComponent<SoldierCode>().soldier1Seen;
        soldierSeen[1] = soldierManager.GetComponent<SoldierCode>().soldier2Seen;
        soldierSeen[2] = soldierManager.GetComponent<SoldierCode>().soldier3Seen;
        soldierSeen[3] = soldierManager.GetComponent<SoldierCode>().soldier4Seen;
        soldierSeen[4] = soldierManager.GetComponent<SoldierCode>().soldier5Seen;


    }
    public void Interact()
    {
        if (darkRoomManager.GetComponent<DarkRoomPhotos>().selectedAmt < 2)
        { 
            selected = !selected;
            if (selected == true)
            {
                gameObject.transform.position += Vector3.forward * moveDistance;
                darkRoomManager.GetComponent<DarkRoomPhotos>().selectedPhoto[darkRoomManager.GetComponent<DarkRoomPhotos>().selectedAmt] = gameObject;
                darkRoomManager.GetComponent<DarkRoomPhotos>().selectedAmt++;
            }
            else
            {
                gameObject.transform.position += Vector3.forward * (-moveDistance);
                darkRoomManager.GetComponent<DarkRoomPhotos>().selectedAmt--;
            }
        }
    }    
}
