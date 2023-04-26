using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform character;
    public Transform camera;
    public Rigidbody grabbedObject;
    public bool isGrabbing;
    Control controlScript;
    public float range;
    public float lerp;
    void Start()
    {
        if(transform.GetComponent<Control>() != null)
            controlScript = transform.GetComponent<Control>();
        if(controlScript != null)
            camera = controlScript.camera;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isGrabbing == false)
            {
                RaycastHit hit;
                Debug.Log("Attempting Grab");
                if(Physics.Raycast(camera.position,camera.forward,out hit,range))
                {
                    Debug.Log("Raycasting");
                    if(hit.rigidbody != null && hit.rigidbody.isKinematic == false)
                    {
                        Debug.Log("Found Object: " + hit.rigidbody);
                        grabbedObject = hit.rigidbody;
                        isGrabbing = true;
                    }
                }
            }
            else
            {
                isGrabbing = false;
                grabbedObject.useGravity = true;
                grabbedObject.angularVelocity = new Vector3(Random.Range(-1,1),Random.Range(-1,1),Random.Range(-1,1));
                grabbedObject = null;
            }
        }

        if(isGrabbing == true)
        {
            grabbedObject.useGravity = false;
            grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position,camera.position+character.forward+camera.forward,lerp);
            grabbedObject.transform.forward = Vector3.Slerp(grabbedObject.transform.forward,camera.forward,lerp);
            grabbedObject.velocity = Vector3.Lerp(grabbedObject.velocity,Vector3.zero,0.2f);
            grabbedObject.angularVelocity = Vector3.Lerp(grabbedObject.angularVelocity,Vector3.zero,0.2f);
        }
    }
}
