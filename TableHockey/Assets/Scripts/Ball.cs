using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float force = 1000.0f;

	// Use this for initialization
	void Start () {
	//	rigidbody.AddForce(new Vector3(50f,50f,250f));	
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "PlayerOnePaddle" || 
		   col.gameObject.name == "PlayerTwoPaddle"){
			var paddle = col.gameObject.GetComponent<PaddleController>();

			var forceVec = new Vector3(paddle.DeltaX, 0, paddle.DeltaZ) * force;
			gameObject.rigidbody.AddForce(forceVec,ForceMode.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.rigidbody.position.z > 10) {
			gameObject.rigidbody.position = new Vector3 (0, gameObject.rigidbody.position.y, 0);
			gameObject.rigidbody.velocity = new Vector3(0,0,0);
		}

		if (gameObject.rigidbody.position.z < -10) {
			gameObject.rigidbody.position = new Vector3 (0, gameObject.rigidbody.position.y, 0);
			gameObject.rigidbody.velocity = new Vector3(0,0,0);
		}
	}
}
