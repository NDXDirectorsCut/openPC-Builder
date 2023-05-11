using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript2 : MonoBehaviour
{
    public Transform selectedPart;
    public Socket partSocket;
    Camera cam;
    RaycastHit hit;
    RaycastHit hit2;
    public LayerMask layers;
    public Vector2 holdOffset;

    void Start()
    {
        cam = transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Ray rayOrigin = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(rayOrigin,out hit))
        {
            if(Input.GetButtonDown("Fire1"))
            {
                //Debug.Log(hit.transform);
                Debug.Log("Selecting Object");
                if(hit.transform.gameObject.tag == "Part")
                {
                    selectedPart = hit.transform;
                    Debug.Log("Selected Part");
                }
                if(hit.transform.gameObject.tag == "Socket" && selectedPart != null)
                {
                    Debug.Log("Selected Socket");
                    //partSocket = selectedPart Socket; conSocket = Socket you're connecting to
                    //This is fucking ass behavior, gonna redo everything later;
                    Socket conSocket = hit.transform.gameObject.GetComponent<TestScript>().socketObject;
                    if(partSocket.socketType == conSocket.socketType)
                    {
                        Debug.Log("AAAAAAAA");
                        selectedPart.position = hit.transform.position + conSocket.offset;
                        selectedPart.up = hit.transform.up;
                        selectedPart = null;
                    }
                }
            }
        }
        if(selectedPart != null)
        {
            partSocket = selectedPart.gameObject.GetComponent<TestScript>().socketObject;
            Vector3 holdPos = transform.position + transform.forward * holdOffset.x + transform.up * holdOffset.y;
            if(Physics.Raycast(transform.position + transform.up * holdOffset.y,transform.forward, out hit2,holdOffset.x*1.5f,layers) )
            {
                if(Vector3.Distance(transform.position + transform.up * holdOffset.y,hit2.point)>holdOffset.x)
                {
                    selectedPart.forward = Vector3.Slerp(selectedPart.forward,hit2.normal,.25f);
                    selectedPart.position = holdPos;
                }
                else
                {
                    selectedPart.forward = Vector3.Slerp(selectedPart.forward,hit2.normal,.6f);
                    selectedPart.position = hit2.point+selectedPart.forward*.05f;
                }
            }
            else
            {
                selectedPart.forward = Vector3.Slerp(selectedPart.forward,-transform.forward,.6f);
                selectedPart.position = Vector3.Lerp(selectedPart.position,holdPos,.8f);
            }
        }
    }
}
