using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public InputBinds binds;
    public StateController stateController;

    // Use this for initialization
    void Start () {
        stateController.setGameObject(gameObject);
	}

   
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(binds.sitDown))
            stateController.setState("sitDown");
        else if (stateController.setState("stand"));

        if (Input.GetKey(binds.moveRight))
            stateController.setXMove(1);
        else if (Input.GetKey(binds.moveLeft))
            stateController.setXMove(-1);

<<<<<<< HEAD
        if (Input.GetKey(binds.moveUp))
            stateController.setYMove(1);
        else if (Input.GetKey(binds.moveDown))
            stateController.setYMove(-1);
=======

    Animator playerAnimator;
    Rigidbody rigibody;

    bool isMoving = false;

    public bool isSittingState = false;
    public bool isSitPositionSet = false;

    public float sitChange = 1f;

	// Use this for initialization
	void Start () {
        playerAnimator = GetComponent<Animator>();
        rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (interfaceScript != null)
            if (interfaceScript.getShow() == false)
                moveController(); else;
        else moveController();
     }

    public bool checkPress(KeyCode c)
    {
        if (Input.GetKey(c))
            return true;
        else return false;
    }

    public void move(float x, float y, float z)
    {

        rigibody.MovePosition(transform.position + new Vector3(x, y, z));
       Rigidbody r = GetComponent<Rigidbody>();
        r.MovePosition(transform.position + new Vector3(x, y, z));

        rigibody.MovePosition(transform.position + new Vector3(x, y, z));
        r.MovePosition(transform.position + new Vector3(x, y, z));
      //  transform.position = new Vector3(transform.position.x + x, transform.position.y  + y, transform.position.z + z);
        isMoving = true;
    }

    public void checkRotate(float s)
    {
        if (s > 0 && rightRotate == false)
        {
            rightRotate = true;
            transform.localScale = new Vector3(transform.lossyScale.x * -1, transform.lossyScale.y, transform.lossyScale.z);
        }
        else if(s < 0 && rightRotate == true)
        {
            rightRotate = false ;
            transform.localScale = new Vector3(transform.lossyScale.x * -1, transform.lossyScale.y, transform.lossyScale.z);
        }
    }

    void walkController(float x, float z)
    {
        if (STATE == STATE_SITTING || STATE == STATE_WALK_SITTING)
        {
            move(sitMoveSpeed * x, 0, z * sitMoveSpeed);
            checkRotate(sitMoveSpeed * x); 
        }
        else
        {
            move(moveSpeed * x, 0, z * moveSpeed);
            checkRotate(x * moveSpeed);
        }
>>>>>>> e17e4dd8fd5fb2d34589163e0bce82c45fa5d86a
    }
}
