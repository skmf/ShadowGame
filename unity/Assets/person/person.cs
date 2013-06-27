using UnityEngine;
using System.Collections;

public class person : MonoBehaviour {
	public Vector3 movement_speed;
	public Vector3 jump_speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Jump")) {
			rigidbody.AddForce(jump_speed, ForceMode.VelocityChange);
		}
		
		if(Input.GetButton("Horizontal")) {
			
			if(Mathf.Abs(rigidbody.velocity.x) > 15) {
				return;
			}
			
			if(Input.GetAxis("Horizontal") > 0) {
				rigidbody.AddForce(movement_speed, ForceMode.VelocityChange);
			} else if (Input.GetAxis("Horizontal") < 0) {
				rigidbody.AddForce(-movement_speed, ForceMode.VelocityChange);
			}
			
		}
		

		
	}
}
