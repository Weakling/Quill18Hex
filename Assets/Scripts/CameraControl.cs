using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float currentRotation;
    private bool rotationOn;
    public float moveSpeed;
    public float moveVelocityX, moveVelocityY, moveVelocityZ;
    public Rigidbody myRigidBody;

	// Use this for initialization
	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody>();	
	}
	
	void Update ()
    {
        // movement and rotation
        #region
        // rotation bool
        if(Input.GetKey(KeyCode.Space))
        {
            rotationOn = true;
        }
        else
        {
            rotationOn = false;
        }
        // velocity sets
        moveVelocityX = Input.GetAxisRaw("Horizontal");
        moveVelocityZ = Input.GetAxisRaw("Vertical");
        if(Input.GetKey(KeyCode.E))
        {
            if(rotationOn)
            {
                currentRotation = currentRotation - 0.5f;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotation, this.transform.rotation.y);
            }
            else
            {
                moveVelocityY = moveSpeed;
            }
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            if (rotationOn)
            {
                currentRotation = currentRotation + 0.5f;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotation, this.transform.rotation.y);
            }
            else
            {
                moveVelocityY = -moveSpeed;
            }
        }
        else
        {
            moveVelocityY = 0;
        }
        myRigidBody.velocity = new Vector3(moveVelocityX * moveSpeed, moveVelocityY, moveVelocityZ * moveSpeed);
        #endregion

        // 
        #region
        
        #endregion
    }
}
