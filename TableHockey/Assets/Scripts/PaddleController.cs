using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float DeltaX;
	public float DeltaZ;

	public bool IsForThisPlayer;
	public bool ThisPlayerIsPlayerTwo;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision col){
	
	}
	
	// Update is called once per frame
	void Update () {
		if (IsForThisPlayer) {
				DeltaX = Input.GetAxis ("Mouse X");
				DeltaZ = Input.GetAxis ("Mouse Y");

				var xPos = Mathf.Clamp (rigidbody.position.x + DeltaX, -6.65f, 6.65f);
				var zPos = ThisPlayerIsPlayerTwo ? Mathf.Clamp (rigidbody.position.z + DeltaZ, 0f, 9.20f) : Mathf.Clamp (rigidbody.position.z + DeltaZ, -9.20f, 0f);

				rigidbody.position = new Vector3 (xPos, rigidbody.position.y, zPos);	
		}
	}
}
