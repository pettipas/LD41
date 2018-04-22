using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public LayerMask blockMAsk;
    public Vector3 extents = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 startPosition;
    public void Update() {
        transform.position += direction * speed * Time.smoothDeltaTime;
        BlockShard shard = this.Detect<BlockShard>(extents, blockMAsk, startPosition);
     
        if (shard != null) {
            Destroy(shard.gameObject);
            Destroy(this.gameObject);
        }

        if (transform.position.z > 32) {
            Destroy(this.gameObject);
        }
    }
}
