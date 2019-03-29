using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;
    public int winScore = 5;
     
    GameObject theBall;

    // Start is called before the first frame update
    void Start () {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update () {

    }

    public static void Score (string wallID) {
        if (wallID == "RightWall") {
            PlayerScore1++;
        } else {
            PlayerScore2++;
        }
    }

    void OnGUI () {

        if (theBall == null)
            theBall = GameObject.FindGameObjectWithTag("Ball");

        GUI.skin = layout;
        GUI.Label (new Rect (Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label (new Rect (Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button (new Rect (Screen.width / 2 - 60, 35, 120, 53), "RESTART")) {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage ("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == winScore) {
            GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "COMPUTER WINS");
            theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (PlayerScore2 == winScore) {
            GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER WINS");
            theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}