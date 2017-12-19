using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour {

    public string stateName = "name";

    public string anmIdle = "idle";
    public string anmMove = "move";

    string currentAnm;
    
    public float moveSpeed = 0;
    public float anmCrossLag = 0.1f;

	// Use this for initialization
	void Start () {
		
	}

    public string getCurrentAnm()
    {
        return currentAnm;
    }

    public void setCurrentAnm(string name)
    {
        currentAnm = name;
    }

    public void setAnm(Animator anm, string name)
    {
        if(currentAnm.Equals(name) == false)
        {
            anm.CrossFade(name, anmCrossLag);
            currentAnm = name;
        }
            
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
