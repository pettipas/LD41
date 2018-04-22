using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guy : MonoBehaviour {

    public NavMeshAgent agent;
    public Animator animator;
    public bool isFixing;

    public void Awake() {
        agent.updateRotation = false;
    }

    public void GoTo(NavTarget target) {
        agent.SetDestination(target.transform.position);
    }

    public void Update() {
        if (isFixing) {
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
    }
}
