using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    public GameObject darkroomManager;
    public Transform rotatePoint;

    public float rotateAmount;
    public bool stop;

    private void Update()
    {

 
            if (darkroomManager.GetComponent<DarkRoomPhotos>().currentPhoto > 2 && stop == false)
            {
                DoorRotate();
            }
    }

    private void DoorRotate()
    {
        transform.RotateAround(rotatePoint.position, Vector3.up, rotateAmount);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bunkerLimit")
        {
            stop = true;
        }
    }

}
