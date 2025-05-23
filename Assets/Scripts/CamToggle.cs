using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamToggle : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private GameObject camera_third;
    [SerializeField] private GameObject camera_first;
    private float verticalLookRotation;
    bool isActive = true;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isActive=!isActive;
            camera_third.SetActive(isActive);
            camera_first.SetActive(!isActive);  
        }

        Look();
    }
    
    private void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        
    }
}
