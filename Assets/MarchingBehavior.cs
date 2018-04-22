using UnityEngine;

public class MarchingBehavior : MonoBehaviour {

    public float stepdistance;
    public float waitTime;
    public AudioSource stepSound;
    public float signDirection = -1;

    public Vector3 halfExtents;
    public GameObject negativeBumper;
    public GameObject positiveBumper;
    public LayerMask enemy;

    public float duratiuon;
    public float countUpToDuration;

    public void Update() {
        if (countUpToDuration >= duratiuon) {
            countUpToDuration = 0;
            Walker negativeWalker = negativeBumper.Detect<Walker>(halfExtents, enemy);
            Walker positiveWalker = positiveBumper.Detect<Walker>(halfExtents, enemy);
          
            if (negativeWalker != null
                && signDirection < 0) {

                signDirection *= -1;
                transform.position += new Vector3(0, 0, stepdistance * -1);
            }
            else if (positiveWalker != null
              && signDirection > 0) {

                signDirection *= -1;
                transform.position += new Vector3(0, 0, stepdistance * -1);

            }
            else {
                transform.position += new Vector3(stepdistance * signDirection, 0, 0);
            }
        }
        countUpToDuration += Time.smoothDeltaTime;
    }

    public void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(negativeBumper.transform.position, transform.position);
        Gizmos.DrawLine(positiveBumper.transform.position, transform.position);
    }
}
