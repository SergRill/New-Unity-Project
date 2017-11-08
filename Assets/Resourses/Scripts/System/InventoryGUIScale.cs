using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGUIScale : MonoBehaviour {

    Vector3 scale;
    Vector3 startScale;
    Vector3 startPosition;
    // Use this for initialization
    void Start () { 
        startPosition = new Vector3(GetComponent<RectTransform>().transform.localPosition.x, GetComponent<RectTransform>().localPosition.y, 0);
        startScale = new Vector3(GetComponent<RectTransform>().transform.localScale.x, GetComponent<RectTransform>().localScale.y, 0);
        GetComponent<RectTransform>().transform.localScale = scale;
    }
	
	// Update is called once per frame
	void Update () {

        scale.x = Screen.width /startScale.x; // Получаем фактор соотношения по ширине 
        scale.y = Screen.height / startScale.y; // Получаем фактор соотношения по высоте
        scale.z = 1; // Неиспользуется, но указать стоит
        
        GetComponent<RectTransform>().transform.localPosition = new Vector3(startPosition.x + scale.x, startPosition.y + scale.y, 0);
       

        print(scale.x);
    }
}
