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

            return projectiles.Count != 2;
        }
    }

    public void Fire() {
        if (MaxInFlight) {
            Projectile proj = projectilePrefab.Duplicate(launchPoint.position);
            projectiles.Add(proj);
            proj.startPosition = this.transform.position;
        }
    }

    public void LateUpdate() {
        projectiles.RemoveAll(x => x == null);
    }
}
