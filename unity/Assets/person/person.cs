using UnityEngine;
using System.Collections;

public class person : MonoBehaviour {
	public Vector3 movement_speed;
	public Vector3 jump_speed;
	public float max_speed;
	private bool touchingPlatform;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Jump") && touchingPlatform) {
			rigidbody.AddForce(jump_speed, ForceMode.VelocityChange);
			touchingPlatform = false;
		}
		
		if(Input.GetButton("Horizontal")) {
			
			if (Mathf.Abs(rigidbody.velocity.x) > max_speed) {
				return;
			}
			
			if (Input.GetAxis("Horizontal") > 0) {
				rigidbody.AddForce(movement_speed, ForceMode.VelocityChange);
			} else if (Input.GetAxis("Horizontal") < 0) {
				rigidbody.AddForce(-movement_speed, ForceMode.VelocityChange);
			}
			
		}
	}
	
	void OnCollisionEnter () {
		touchingPlatform = true;
	}

	void OnCollisionExit () {
		touchingPlatform = false;
	}
}
