﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public InterfaceScript interfaceScript;

    public float moveSpeed = 0.01f;
    public float currentSpeed = 0;
    public float animationCrossLag = 1;

    Vector3 destination;
    Vector3 moveWay;


    Animator plA;
    Vector3 position = new Vector3();
    bool movingState = false;
    bool rightWay = true;
    bool isMoving = false;

	// Use this for initialization
	void Start () {
        plA = GetComponent<Animator>();
    
      
    }

    // Update is called once per frame
    void Update() {

        if (interfaceScript != null)
            if (!interfaceScript.getShow())
                move();
            else { }
        else move();
    }

    public void move()
    {

        movingState = false;
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
            movingState = true;
            if (!rightWay)
            {
                rightWay = true;
                transform.localScale = new Vector3(transform.lossyScale.x * -1, transform.lossyScale.y, transform.lossyScale.z);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
            movingState = true;
            if (rightWay)
            {
                rightWay = false;
                transform.localScale = new Vector3(transform.lossyScale.x * -1, transform.lossyScale.y, transform.lossyScale.z);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed);
            movingState = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed);
            movingState = true;
        }

        setMovingState(movingState);
    }


    public void setMovingState(bool move)
    {
        if (move && !isMoving)
        {
            GetComponent<Animator>().CrossFade("walk", animationCrossLag);
            isMoving = true;
        }
        else if(!move)
        {
            isMoving = false;
            GetComponent<Animator>().CrossFade("idle", animationCrossLag);
        }
            
    }
 

}
