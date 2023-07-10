using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState =CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Time.deltaTime * sensitivity * Input.GetAxis("Mouse X");
        float mouseY = Time.deltaTime *sensitivity *Input.GetAxis("Mouse Y");
        
        xRotation-=mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);
        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
    }
}
