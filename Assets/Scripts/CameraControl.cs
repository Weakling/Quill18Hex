using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float currentRotationX;
    public float currentRotationY;
    private bool rotationOn;
    private float rotationSpeed;
    public float moveSpeed;
    public float moveVelocityX, moveVelocityY, moveVelocityZ;
    public Rigidbody myRigidBody;

	// Use this for initialization
	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody>();
        rotationSpeed = .75f;
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
        // up
        if(Input.GetKey(KeyCode.E))
        {
            if(rotationOn)
            {
                currentRotationX = currentRotationX - rotationSpeed;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
            }
            else
            {
                moveVelocityY = moveSpeed;
            }
        }
        // down
        else if(Input.GetKey(KeyCode.Q))
        {
            if (rotationOn)
            {
                currentRotationX = currentRotationX + rotationSpeed;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
            }
            else
            {
                moveVelocityY = -moveSpeed;
            }
        }
        // kill y velocity when not using it
        else
        {
            moveVelocityY = 0;
        }
        // velocity sets
        moveVelocityX = Input.GetAxisRaw("Horizontal");
        moveVelocityZ = Input.GetAxisRaw("Vertical");
        if (rotationOn)
        {
            //Vector3 v3 = new Vector3 (moveVelocityX, 0f, 0f);
            //this.transform.Rotate(v3, moveSpeed * Time.deltaTime);
            if(moveVelocityX > 0)
            {
                currentRotationY = currentRotationY + rotationSpeed;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
            }
            else if(moveVelocityX < 0)
            {
                currentRotationY = currentRotationY - rotationSpeed;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
            }

        }
        else
        
        
        myRigidBody.velocity = new Vector3(moveVelocityX * moveSpeed, moveVelocityY, moveVelocityZ * moveSpeed);
        #endregion

        // 
        #region
        
        #endregion
    }
}
