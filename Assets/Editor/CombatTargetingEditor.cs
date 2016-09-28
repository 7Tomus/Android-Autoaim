using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (CombatTargeting))]
public class CombatTargetingEditor : Editor {

	void OnSceneGUI() {
		CombatTargeting fow = (CombatTargeting)target;
		Handles.color = Color.white;
		Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);

		if(fow.targets.Length > 0){
			Handles.color = Color.red;
			Handles.DrawLine (fow.transform.position, fow.targets[fow.targetNumber].transform.position);
		}
	}

}
