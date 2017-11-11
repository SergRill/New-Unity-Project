using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryButton : MonoBehaviour {

   // public SpriteRenderer background;
   // public SpriteRenderer objectSprite;

    public Inventory inventory;
    public int id;


	// Use this for initialization
	void Start () {
		
	}

    public void press()
    {
        inventory.setInventory(id);
    }

	void Update () {
   
	}
}
