using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    public List<Animator> tracks = new List<Animator>();
    public float speed;

    public float speedLastFrame;

    public float desiredSpeed  = 5.0f;
    public float spinOutSpeed = 8.0f;

    public bool directionFlipped;
    public float signOfLastSpeed;
    public float spinOutDuration = 1.0f;
    public CharacterController controller;
    public GameZone zone;
    public Launcher launcher;

    public float coolDown;
    public float timeBeforeNext = 0.3f;

    public bool ReadyToShoot {
        get {
            return coolDown >= timeBeforeNext;
        }
    }

    public float AnimationSpeed {
        get {
            if (spinOutDuration > 0) {
                return spinOutSpeed;
            }
            return desiredSpeed;
        } 
    }

	void Update () {
        spinOutDuration -= Time.smoothDeltaTime;
        float x = Input.GetAxis("Horizontal");

        if (x != 0) {

            if (signOfLastSpeed == 0) {
                signOfLastSpeed = Mathf.Sign(x);
            }

            controller.Move(new Vector3(x, 0, 0) * speed * Time.smoothDeltaTime);

            for (int i = 0; i < tracks.Count; i++) {
                if (x < 0) {
                    tracks[i].speed = AnimationSpeed;
                    tracks[i].SafePlay("drive_oneway", 0);
                }
                else {
                    tracks[i].speed = AnimationSpeed;
                    tracks[i].SafePlay("drive_otherway", 0);
                }
            }
        }
        else {
            for (int i = 0; i < tracks.Count; i++) {
                tracks[i].SafePlay("idle", 0);
            }
        }
        if (Mathf.Sign(x) != signOfLastSpeed) {
            spinOutDuration = 1.0f;
        }

        signOfLastSpeed = Mathf.Sign(x);

        if (Input.GetKey(KeyCode.Space) && ReadyToShoot 
            || Input.GetKeyDown(KeyCode.Space)) {
            coolDown = 0;
            launcher.Fire();
        }

        coolDown += Time.smoothDeltaTime;
    }
}
