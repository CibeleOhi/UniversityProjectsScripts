using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLook : MonoBehaviour {
   
    public Transform playerObject;
    public float mouseSensitivity;
    float xAxisAntiFlick=0.0f;
    public Toggle invertMouse;
    public Slider changeSensitivity;
   


    public void Update()
    {
        CameraRotation();
    }


    public void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotationIntensityX = mouseX * mouseSensitivity;
        float rotationIntensityY = mouseY * mouseSensitivity;

        Vector3 CamRotation = transform.rotation.eulerAngles;
        Vector3 PlayerRotation = playerObject.rotation.eulerAngles;
  
        CamRotation.x -= rotationIntensityY;
        CamRotation.z = 0;
        PlayerRotation.y += rotationIntensityX;
        xAxisAntiFlick -= rotationIntensityY;

        if (xAxisAntiFlick > 90)
        {
            xAxisAntiFlick = 90;
            CamRotation.x = 90;
        }

        else if (xAxisAntiFlick < -90)
        {
            xAxisAntiFlick = -90;
            CamRotation.x = 270;

        }

        transform.rotation = Quaternion.Euler(CamRotation);
        playerObject.rotation = Quaternion.Euler(PlayerRotation);

    }

    public void InvertMouse()
    {
        mouseSensitivity = mouseSensitivity * -1;
        Update();
    }

    public void ChangeSensitivity(float levelIntensity)
    {
        mouseSensitivity = +levelIntensity;
        if (invertMouse.isOn == true)
        {
            mouseSensitivity = mouseSensitivity * -1;
        }
    }
}
