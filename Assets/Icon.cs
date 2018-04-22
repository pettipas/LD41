using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour {

    public Animator iconAnimation;
    public bool damaged;

    public void Update() {
        if (damaged) {
            iconAnimation.SafePlay("damaged", 0);
        }
        else {
            iconAnimation.SafePlay("functional", 0);
        }
    }
}
