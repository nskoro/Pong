using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        Invoke ("GoBall", 2);
    }

    // Update is called once per frame
    void Update () {

    }

    void GoBall () {
        float rand = Random.Range (0, 2);
        if (rand < 1) {
            rb2d.AddForce (new Vector2 (20, Random.Range(-15, 15)) );
        } else {
            rb2d.AddForce (new Vector2 (-20, Random.Range(-15,15)) );
        }
    }

    void ResetBall () {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame () {
        ResetBall ();
        Invoke ("GoBall", 1);
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y) + (coll.collider.attachedRigidbody.velocity.y / 2);

            if (vel.x < 1 && vel.x >-1)
                vel.x = (vel.x * 2);
            if (vel.y< 1 && vel.y >-1)
                vel.y = vel.y * 2;

            rb2d.velocity = vel;
        }
    }
}