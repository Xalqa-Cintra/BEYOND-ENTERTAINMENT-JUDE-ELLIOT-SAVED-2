  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    float maxSpeed;
    float normalSpeed = 10.0f;
    float sprintSpeed = 14.0f;
    float rotation = 0.0f;
    float camRotation = 0.0f;
    float xRotation;
    float sensY;
    public GameObject cam;
    Rigidbody rb;
    public GameObject cameraManager, gameManager, nextArea;
    float rotationSpeed = 2.0f;
    float camRoatationSpeed = -1.5f;
    public bool isOnGround, canTP;
    public GameObject groundChecker;
    public LayerMask groudLayer;
    public float jumpForce = 300.0f;
    public float maxSprint = 10.0f, gravity;
    float sprintTimer;
    public int added;
    public float distToGround = 1f;
    public Text Grounded;
    public AudioSource footsteps;

    public Transform darkroomTP, bunkerTP, mapTP, bunkerMapTP, warTP, warMapTP, AirStripTP, airStripMapTP;
    public int teleports;


    void Start()
    {
        gameManager = GameObject.Find("gamemanager");
        gameManager.GetComponent<GameManager>().MoveScene();
        gameManager.GetComponent<GameManager>().FirstLoad();
        sprintTimer = maxSprint;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.5f, groudLayer);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);
        }

        rb.AddForce(transform.up * (gravity * -1), ForceMode.Force);

        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        }
        else
        {
            maxSpeed = normalSpeed;
            if(Input.GetKey(KeyCode.LeftShift) == false && sprintTimer < maxSprint)
            {
                sprintTimer = sprintTimer + Time.deltaTime;
            }
        }

        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        xRotation += mouseY;

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        rb.velocity = new Vector3(newVelocity.x, rb.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRoatationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

        camRotation = Mathf.Clamp(camRotation, -80f, 80f);

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) { footsteps.Play();} else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) { footsteps.Pause(); }
        
        if (Input.GetMouseButtonDown(1))
        {
            cameraManager.GetComponent<PhotoCapture>().canTakePhoto = !cameraManager.GetComponent<PhotoCapture>().canTakePhoto;
        }
        if(canTP) { nextArea.SetActive(true); } else { nextArea.SetActive(false); }
        if(Input.GetMouseButtonDown(0) && cameraManager.GetComponent<PhotoCapture>().canTakePhoto == false && canTP)
        {
            CheckTeleports();
        }
    }

    public void CheckTeleports()
    {
        switch (teleports)
        {
            case 1:
                transform.position = darkroomTP.position;// set tps to a value;
                break;
            case 2:
                transform.position = bunkerTP.position;
                break;
            case 3:
                cameraManager.GetComponent<PhotoCapture>().photoLimit = 3;
                cameraManager.GetComponent<PhotoCapture>().SetMaxLimit();
                transform.position = mapTP.position;
                break;
            case 4:
                transform.position = bunkerMapTP.position;
                break;
            case 5:
                transform.position = warTP.position;
                break;
            case 6:
                transform.position = warMapTP.position;
                break;
            case 7:
                transform.position = airStripMapTP.position;
                break;
            case 8:
                transform.position = AirStripTP.position;
                break;

        }
        teleports = 0;
        canTP = false;
    }
    public void OnTriggerExit(Collider other)
    {
        canTP = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Camera Pickup")
        {
            cameraManager.GetComponent<PhotoCapture>().photoLimit += added;
            cameraManager.GetComponent<PhotoCapture>().SetMaxLimit();
            cameraManager.GetComponent<PhotoCapture>().photoTaken = 0;
            Destroy(other.gameObject);
        }
        if (other.tag == "DarkroomTP")
        {
            canTP = true;
            teleports = 1;
        }
        if (other.tag == "BunkerTP")
        {
            canTP = true;
            teleports = 2;
        }
        if (other.tag == "MapTP")
        {
            canTP = true;
            teleports = 3;
        }
        if (other.tag == "BunkerMapTP")
        {
            canTP = true;
            teleports = 4;
        }
        if (other.tag == "WarTP")
        {
            canTP = true;
            teleports = 5;
        }
        if (other.tag == "WarMapTP")
        {
            canTP = true;
            teleports = 6;
        }
        if (other.tag == "AirStripMapTP")
        {
            canTP = true;
            teleports = 7;
        }
        if (other.tag == "AirStripTP")
        {
            canTP = true;
            teleports = 8;
        }
    }
}
