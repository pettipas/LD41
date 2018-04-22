using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour {

    public Icon wheel;
    public Icon rightDirection;
    public Icon leftDirection;
    public Icon bullets;

    public NavTarget leftSide;
    public NavTarget rightSide;
    public NavTarget wheelNorth;
    public NavTarget bulletBaySouth;

    public Guy cap;

    public void Update() {

        if (Input.GetKeyDown(KeyCode.Alpha1) 
            || Input.GetKeyDown(KeyCode.Keypad1)) {

            cap.GoTo(wheelNorth);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)
         || Input.GetKeyDown(KeyCode.Keypad2)) {
            cap.GoTo(bulletBaySouth);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)
         || Input.GetKeyDown(KeyCode.Keypad3)) {
            cap.GoTo(leftSide);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)
         || Input.GetKeyDown(KeyCode.Keypad4)) {
            cap.GoTo(rightSide);
        }
    }
}
