using UnityEngine;

public class ScoreBoard : MonoBehaviour {

    private int playerScore, computerScore;
	// Use this for initialization
	void Start () {
        playerScore = computerScore = 0;
	}
	
    private void IncrementScore(bool player) {
        if (player) {
            playerScore += 1;
        }
        else {
            computerScore += 1;
        }

        GetComponent<TextMesh>().text = "" + playerScore + " : " + computerScore;
    }
}
