using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class MarchingBehavior : MonoBehaviour {

    public static MarchingBehavior Instance;

    public float stepdistance;
    public float waitTime;
    public AudioClip stepSound;
    public AudioClip stepSound2;
    public AudioClip shootSound;
    public float signDirection = -1;

    public Vector3 halfExtents;
    public GameObject negativeBumper;
    public GameObject positiveBumper;
    public LayerMask enemy;

    public Projectile alienShot;

    public float duratiuon;
    public float countUpToDuration;
    public float countDown;
    public List<Walker> walkers = new List<Walker>();

    public void Awake() {
        walkers = GameObject.FindObjectsOfType<Walker>().ToList();
        Instance = this;
    }

    Vector3 velocityForDamp;
    bool flip = false;
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
                duratiuon -= countDown;

                PLayStepSound();
                Shoot();
            }
            else if (positiveWalker != null
              && signDirection > 0) {

                signDirection *= -1;
                Vector3 newPosition = transform.position + new Vector3(0, 0, stepdistance * -1);
                transform.position = newPosition;
                duratiuon -= countDown;

                PLayStepSound();
                Shoot();
            }
            else {
                transform.position += new Vector3(stepdistance * signDirection, 0, 0);
                for (int i = 0; i < walkers.Count; i++) {
                    if (walkers[i] != null) walkers[i].TakeStep();
                }

                PLayStepSound();
                Shoot();
            }
        }

        countUpToDuration += Time.smoothDeltaTime;
    }

    public void PLayStepSound() {
        if (flip) {
            MarchingBehavior.Instance.GetComponent<AudioSource>().PlayOneShot(stepSound);
        }else {
            MarchingBehavior.Instance.GetComponent<AudioSource>().PlayOneShot(stepSound2);
        }
        flip = !flip;
    }

    public void Shoot() {
        walkers.RemoveAll(x => x == null);
       

        for (int i = 0; i < walkers.Count; i++) {
            if (Random.value > 0.9) {
                Projectile proj = alienShot.Duplicate(walkers[i].transform.position);
                proj.startPosition = walkers[i].transform.position;
            }
        }
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
