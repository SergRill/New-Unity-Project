using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceScript : MonoBehaviour {

    public Camera usingCamera;
    // переменные инвентаря
    public Color chooseColor;
    public Color normalColor;

    public GameObject[] buttons;
    public int lastPressed = 0;
    //

    // переменные для ideas
    public IdeaScript[] ideas = new IdeaScript[40];

    public GameObject mainStoryIdea;
    public GameObject sideStoryIdea;
    public GameObject nonStoryIdea;

    public const byte MAIN_STORY_IDEA = 0;
    public const byte SIDE_STORY_IDEA = 1;
    public const byte NON_STORY_IDEA = 2;
    //

    public bool showInventory = false;
    public bool showIdeas = false;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<InventoryButton>().inventory = this;
            buttons[i].GetComponent<InventoryButton>().id = i;
            buttons[i].GetComponent<CanvasRenderer>().SetColor(normalColor);
        }

        UnityEngine.UI.Image panel = transform.GetChild(2).GetComponent<UnityEngine.UI.Image>();
    }

    public bool getShow()
    {
        if (showInventory || showIdeas)
            return true;
        else return false;
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

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<InventoryButton>().inventory = this;
            if (!buttons[i].GetComponent<InventoryButton>().haveObject)
            {
                buttons[i].GetComponent<InventoryButton>().objectTexture.sprite = g.GetComponent<SpriteRenderer>().sprite;
                buttons[i].GetComponent<InventoryButton>().haveObject = true;
                i = buttons.Length;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) && showIdeas == false)
        {
            if (showInventory == false && showInventory == false)
                GetComponent<Animator>().CrossFade("InventoryShow", 1);
            else
                GetComponent<Animator>().CrossFade("InventoryHide", 1);
            showInventory = !showInventory;
        }
        else if (Input.GetKeyDown(KeyCode.D) && showIdeas == false)
            if (showInventory)
                setInventory(lastPressed + 1);
            else { }
        else if (Input.GetKeyDown(KeyCode.A) && showIdeas == false)
            if (showInventory)
                setInventory(lastPressed - 1);
            else { }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            UnityEngine.UI.Image panel = transform.GetChild(2).GetComponent<UnityEngine.UI.Image>();
            panel.color *= -1;
            for (int i = 0; i < ideas.Length; i++)
            {
                if (ideas[i] != null)
                    if (showIdeas)
                        ideas[i].Hide();
                    else ideas[i].Show();
            }
            showIdeas = !showIdeas;
        }
        

    }

    public void addIdea(int ideaID, string text, int x, int y)
    {
        GameObject g = null;
        if (ideaID == MAIN_STORY_IDEA)
            g = createMainStoryIdea(text);
        else if (ideaID == SIDE_STORY_IDEA)
            g = createSideStoryIdea(text);
        else if (ideaID == NON_STORY_IDEA)
            g = createNonStoryIdea(text);

        IdeaScript a = g.GetComponent<IdeaScript>();
        a.text = text;
        g.GetComponent<UnityEngine.UI.Text>().text = text;
        g.GetComponent<RectTransform>().sizeDelta = new Vector2(text.Length * 14, 35);
        g.transform.position = usingCamera.WorldToScreenPoint(new Vector3(x, y, 0));

        ideas[0] = a;
        a.Hide();
    }
    public GameObject createMainStoryIdea(string t)
    {
        return Instantiate(mainStoryIdea, this.gameObject.transform.GetChild(gameObject.transform.GetChildCount() - 1));
    }

    public GameObject createSideStoryIdea(string t)
    {
        return Instantiate(sideStoryIdea, this.gameObject.transform);
    }

    public GameObject createNonStoryIdea(string t)
    {
        return Instantiate(nonStoryIdea, this.gameObject.transform);
    }

}
