using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeaScript : MonoBehaviour {

   // public Color color;
    public string text;
    public bool isImportant = false;
    public double minAlphaValue = 0.5;

	// Use this for initialization
	void Start () {
		
	}

    public void Hide()
    {
        Color c = GetComponent<UnityEngine.UI.Text>().color;
        GetComponent<UnityEngine.UI.Text>().color = new Color(c.r, c.g, c.b, 0);
        
    }

    public void Show()
    {
        Color c = GetComponent<UnityEngine.UI.Text>().color;
        GetComponent<UnityEngine.UI.Text>().color = new Color(c.r, c.g, c.b, 1);
    }

    // Update is called once per frame
    void Update () {
    
	}
}
