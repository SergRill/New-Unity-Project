using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {


	public bool isLoop = false;
    public bool isPlaying = false;


<<<<<<< HEAD
=======

>>>>>>> e17e4dd8fd5fb2d34589163e0bce82c45fa5d86a
    Animator animator;

    public AnimationBase animationBase;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    public void startAnimation(int id, int delay, bool isLoop)
    {
        if(animator != null)
        {
            animator.CrossFade(animationBase.animations[id], delay);
            this.isLoop = isLoop;
        }
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
