using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Socket
{
    public enum SocketType {CPU,PCIE,USB};
    public SocketType socketType;
    public Vector3 offset;
}

public class SocketClass : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
