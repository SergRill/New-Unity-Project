using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryButton : MonoBehaviour {

   // public SpriteRenderer background;
   // public SpriteRenderer objectSprite;

    public Inventory inventory;
    public int id;
    public int cells;
    bool show = false;


	// Use this for initialization
	void Start () {
		
	}

    public void press()
    {
        inventory.setInventory(id);
    }


	
	// Update is called once per frame
	void Update () {
   
	}
}
