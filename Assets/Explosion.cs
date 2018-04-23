using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public Animator animator;
    public AudioClip explosion;
    public IEnumerator Start() {
        MarchingBehavior.Instance.GetComponent<AudioSource>().PlayOneShot(explosion);
        animator.SafePlay("explosion", 0);
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
