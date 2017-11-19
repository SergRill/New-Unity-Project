using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInterface : MonoBehaviour {

    public LinkedList<IdeaScript> ideas = new LinkedList<IdeaScript>();

    public GameObject mainStoryIdea;
    public GameObject sideStoryIdea;
    public GameObject nonStoryIdea;

    public const byte MAIN_STORY_IDEA = 0;
    public const byte SIDE_STORY_IDEA = 1;
    public const byte NON_STORY_IDEA = 2;

    // Use this for initialization
    void Start () {
        add(MAIN_STORY_IDEA, "tttttTTTTtt", 3, 4);
	}
	
    public void add(int ideaID, string text, int x, int y)
    {
        GameObject g = null ;
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
        g.transform.position = Camera.main.WorldToScreenPoint(new Vector3(x, y, 0));
        
        ideas.AddFirst(a);
    }

    public GameObject createMainStoryIdea(string t)
    {
        return Instantiate(mainStoryIdea, this.gameObject.transform);
    }

    public GameObject createSideStoryIdea(string t)
    {
        return Instantiate(sideStoryIdea, this.gameObject.transform);
    }

    public GameObject createNonStoryIdea(string t)
    {
        return Instantiate(nonStoryIdea, this.gameObject.transform);
    }
   

    void Update () {
		
	}
}
