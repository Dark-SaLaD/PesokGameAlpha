using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;

    private float minAngle = -60;
    private float maxAngle = 40;
    public int CameraRotationSpeed;

    void Start() {
        //cursor lock
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        //rotate left-riht
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * CameraRotationSpeed * Input.GetAxis("Mouse X"), 0);

        //rotate top-down
        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * CameraRotationSpeed * Input.GetAxis("Mouse Y");
        if(newAngleX > 180) {
            newAngleX -= 360;
        }
        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
