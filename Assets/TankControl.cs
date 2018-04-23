using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TankControl : MonoBehaviour {

    public Icon wheel;
    public Icon rightDirection;
    public Icon leftDirection;
    public Icon bullets;

    public NavTarget leftSide;
    public NavTarget rightSide;
    public NavTarget wheelNorth;
    public NavTarget bulletBaySouth;

    public List<NavTarget> targets = new List<NavTarget>();
    public List<Icon> icons = new List<Icon>();
    public AudioClip problemSound;
    public AudioClip buttonHit;
    public void Awake() {
        targets = FindObjectsOfType<NavTarget>().ToList();
        icons = FindObjectsOfType<Icon>().ToList();
    }

    public bool GameOver {
        get {
            return icons.FindAll(x => !x.damaged).Count == 0;
        }
    }

    public Guy cap;

    public void Update() {

        if (Input.GetKeyDown(KeyCode.Alpha1) 
            || Input.GetKeyDown(KeyCode.Keypad1)) {

            cap.GoTo(wheelNorth);
            MarchingBehavior.Instance.GetComponent<AudioSource>().PlayOneShot(buttonHit);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)
         || Input.GetKeyDown(KeyCode.Keypad2)) {
            cap.GoTo(bulletBaySouth);
            MarchingBehavior.Instance.GetComponent<AudioSource>().PlayOneShot(buttonHit);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)
         || Input.GetKeyDown(KeyCode.Keypad3)) {
            cap.GoTo(leftSide);
            MarchingBehavior.Instance.GetComponent<AudioSource>().PlayOneShot(buttonHit);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)
         || Input.GetKeyDown(KeyCode.Keypad4)) {
            cap.GoTo(rightSide);
            MarchingBehavior.Instance.GetComponent<AudioSource>().PlayOneShot(buttonHit);
        }
    }

    public void CauseProblem() {
        Icon icon = icons.FindAll(x => !x.damaged).GetRandomElement();
        if (icon != null) {
            MarchingBehavior.Instance.GetComponent<AudioSource>().PlayOneShot(problemSound);
            icon.damaged = true;
        }
    }
}
