using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField] private bool lockX;
    [SerializeField] private bool lockY;
    [SerializeField] private bool lockZ;
    public GameObject Playerwcam1;
    private Vector3 originalRotation;

    void LateUpdate()
    {
        transform.LookAt(Playerwcam1.transform.position);

 
    }
}
