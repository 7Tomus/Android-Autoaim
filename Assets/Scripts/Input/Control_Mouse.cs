using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class Control_Mouse : MonoBehaviour {

	private CharacterController pController;
	private Quaternion targetRotation;
	private float rotationSpeed = 360;
	private float walkSpeed = 8;
	private float acceleration = 3;
	private Vector3 currentVelocityModifier;
	public VirtualJoystick touchJoystic;

	void Start () {
		pController = GetComponent<CharacterController>();
	}

	void Update () {
		ControlTouch();
	}

	void ControlTouch(){
		Vector3 input = new Vector3(touchJoystic.Horizontal(),0,touchJoystic.Vertical());
		if(input != Vector3.zero){
			targetRotation = Quaternion.LookRotation(input);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,targetRotation.eulerAngles.y,rotationSpeed * Time.deltaTime);
		}
		currentVelocityModifier = Vector3.MoveTowards(currentVelocityModifier,input,acceleration*Time.deltaTime);
		Vector3 motion = currentVelocityModifier;
		motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1)? .7f : 1;
		motion *= walkSpeed;
		motion += Vector3.up * -8;
		pController.Move(motion * Time.deltaTime);
	}
}
