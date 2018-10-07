using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerController : MonoBehaviour {
    
    [Range(0, 1)]
    private float acceleration = 1;
    [Range(0, 1)] 
    public float lookSpeed;
    
    private PlayerMotor motor;
    private PlayerLook looker;
    
    private void Start() {

        Cursor.lockState = CursorLockMode.Locked;
        
        motor = GetComponent<PlayerMotor>();
        looker = GetComponentInChildren<PlayerLook>();

    }

    private void Update() {
        
        motor.Move(acceleration);
        motor.RotateY(lookSpeed);
        looker.RotateX(lookSpeed);
        
    }
}
