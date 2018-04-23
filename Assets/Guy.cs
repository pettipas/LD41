using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Guy : MonoBehaviour {

    public NavMeshAgent agent;
    public Animator animator;
    public bool isFixing;
    public List<Icon> icons;
    public AudioClip fixedSound;
    public float fixTimer;
    public float fixTime = 2.0f;

    public void Awake() {
        icons = FindObjectsOfType<Icon>().ToList();
        agent.updateRotation = false;
    }

    public void GoTo(NavTarget target) {
        if(fixTimer == 0)
            agent.SetDestination(target.transform.position);
    }

    Icon broken;

    public void Update() {

        if (fixTimer >= fixTime) {
            fixTimer = 0;
            isFixing = false;
            broken.damaged = false;
            broken = null;
            MarchingBehavior.Instance.GetComponent<AudioSource>().PlayOneShot(fixedSound);
        }

        if (isFixing) {
            fixTimer += Time.smoothDeltaTime;
            animator.SafePlay("fixing", 0);
        }
        else {
            if (agent.hasPath) {
                animator.SafePlay("walk", 0);
            }
            else {
                animator.SafePlay("idle", 0);
            }
        }

        Icon problem = icons.Find(x => x.damaged && Vector3.Distance(x.transform.position, transform.position) <= 0.5f);

        if (problem != null && isFixing == false) {
            broken = problem;
            isFixing = true;
        }
    }
}
