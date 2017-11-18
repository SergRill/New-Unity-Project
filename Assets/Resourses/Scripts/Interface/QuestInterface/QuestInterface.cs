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
        add(MAIN_STORY_IDEA, "testText");
	}
	
    public void add(int ideaID, string text)
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
     

       // g.GetComponent<RectTransform>().localScale = new Vector3(text.Length * 20, 35, 0);
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
