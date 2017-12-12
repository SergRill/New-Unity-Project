using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

<<<<<<< HEAD
	public bool isLoop = false;
    public bool isPlaying = false;

=======
    bool isLoop = false;
>>>>>>> 4052c1764df7c85aeaea4cdb15d7eaafa142340c
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
