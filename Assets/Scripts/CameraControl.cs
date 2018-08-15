using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// moves camera in 3D scenes

public class CameraControl : MonoBehaviour {

    private float currentRotationX, currentRotationY;
    public float rotationSpeedVertical, rotationSpeedHorizontal;
    public float moveSpeed;
    private float moveVelocityX, moveVelocityZ;
    public Transform leftTarget, rightTarget, forwardTarget, backwardTarget, downTarget, upTarget, myCamera;


    // Use this for initialization
    void Start ()
    {
        myCamera = transform.GetChild(0);
        //leftTarget = transform.GetChild(1);
        //rightTarget = transform.GetChild(2);
        //forwardTarget = transform.GetChild(3);
        //backwardTarget = transform.GetChild(4);
        //downTarget = transform.GetChild(5);
        //upTarget = transform.GetChild(6);

        currentRotationX = 14;
        currentRotationY = 0;
        rotationSpeedHorizontal = 1.1f;
        rotationSpeedVertical = .90f;
	}
	
	void Update ()
    {
        // velocity sets
        moveVelocityX = Input.GetAxisRaw("Horizontal");
        moveVelocityZ = Input.GetAxisRaw("Vertical");

        // que movement
        CameraMove();
    }

    void CameraMove()
    {
        // rotate left..
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)))
        {
            currentRotationY = currentRotationY - rotationSpeedHorizontal;
            myCamera.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
        }

        // rotate up..
        else if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)))
        {
            currentRotationX = currentRotationX + rotationSpeedVertical;
            myCamera.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
        }
        // rotate right..
        else if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)))
        {
            currentRotationY = currentRotationY + rotationSpeedHorizontal;
            myCamera.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
        }
        // rotate down..
        else if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)))
        {
            currentRotationX = currentRotationX - rotationSpeedVertical;
            myCamera.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
        }

        // vertical movement
        // up
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.position = Vector3.MoveTowards(transform.position, upTarget.position, moveSpeed * Time.deltaTime);
        }
        // down
        else if (Input.GetKey(KeyCode.Q))
        {
            this.transform.position = Vector3.MoveTowards(transform.position, downTarget.position, moveSpeed * Time.deltaTime);
        }

        // horizontal movement
        // moving right..
        if (moveVelocityX > 0)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, rightTarget.position, moveSpeed * Time.deltaTime);
        }
        // moving left..
        else if (moveVelocityX < 0)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, leftTarget.position, moveSpeed * Time.deltaTime);
        }
        // moving forward..
        if(moveVelocityZ > 0)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, forwardTarget.position, moveSpeed * Time.deltaTime);
        }
        // moving backward..
        else if (moveVelocityZ < 0)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, backwardTarget.position, moveSpeed * Time.deltaTime);
        }

        //Vector3 v3 = new Vector3 (moveVelocityX, 0f, 0f);
        //this.transform.Rotate(v3, moveSpeed * Time.deltaTime);
    }
}
