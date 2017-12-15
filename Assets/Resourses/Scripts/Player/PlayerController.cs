using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public InputBinds binds;
    public InterfaceScript interfaceScript;

    public float moveSpeed = 0.01f;
    public float sitMoveSpeed = 0.01f;
    public float runMoveSpeed = 0.01f;

    public float animationCrossLag = 1;
    bool rightRotate = true;

    public int STATE = 0;
    int ANIMATION_STATE = 0;
    public const int STATE_WALK = 1;
    public const int STATE_RUN = 2;
    public const int STATE_WALK_SITTING = 3;
    public const int STATE_SITTING = 4;
    public const int STATE_IDLE = 5;

    public const int MOVE = 1;
    public const int STAY = 0;


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
<<<<<<< HEAD

        rigibody.MovePosition(transform.position + new Vector3(x, y, z));
=======
       Rigidbody r = GetComponent<Rigidbody>();
        r.MovePosition(transform.position + new Vector3(x, y, z));
>>>>>>> 0fa157d8fd09eb865e88e2dfd5a596b73e5450ec
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
    }

    int moveX, moveY;

    public void moveController()
    {
        isMoving = false;
        setState(STATE_IDLE);
        moveX = 0; moveY = 0;

        if (checkPress(binds.sitDown))
        {
            setState(STATE_SITTING);
        }
        else if(Input.GetKeyUp(binds.sitDown))
        {
            
        }

        if (checkPress(binds.moveUp))
        {
            setState(STATE_WALK);
            moveY = 1;
        }
        else if (checkPress(binds.moveDown))
        {
            setState(STATE_WALK);
            moveY = -1;
        }

        if (checkPress(binds.moveRight))
        {
            setState(STATE_WALK);
            moveX = 1;
        }
        else if (checkPress(binds.moveLeft))
        {
            setState(STATE_WALK);
            moveX = -1;
        }

        walkController(moveX, moveY);

        if(ANIMATION_STATE != STATE)
            checkAnimation();
    }

    public void setState(int state)
    {
        if (state == STATE_WALK && (STATE == STATE_SITTING || STATE == STATE_WALK_SITTING))
            STATE = STATE_WALK_SITTING;
        else
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
                GetComponent<Animator>().CrossFade("PLAYER_CROUCHING", animationCrossLag);
            }
            else if(isMoving&&isState(STATE_WALK_SITTING))
            {
                GetComponent<Animator>().CrossFade("PLAYER_CROUCHING_WALK", animationCrossLag);
            }
            else if (isState(STATE_IDLE))
                GetComponent<Animator>().CrossFade("idle", animationCrossLag);
            ANIMATION_STATE = STATE;
    }
 

}
