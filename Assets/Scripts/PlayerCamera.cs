using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float cameraSensitivity = 5f;
    [SerializeField] Transform playerBody;
    UIManager um;
    float xRot = 0;

    void Awake()
    {
        um = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    void Start()
    {

    }

    void Update()
    {
        LookandRotate();
    }

    void LookandRotate()
    {
        if(!um.Toggle)
        {
            float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90, 90);
        
            transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

}
