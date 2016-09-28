using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class Control_WSAD : MonoBehaviour {

	private CharacterController pController;
	private Quaternion targetRotation;
	private float rotationSpeed = 360;
	private float acceleration = 3;
	private Vector3 currentVelocityModifier;

	void Start () {
		pController = GetComponent<CharacterController>();
	}

	void Update () {
		ControlWASD();
	}

	void ControlWASD(){
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
		if(input != Vector3.zero){
			targetRotation = Quaternion.LookRotation(input);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,targetRotation.eulerAngles.y,rotationSpeed * Time.deltaTime);
		}
		currentVelocityModifier = Vector3.MoveTowards(currentVelocityModifier,input,acceleration*Time.deltaTime);
		Vector3 motion = currentVelocityModifier;
		motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1)? .7f : 1;
		motion += Vector3.up * -8;
		pController.Move(motion * Time.deltaTime);
	}
}
