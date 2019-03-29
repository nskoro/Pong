using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public bool computer = false;
     
    public float speed = 20.0f;
    public float boundY = 0.25f;
    private Rigidbody2D rb2d;
    GameObject theBall;

    // Start is called before the first frame update
    void Start () {
        Debug.Log("Start called.");
        rb2d = GetComponent<Rigidbody2D>();
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update () {
      //   Debug.Log("Update called called.");
        var vel = rb2d.velocity;

        if (!computer)
        { 
            if (Input.GetKey (moveUp)) {
                vel.y = speed;
            } else if (Input.GetKey (moveDown)) {
                vel.y = -speed;
            } else {
                vel.y = 0;
            }
        }
        else
        {
            Debug.Log("computers turn to update " + theBall.transform.position.y);
            if (rb2d.transform.position.y > (theBall.transform.position.y + 0.4))
                vel.y = -speed;
            else if (rb2d.transform.position.y < (theBall.transform.position.y-0.4))
                vel.y = speed;
            else
                vel.y = 0;
        }

        rb2d.velocity = vel;


        var pos = transform.position;
        if (pos.y > boundY) {
            pos.y = boundY;
        } else if (pos.y < -boundY) {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}