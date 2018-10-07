using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMotor : MonoBehaviour {


    private Vector3 velocity;

    [Range(0, 10)]
    public float maxZ, maxX;
    
    public void Move(float acceleration) {
        
        //forward/back
        if (Input.GetKey(KeyCode.W)) {
            velocity.z = Mathf.Clamp(velocity.z + acceleration, -maxZ, maxZ);
        } else if (Input.GetKey(KeyCode.S)) {
            velocity.z = Mathf.Clamp(velocity.z - acceleration, -maxZ, maxZ);
        } else {
            Vector3 lerpTarget = velocity;
            lerpTarget.z = 0;
            velocity = Vector3.Lerp(velocity, lerpTarget, acceleration);
        }
        
        Debug.Log("Forward Velocity is: " + velocity.z);
        
        //left/right
        if (Input.GetKey(KeyCode.D)) {
            velocity.x = Mathf.Clamp(velocity.x + acceleration, -maxX, maxX);
        } else if (Input.GetKey(KeyCode.A)) {
            velocity.x = Mathf.Clamp(velocity.x - acceleration, -maxX, maxX);
        } else {
            Vector3 lerpTarget = velocity;
            lerpTarget.x = 0;
            velocity = Vector3.Lerp(velocity, lerpTarget, acceleration);
        }
        
        transform.Translate(velocity * Time.deltaTime);

    }
    
    public void RotateY(float lookSpeed) {
        
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0);
        
        transform.Rotate(rotation * lookSpeed);

        Vector3 clamped = transform.rotation.eulerAngles;
        clamped.z = 0;
        clamped.x = 0;
        transform.rotation = Quaternion.Euler(clamped);

    }

    
    
}