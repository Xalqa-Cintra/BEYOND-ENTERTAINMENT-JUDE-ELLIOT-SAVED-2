using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable { 
    public void Interact();
}
public class InteractScript : MonoBehaviour
{
    public Transform interactorSource;
    public float interactorRange;
    public GameObject cursor;

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactorRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))   
            {
                cursor.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    interactObj.Interact();
                }
            } else { cursor.SetActive(false); }
        }
    }
}
