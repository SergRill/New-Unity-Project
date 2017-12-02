using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBinds : MonoBehaviour {

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode ideasInterface = KeyCode.C;
    public KeyCode inventory = KeyCode.Q;
    public KeyCode sitDown = KeyCode.LeftControl;

    // Use this for initialization
    void Start () {
		
	}

    public static void getButtonAction(KeyCode c)
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
