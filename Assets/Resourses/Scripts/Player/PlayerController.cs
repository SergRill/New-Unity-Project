using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Inventory inventory;

    public float moveSpeed = 0.01f;
    public float currentSpeed = 0;
    public float animationCrossLag = 1;

    Vector3 destination;
    Vector3 moveWay;


    Animator plA;
    Vector3 position = new Vector3();
    bool movingState = false;
    bool rightWay = true;

	// Use this for initialization
	void Start () {
        plA = GetComponent<Animator>();
    
      
    }

    // Update is called once per frame
    void Update() {

        if(!inventory.show)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
                setMovingState(true);
                if (!rightWay)
                {
                    rightWay = true;
                    transform.localScale = new Vector3(transform.lossyScale.x * -1, transform.lossyScale.y, transform.lossyScale.z);
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
                setMovingState(true);
                if (rightWay)
                {
                    rightWay = false;
                    transform.localScale = new Vector3(transform.lossyScale.x * -1, transform.lossyScale.y, transform.lossyScale.z);
                }
            }
            else setMovingState(false);
        }
    }


    public void setMovingState(bool move)
    {
        if (move && !movingState)
        {
            movingState = true;
            GetComponent<Animator>().CrossFade("walk", animationCrossLag);
        }
        else if (!move && movingState)
        {
            movingState = false;
            GetComponent<Animator>().CrossFade("idle", animationCrossLag);
        }
    }
 

}
