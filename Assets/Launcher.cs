using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    public Projectile projectilePrefab;
    public Transform launchPoint;

    public List<Projectile> projectiles = new List<Projectile>();

    public bool MaxInFlight {
        get {

            if (projectiles == null) {
                projectiles = new List<Projectile>();
            }

            return projectiles.Count != 10;
        }
    }

    public void Fire() {
        Projectile proj = projectilePrefab.Duplicate(launchPoint.position);
        projectiles.Add(proj);
    }

    public void LateUpdate() {
        projectiles.RemoveAll(x => x == null);
    }
}
