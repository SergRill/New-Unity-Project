using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Inventory : MonoBehaviour {

    public Color chooseColor;
    public Color normalColor;

    public GameObject[] buttons;
    int lastPressed = 0;

    public bool show = false;

    // Use this for initialization
    void Start () {

      

        for (int i = 0; i < buttons.Length; i++)
        {
            InventoryButton b = buttons[i].GetComponent<InventoryButton>();
            b.id = i;
            b.inventory = this;
        }

    }

    public void setInventory(int id)
    {
        //buttons[lastPressed].background.color = normalColor;
        //buttons[id].background.color = chooseColor;
        lastPressed = id;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (show == false)
                GetComponent<Animator>().CrossFade("InventoryShow", 1);
            else
                GetComponent<Animator>().CrossFade("InventoryHide", 1);
            show = !show;
        }
	}
}
