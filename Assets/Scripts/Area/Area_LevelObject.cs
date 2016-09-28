using UnityEngine;
using System.Collections;

public class Area_LevelObject : MonoBehaviour {

	public enum InteractionType {Button, Collision, Stay, Damage};

	public bool interactive = true;
	public InteractionType interactionType;

	public void InteractionButton(){
		if(interactive && interactionType == InteractionType.Button){
			Action();
		}
	}

	private void Action(){
		GetComponent<Renderer>().material.color = new Color(1,0,0);
	}
}
