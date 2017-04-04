using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private float currentRotationX, currentRotationY;
    private float rotationSpeed;
    public float moveSpeed;
    private float moveVelocityX, moveVelocityZ;
    public Transform leftTarget, rightTarget, forwardTarget, backwardTarget, downTarget, upTarget, myCamera;


    // Use this for initialization
    void Start ()
    {
        myCamera = transform.GetChild(0);
        leftTarget = transform.GetChild(1);
        rightTarget = transform.GetChild(2);
        forwardTarget = transform.GetChild(3);
        backwardTarget = transform.GetChild(4);
        downTarget = transform.GetChild(5);
        upTarget = transform.GetChild(6);

        currentRotationX = 14;
        currentRotationY = 0;
        rotationSpeed = .75f;
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentRotationY = currentRotationY - rotationSpeed;
            myCamera.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
        }
        // rotate up..
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            currentRotationX = currentRotationX + rotationSpeed;
            myCamera.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
        }
        // rotate right..
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            currentRotationY = currentRotationY + rotationSpeed;
            myCamera.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
        }
        // rotate down..
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currentRotationX = currentRotationX - rotationSpeed;
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
