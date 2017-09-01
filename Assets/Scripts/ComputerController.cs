using UnityEngine;

public class ComputerController : MonoBehaviour {

    public Transform ball;
    public float maxVelocity;

    private bool wait = true;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        // chase after the ball but don't be too perfect or else it's impossible to win
        if (wait && Input.GetMouseButtonDown(0)) {
            wait = false;
        }

        if (wait) {
            Vector3 pos = transform.position;
            pos.z = ball.position.z;
            transform.position = pos;
        }
        else {
            Vector3 pos = transform.position;

            if (ball.position.z > transform.position.z) {
                pos.z += maxVelocity * Time.fixedDeltaTime;
            }
            else {
                pos.z -= maxVelocity * Time.fixedDeltaTime;
            }

            pos.z = Mathf.Clamp(pos.z, -7f, 9f);

            transform.position = pos;
        }
    }

    public void ResetAfterScore() {
        wait = true;
    }
}
