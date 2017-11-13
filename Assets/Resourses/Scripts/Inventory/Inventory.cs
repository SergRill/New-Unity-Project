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

    public GameObject test;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<InventoryButton>().id = i;
            buttons[i].GetComponent<CanvasRenderer>().SetColor(normalColor);
        }
    }

    public void setInventory(int id)
    {
        if (id > 7) id = 0;
        else if (id < 0) id = 7;
        buttons[id].GetComponent<CanvasRenderer>().SetColor(chooseColor);
        buttons[lastPressed].GetComponent<CanvasRenderer>().SetColor(normalColor);
        lastPressed = id;
    }

    public void addObject(GameObject g)
    {
      
        for(int i = 0; i < buttons.Length; i++)
        {
            if(!buttons[i].GetComponent<InventoryButton>().haveObject)
            {
                buttons[i].GetComponent<InventoryButton>().objectTexture.sprite = g.GetComponent<SpriteRenderer>().sprite;
                buttons[i].GetComponent<InventoryButton>().haveObject = true;
                i = buttons.Length;
            }
        }
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
            else if(show)
            {
                if (Input.GetKeyDown(KeyCode.D))
                    setInventory(lastPressed + 1);
                else if (Input.GetKeyDown(KeyCode.A))
                    setInventory(lastPressed - 1);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
            addObject(test);
            }

        }
}
