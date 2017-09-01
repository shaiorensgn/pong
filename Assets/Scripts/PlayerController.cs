using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject ball;
    public Vector3 clickImpulse;

    private float initialMouseY;
    
    private Vector3 initialBallPos;
    private bool wait = true;

	// Use this for initialization
	void Start () {
        initialMouseY = Input.mousePosition.y;
        initialBallPos = ball.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 mousePos = Input.mousePosition;

        if (wait && Input.GetMouseButtonDown(0)) {
            // left click
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(clickImpulse, ForceMode.Impulse);
            wait = false;
        }
        else {
            Vector3 pos = transform.position;

            pos.z = (mousePos.y - initialMouseY) / 10; // janky slow down of the mouse

            pos.z = Mathf.Clamp(pos.z, -7f, 9f);
            transform.position = pos;

            if (wait) {
                Vector3 ballPos = ball.transform.position;
                ballPos.z = pos.z;
                ball.transform.position = ballPos;
            }
        }
	}

    public void ResetAfterScore() {
        wait = true;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.velocity = new Vector3();
        ball.transform.position = initialBallPos;
    }
}
