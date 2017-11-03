using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera controllerCamera;

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
    
      
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = Physics.raycasy
            
            if (hit.collider != null)
            {

                float distance = Mathf.Abs(hit.point.y - transform.position.y);
                print(distance);
            }

        }

      
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
