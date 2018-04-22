using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {
    public MeshRenderer stepOne;
    public MeshRenderer stepTwo;
    public Explosion explosion;

    public bool Exploding {
        get;set;
    }

    public void Explode() {
        Exploding = true;
        Explosion explosionInstance = explosion.Duplicate(transform.position);
        explosionInstance.transform.SetParent(transform.parent);
    }

    public void TakeStep(bool step) {
        if (step) {
            stepOne.enabled = step;
            stepTwo.enabled = !stepOne.enabled;
        }
    }
}
