using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 10f;
    private Rigidbody2D playerRigidBody;
    private PhotonView punView;

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
    }
}
