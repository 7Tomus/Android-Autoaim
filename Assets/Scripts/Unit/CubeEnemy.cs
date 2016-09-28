using UnityEngine;
using System.Collections;

public class CubeEnemy : MonoBehaviour {

	private GameObject player;

	void Start(){
		player = GameObject.FindWithTag("Player");
	}

	public void Death(){
		StartCoroutine(Dstr());
		player.GetComponent<CombatTargeting>().FindNewTargetWithDelay(0.1f);
	}

	IEnumerator Dstr(){
		gameObject.GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
