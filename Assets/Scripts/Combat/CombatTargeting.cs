using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent (typeof(Control_Touch))]
public class CombatTargeting : MonoBehaviour {

	public float viewRadius;
	public LayerMask targetMask, obstacleMask;
	[HideInInspector]
	public List<Collider> visibleTargets = new List<Collider>();
	[HideInInspector]
	public int targetNumber = 0;
	public Collider[] targets;
	private Control_Touch controlTouch;
	private Stats stats;

	void Start(){
		stats = GetComponent<Stats>();
		controlTouch = GetComponent<Control_Touch>();
		targets = new Collider[0];
	}

	void Update(){
		if(Input.GetButtonDown("ChangeTarget")){
			FindVisibleTargets();
			ChangeTarget();
		}
	}

	public void FindVisibleTargets(){
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

		for(int i = 0; i< targetsInViewRadius.Length; i++){
			Transform target = targetsInViewRadius[i].transform;
			Vector3 directionToTarget = (target.position - transform.position).normalized;

			float distanceToTarget = Vector3.Distance(transform.position,target.position);

			if(!Physics.Raycast(transform.position,directionToTarget,distanceToTarget,obstacleMask) && !targetsInViewRadius[i].isTrigger && targetsInViewRadius[i].GetComponent<Stats>().hp > 0){
				visibleTargets.Add(targetsInViewRadius[i]);
			}
		}
		targets = new Collider[visibleTargets.Count];
		int n = 0;
		foreach(Collider t in visibleTargets){
			targets[n] = t;
			n++;
		}
	}

	public void ChangeTarget(){
		if(targetNumber >= targets.Length-1){
			targetNumber = 0;
		}else{
			targetNumber++;
		}

		if(targets.Length == 0){
			targetNumber = 0;
			controlTouch.target = null;
			stats.combatMode = false;
			return;
		}else{
			controlTouch.target = targets[targetNumber].transform;
			stats.combatMode = true;
		}
	}

	public void FindNewTargetWithDelay(float delay){
		StartCoroutine(FindNewTargetWithDelayCourutine(delay));
	}

	private IEnumerator FindNewTargetWithDelayCourutine(float delay){
		yield return new WaitForSeconds(delay);
		FindVisibleTargets();
		ChangeTarget();
	}
}
