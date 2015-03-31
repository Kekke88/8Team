using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 10f;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        InputMovement();
	}

    void InputMovement()
    {
        Vector2 curVel = rb.velocity;
        curVel.x = (float)(Input.GetAxis("Horizontal") * speed);
        rb.velocity = curVel;
    }
}
