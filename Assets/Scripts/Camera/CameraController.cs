using UnityEngine;
using System.Collections;

public class CameraController: MonoBehaviour {

	//private MapGenerator mapGen;

	public GameObject player;
	public bool cameraIsStatic;
	public float xAdjustment, yAdjustment = 10, zAdjustment;
	private Vector3 cameraTarget;
	private Transform target;
	//public GameObject player_model;


	void Start(){
		target = player.transform;
		/*
		GameObject player = Instantiate(player_model) as GameObject;
		player.transform.position = new Vector3(-1,-1,-1);
		player.name = "Player";
		target = player.transform;
		*/


	}

	void Update(){
		if(!cameraIsStatic){
			cameraTarget = new Vector3(target.position.x+xAdjustment, target.position.y+yAdjustment, target.position.z+zAdjustment);
			transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime*8);
		}
	}

	void LateUpdate(){
		if(cameraIsStatic){
			transform.LookAt(player.transform,Vector3.up);
		}
	}



	/*
	void Start(){
		target = GameObject.Find("Player").transform;
		mapGen = GameObject.Find("MapSpawn").GetComponent<MapGenerator>();
		float cameraLiftRatio = 0.5f;
		transform.position = new Vector3(mapGen.width / 2.0f, (mapGen.width >= mapGen.height) ? mapGen.width*cameraLiftRatio : mapGen.height*cameraLiftRatio , mapGen.height / 2.0f);
	}
	*/

}
