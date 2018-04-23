
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGuy : MonoBehaviour {

    public Animator animator;
	
	void Update () {
        animator.SafePlay("fixing");
        if (Input.anyKeyDown) {
            SceneManager.LoadScene("main");
        }
    }
}
