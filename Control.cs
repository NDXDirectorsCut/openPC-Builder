using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameStateManager gsm;
    public Transform character;
    public Transform camera;
    CharacterController charControl;
    public float cameraSpeed;
    public float movementSpeed;
    public float cameraYClamp;
    // Start is called before the first frame update
    void Start()
    {
        character = transform.Find("Character");
        charControl = character.GetComponent<CharacterController>();
        camera = character.Find("Camera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");
        Vector3 axisInput = character.TransformDirection(new Vector3(axisX,0,axisY));
        charControl.Move(axisInput*movementSpeed*Time.deltaTime);
        charControl.Move(-transform.up*10*Time.deltaTime);
        character.Rotate(new Vector3(0,mouseX*cameraSpeed*Time.deltaTime,0),Space.Self);
        //camera.eulerAngles = new Vector3(Mathf.Clamp(camera.eulerAngles.x,-45,45),camera.eulerAngles.y,camera.eulerAngles.z);
        camera.Rotate(new Vector3(-mouseY*cameraSpeed*Time.deltaTime,0,0),Space.Self);

    }
}
