using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour {

   // public SpriteRenderer background;
   // public SpriteRenderer objectSprite;

    public Inventory inventory;
    public int id;
    public int cells;



	// Use this for initialization
	void Start () {
		

	}

    public void press()
    {
        inventory.setInventory(id);

    }


	
	// Update is called once per frame
	void Update () {
       // int x = ((Screen.width - inventory.indent*2 ) / cells) * (id + 1) ;
       // int d = ((Screen.width - inventory.indent * 2) / cells)/2;

     

       // transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x - d + inventory.indent, 50 , 100));
	}
}
