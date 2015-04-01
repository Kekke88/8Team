using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {


    public float speed;
    private Rigidbody2D playerRigidBody;
    private PhotonView punView;
    private bool isGrounded;


	// Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        punView = GetComponent<PhotonView>();

	}
	// Update is called once per frame
	void Update () {
        if(punView.isMine)
        {
            InputMovement();
        }
	}
    // Bla bla
    void InputMovement()
    {
        Vector2 curVel = playerRigidBody.velocity;
        curVel.x = (float)(Input.GetAxis("Horizontal") * speed);
        playerRigidBody.velocity = curVel;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidBody.AddForce(new Vector2(0, 14), ForceMode2D.Impulse);
            isGrounded = false;
        } 
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
