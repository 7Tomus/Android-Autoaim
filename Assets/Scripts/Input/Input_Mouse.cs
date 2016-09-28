using UnityEngine;
using System.Collections;

public class Input_Mouse : MonoBehaviour {

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit,100f)){
				Area_LevelObject levelObject = hit.collider.GetComponent<Area_LevelObject>();
				if(levelObject != null){
					levelObject.InteractionButton();
				}
			}
		}
	}
}
