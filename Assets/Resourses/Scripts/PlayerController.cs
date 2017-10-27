using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 0.01f;
    public float currentSpeed = 0;
    public float acceleration = 0.001f;
    public float animationCrossLag = 1;

    Vector3 destination;
    Vector3 moveWay;


    Animator plA;
    Vector3 position = new Vector3();
    bool movingState = false;

	// Use this for initialization
	void Start () {
        plA = GetComponent<Animator>();
        position.Set(transform.position.x, transform.position.y, transform.position.z);
        transform.position = position;
        destination.Set(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0))
        {

            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination = new Vector3(destination.x, destination.y, 0);
            moveWay = new Vector3(transform.position.x - destination.x, transform.position.y - destination.y, 0);
            print(moveWay);
            setMovingStateTrue();
            if (transform.position.x > destination.x)
                transform.localScale = new Vector3(transform.lossyScale.x * -1, transform.lossyScale.y, transform.lossyScale.z);
            else if(transform.localScale.x < 0 && transform.position.x < destination.x)
                transform.localScale = new Vector3(transform.lossyScale.x * -1, transform.lossyScale.y, transform.lossyScale.z);
        }

        if (!Vector3.Distance(transform.position, destination).Equals(0))
        {
            moveWay = new Vector3(transform.position.x - destination.x, transform.position.y - destination.y, 0) / Vector3.Distance(transform.position, destination) * currentSpeed;
            transform.position = transform.position + moveWay * -0.01f;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            speed();

            

            if (Vector3.Distance(transform.position, destination) < 0.1f)
            {
                transform.position = new Vector3(destination.x, destination.y, destination.z);
                currentSpeed = 0;
            }
           
        }
        else
            setMovingStateFalse();
    }

    public void speed()
    {
        if (currentSpeed <= moveSpeed)
            currentSpeed += acceleration;
    }

    public void setMovingStateTrue()
    {
            GetComponent<Animator>().CrossFade("walk", animationCrossLag);
    }
    public void setMovingStateFalse()
    {
            GetComponent<Animator>().CrossFade("idle", animationCrossLag);
    }

}
