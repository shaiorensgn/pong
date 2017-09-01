using UnityEngine;

public class BackWall : MonoBehaviour {

    public GameObject playerPaddle;
    public GameObject computerPaddle;
    public GameObject scoreboard;
    
    private void OnCollisionEnter(Collision collision) {
        scoreboard.SendMessage("IncrementScore", collision.collider.transform.position.x > 0);
        playerPaddle.SendMessage("ResetAfterScore");
        computerPaddle.SendMessage("ResetAfterScore");
    }
}
