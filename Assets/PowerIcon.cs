using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerIcon : MonoBehaviour {

    public Icon SystemIcon;
    public Animator animator;
	
	void Update () {
        if (SystemIcon.damaged) {
            animator.SafePlay("damaged", 0);
        }
        else {
            animator.SafePlay("allfine", 0);
        }
    }
}
