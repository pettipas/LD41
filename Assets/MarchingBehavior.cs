using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class MarchingBehavior : MonoBehaviour {

    public float stepdistance;
    public float waitTime;
    public AudioSource stepSound;
    public float signDirection = -1;

    public Vector3 halfExtents;
    public GameObject negativeBumper;
    public GameObject positiveBumper;
    public LayerMask enemy;

    public Projectile alienShot;

    public float duratiuon;
    public float countUpToDuration;

    public List<Walker> walkers = new List<Walker>();

    public void Awake() {
        walkers = GameObject.FindObjectsOfType<Walker>().ToList();
    }

    Vector3 velocityForDamp;

    public void Update() {

        if (countUpToDuration >= duratiuon) {
            countUpToDuration = 0;
            Walker negativeWalker = negativeBumper.Detect<Walker>(halfExtents, enemy);
            Walker positiveWalker = positiveBumper.Detect<Walker>(halfExtents, enemy);
          
            if (negativeWalker != null
                && signDirection < 0) {

                signDirection *= -1;
                Vector3 newPosition = transform.position + new Vector3(0, 0, stepdistance * -1);
                transform.position = newPosition;
                duratiuon -= 0.05f;
            }
            else if (positiveWalker != null
              && signDirection > 0) {

                signDirection *= -1;
                Vector3 newPosition = transform.position + new Vector3(0, 0, stepdistance * -1);
                transform.position = newPosition;
                duratiuon -= 0.05f;
            }
            else {
                transform.position += new Vector3(stepdistance * signDirection, 0, 0);
                for (int i = 0; i < walkers.Count; i++) {
                    if (walkers[i] != null) walkers[i].TakeStep();
                }
            }
        }

        countUpToDuration += Time.smoothDeltaTime;
    }

    public void LateUpdate() {
        walkers.RemoveAll(x => x == null);
    }

    public void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(negativeBumper.transform.position, transform.position);
        Gizmos.DrawLine(positiveBumper.transform.position, transform.position);
    }
}
