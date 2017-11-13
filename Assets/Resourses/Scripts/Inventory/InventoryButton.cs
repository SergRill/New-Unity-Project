using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryButton : MonoBehaviour {

   // public SpriteRenderer background;
   // public SpriteRenderer objectSprite;

    public Inventory inventory;
    public int id;
    public bool haveObject = false;

    public UnityEngine.UI.Image objectTexture;

	// Use this for initialization
	void Start () {
        objectTexture = transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        
	}

    public void press()
    {
        inventory.setInventory(id);
    }

	void Update () {
   
	}
}
