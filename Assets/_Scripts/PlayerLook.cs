using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    
    public void RotateX(float lookSpeed) {
        
        float xRot = -Input.GetAxisRaw("Mouse Y");

        Vector3 rotation = new Vector3(xRot, 0, 0);
        
        transform.Rotate(rotation * lookSpeed);

        Vector3 clamped = transform.rotation.eulerAngles;
        clamped.z = 0;
        clamped.y = 0;
        transform.localRotation = Quaternion.Euler(clamped);

    }
    
}
