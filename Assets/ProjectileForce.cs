using UnityEngine;
using System.Collections;

public class ProjectileForce : MonoBehaviour {
    private float speed = 10;

	// Use this for initialization
	void Start () {
        Rigidbody2D projectileBody = GetComponent<Rigidbody2D>();
        Transform transf = GetComponent<Transform>();

        projectileBody.velocity = transf.forward * speed;
        Debug.Log(transf.forward);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
