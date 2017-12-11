using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	public bool isLoop = false;
    public bool isPlaying = false;

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    public void startAnimation(string name, int delay, bool isLoop)
    {
        if(animator != null)
        {
            animator.CrossFade(name, delay);
            this.isLoop = isLoop;
        }
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
