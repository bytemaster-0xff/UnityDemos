using UnityEngine;
using System.Collections;

public class BackStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "PongBall"){
			//rigidbody.position
			//col.gameObject.rigidbody.AddForce(new Vector3(50f,-50f,150.0f));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
