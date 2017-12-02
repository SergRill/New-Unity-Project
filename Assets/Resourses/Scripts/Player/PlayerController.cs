using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public InputBinds binds;
    public InterfaceScript interfaceScript;

    public float moveSpeed = 0.01f;
    public float animationCrossLag = 1;
    bool rightRotate = true;

    public int STATE = 0;
    int ANIMATION_STATE = 0;
    public const int STATE_WALK = 1;
    public const int STATE_RUN = 2;
    public const int STATE_WALK_SITTING = 3;
    public const int STATE_SITTING = 4;
    public const int STATE_IDLE = 5;

    Animator playerAnimator;

    bool isMoving = false;

	// Use this for initialization
	void Start () {
        playerAnimator = GetComponent<Animator>();
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
        transform.position = new Vector3(transform.position.x + x, transform.position.y  + y, transform.position.z + z);
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

    public void moveController()
    {
        isMoving = false;
        setState(STATE_IDLE);

        if (checkPress(binds.sitDown))
        {
            setState(STATE_SITTING);
        }

        if (checkPress(binds.moveUp))
        {
            move(0, 0, moveSpeed);
            setState(STATE_WALK);
        }
        else if (checkPress(binds.moveDown))
        {
            move(0, 0, -moveSpeed);
            setState(STATE_WALK);
        }

        if (checkPress(binds.moveRight))
        {
            move(moveSpeed, 0, 0);
            setState(STATE_WALK);
            checkRotate(moveSpeed);
        }
        else if (checkPress(binds.moveLeft))
        {
            move(-moveSpeed, 0, 0);
            setState(STATE_WALK);
            checkRotate(-moveSpeed);
        }

        if(ANIMATION_STATE != STATE)
            checkAnimation();
    }

    public void setState(int state)
    {
        STATE = state;
    }

    public bool isState(int s)
    {
        if (STATE == s)
            return true;
        else return false;
    }

    public void checkAnimation()
    {
            if (isMoving && isState(STATE_WALK))
            {
                GetComponent<Animator>().CrossFade("walk", animationCrossLag);
            }
            else if (isState(STATE_SITTING))
            {
                GetComponent<Animator>().CrossFade("sitting", animationCrossLag);
            }
            else if (isState(STATE_IDLE))
                GetComponent<Animator>().CrossFade("idle", animationCrossLag);
        ANIMATION_STATE = STATE;
    }
 

}
