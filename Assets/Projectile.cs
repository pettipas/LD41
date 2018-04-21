using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Vector3 direction;
    public float speed;

    public void Update() {
        transform.Translate(direction * speed * Time.smoothDeltaTime);
    }
}
