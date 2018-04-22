using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public Animator animator;

    public IEnumerator Start() {
        animator.SafePlay("explosion", 0);
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
