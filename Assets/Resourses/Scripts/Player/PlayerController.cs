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


        if (Input.GetKey(binds.moveUp))
            stateController.setYMove(1);
        else if (Input.GetKey(binds.moveDown))
            stateController.setYMove(-1);
    }
}
