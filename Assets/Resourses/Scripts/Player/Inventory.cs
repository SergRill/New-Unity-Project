using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Color chooseColor;
    public Color normalColor;

    public int cells = 8;
    public int indent = 200;

    //public InventoryButton buttonStyle;
    //InventoryButton [] buttons;
    public GameObject buttonStyle;
    GameObject[] buttons;
    int lastPressed = 0;

    public Canvas canvas;



    // Use this for initialization
    void Start () {
       /* buttons = new InventoryButton[cells];
        
        for(int i = 0; i < cells; i++)
        {
            buttons[i] = Instantiate(buttonStyle);
            buttons[i].id = i;
            buttons[i].cells = cells;
            buttons[i].inventory = this;
        }
        */
        buttons = new GameObject[cells];

        for (int i = 0; i < cells; i++)
        {
            buttons[i] = Instantiate(buttonStyle);
            buttons[i].transform.parent = this.transform;
            InventoryButton b = buttons[i].GetComponent<InventoryButton>();
            b.id = i;
            b.cells = cells;
            b.inventory = this;
        }

    }

    public void setInventory(int id)
    {
        //buttons[lastPressed].background.color = normalColor;
        //buttons[id].background.color = chooseColor;
        //lastPressed = id;
    }
	
	// Update is called once per frame
	void Update () {


	}
}
