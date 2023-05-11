using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float turnSpeed;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        float zAxis = Input.GetAxis("VerticalZ");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(0,mouseX*turnSpeed*Time.deltaTime,0),Space.World);
        transform.Rotate(new Vector3(-mouseY*turnSpeed*Time.deltaTime,0,0),Space.Self);
        transform.position += (transform.forward * yAxis * moveSpeed) + (transform.right * xAxis * moveSpeed) + (transform.up * zAxis * moveSpeed);
    }
}
