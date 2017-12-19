using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public CharacterState[] states;
    CharacterState state;

    string currentAnm;

    GameObject gm;
    Animator animator;
    Rigidbody rigibody;

	// Use this for initialization
	void Start () {
		
	}

    public void setGameObject(GameObject g)
    {
        rigibody = g.GetComponent<Rigidbody>();
        animator = g.GetComponent<Animator>();
        gm = g;
        state = states[0];
    }

    public bool setState(string name)
    {
        bool res = false;

            for (int i = 0; i < states.Length; i++)
            {
                if (states[i].stateName.Equals(name) && name != state.stateName)
                {
                state.setCurrentAnm("");
                    state = states[i];
                    res = true;
                }
            }

        return res;
    }


    float mx, my;
    public void setMove()
    {
        mx += state.moveSpeed; my += state.moveSpeed;
    }

    public void setXMove(int direction)
    {
        mx = state.moveSpeed * direction;
    }

    public void setYMove(int direction)
    {
        my = state.moveSpeed * direction;
    }

    void Update () {

        if (mx != 0 || my != 0)
        {
            state.setAnm(animator, state.anmMove);
            rigibody.MovePosition(gm.transform.position + new Vector3(mx, 0, my));
        }
        else state.setAnm(animator, state.anmIdle);


        mx = 0; my = 0;
	}
}
