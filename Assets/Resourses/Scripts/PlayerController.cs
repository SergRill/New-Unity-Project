using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 0.01f;
    public float currentSpeed = 0;
    public float acceleration = 0.001f;
    public float animationCrossLag = 1;


    Animator plA;
    Vector3 position = new Vector3();
    bool movingState = false;

	// Use this for initialization
	void Start () {
        plA = GetComponent<Animator>();
        position.Set(transform.position.x, transform.position.y, transform.position.z);
        transform.position = position;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.D))
        {
            setMovingStateTrue();
            setSpeed(true, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            setMovingStateTrue();
            setSpeed(true, -1);
        }
        else
            setMovingStateFalse();
    }

    public void setSpeed(bool accel, int mod)
    {

        if (accel)
            if (Mathf.Abs(currentSpeed) < moveSpeed) currentSpeed += acceleration * mod;
            else { }
        else if (currentSpeed != 0)
            if (Mathf.Abs(currentSpeed) <= acceleration) currentSpeed = 0;
            else if(currentSpeed > 0) currentSpeed -= acceleration;
            else currentSpeed += acceleration;
        position.x += currentSpeed;
        transform.position = position;
    }

    public void setMovingStateTrue()
    {
        if (!movingState)
        {
            GetComponent<Animator>().CrossFade("walk", animationCrossLag);
            movingState = true;
        }   
    }
    public void setMovingStateFalse()
    {
        if (movingState)
        {
            GetComponent<Animator>().CrossFade("idle", animationCrossLag);
            movingState = false;
        }
        setSpeed(false, 1);
    }

}
