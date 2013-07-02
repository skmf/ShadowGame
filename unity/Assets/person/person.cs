using UnityEngine;
using System.Collections;

public class person : MonoBehaviour {
	public Vector3 movement_speed;
	public Vector3 jump_speed;
	public float max_speed;
    
    public static bool newBackgroundPlatformLayerActive;
    public static Vector3 currentPosition;
    public static float zJumpValue = 7;

	private bool background;
	// Use this for initialization
	void Start () {
        newBackgroundPlatformLayerActive = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
			rigidbody.AddForce(jump_speed, ForceMode.VelocityChange);
            newBackgroundPlatformLayerActive = false;
		}
		
		if(Input.GetButton("Horizontal")) {
			if (Mathf.Abs(rigidbody.velocity.x) < max_speed) {
				if (Input.GetAxis("Horizontal") > 0) {
					rigidbody.AddForce(movement_speed, ForceMode.VelocityChange);
				} else if (Input.GetAxis("Horizontal") < 0) {
					rigidbody.AddForce(-movement_speed, ForceMode.VelocityChange);
				}
			}
		}
		
		if (Input.GetButtonDown("Vertical")) {
			if (Input.GetAxis("Vertical") > 0) {
                transform.Translate(0, 0, zJumpValue);
			}
			else if (Input.GetAxis("Vertical") < 0) {
                transform.Translate(0, 0, -zJumpValue);
			}
		}
		
	}
	
	void OnCollisionEnter () {
        newBackgroundPlatformLayerActive = true;
        currentPosition = transform.localPosition;
	}

	void OnCollisionExit () {
        newBackgroundPlatformLayerActive = false;
	}
}
