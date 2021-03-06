using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController), typeof(CombatTargeting))]
public class Control_Touch : MonoBehaviour {

	private CharacterController pController;
	private Quaternion targetRotation;
	private float rotationSpeed = 360;
	private float walkSpeed = 8;
	private float acceleration = 3;
	private Vector3 currentVelocityModifier;
	public VirtualJoystick touchJoystic;
	[HideInInspector]
	public Transform target;
	private CombatTargeting combatTargeting;
	private Gun gun;
	private Stats stats;

	void Start () {
		pController = GetComponent<CharacterController>();
		combatTargeting = GetComponent<CombatTargeting>();
		gun = GetComponent<Gun>();
		stats = GetComponent<Stats>();
	}

	void Update () {
		ControlTouch();
		if(Input.GetButtonDown("Shoot")){
			gun.Shoot();
		}
	}

	void ControlTouch(){
		Vector3 input = new Vector3(touchJoystic.Horizontal(),0,touchJoystic.Vertical());
		if(input != Vector3.zero && !stats.combatMode){
			targetRotation = Quaternion.LookRotation(input);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,targetRotation.eulerAngles.y,rotationSpeed * Time.deltaTime);
		}
		if(stats.combatMode){
			if(((target.position - transform.position).magnitude) > combatTargeting.viewRadius){
				combatTargeting.FindVisibleTargets();
				combatTargeting.ChangeTarget();
				if(!stats.combatMode){
					return;
				}
			}
			targetRotation = Quaternion.LookRotation(target.position - transform.position);
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
