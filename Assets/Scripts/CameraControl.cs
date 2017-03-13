using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private float currentRotationX, currentRotationY;
    private bool rotationOn;
    private float rotationSpeed;
    public float moveSpeed;
    private float moveVelocityX, moveVelocityZ;
    public Transform leftTarget, rightTarget, forwardTarget, backwardTarget, downTarget, upTarget;


	// Use this for initialization
	void Start ()
    {
        leftTarget = transform.GetChild(0);
        rightTarget = transform.GetChild(1);
        forwardTarget = transform.GetChild(2);
        backwardTarget = transform.GetChild(3);
        downTarget = transform.GetChild(4);
        upTarget = transform.GetChild(5);

        currentRotationX = 14;
        currentRotationY = 0;
        rotationSpeed = .75f;
	}
	
	void Update ()
    {
        // check rotation
        if (Input.GetKey(KeyCode.Space))
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

        // que movement
        CameraMove();
    }

    void CameraMove()
    {
        // vertical move
        // up
        if (Input.GetKey(KeyCode.E))
        {
            if (rotationOn)
            {
                currentRotationX = currentRotationX - rotationSpeed;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(transform.position, upTarget.position, moveSpeed * Time.deltaTime);
            }
        }
        // down
        else if (Input.GetKey(KeyCode.Q))
        {
            if (rotationOn)
            {
                currentRotationX = currentRotationX + rotationSpeed;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(transform.position, downTarget.position, moveSpeed * Time.deltaTime);
            }
        }
        // horizontal
        // moving right..
        if (moveVelocityX > 0)
        {
            if(rotationOn)
            {
                currentRotationY = currentRotationY + rotationSpeed;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(transform.position, rightTarget.position, moveSpeed * Time.deltaTime);
            }
        }
        // moving left..
        else if (moveVelocityX < 0)
        {
            if(rotationOn)
            {
                currentRotationY = currentRotationY - rotationSpeed;
                this.gameObject.transform.eulerAngles = new Vector3(currentRotationX, currentRotationY);
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(transform.position, leftTarget.position, moveSpeed * Time.deltaTime);
            }
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

    void CameraRotate()
    {

    }
}
