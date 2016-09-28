using UnityEngine;
using System.Collections;

public class TouchSwitch : MonoBehaviour {

	private int i;
	public GameObject doors;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private bool inProcess;
	private Vector3 howMuch;

	void Start(){
		howMuch = new Vector3(4.5f,0,0);
	}

	public void OnTouchDown(){
		if((gameObject.transform.position - GameObject.FindWithTag("Player").transform.position).magnitude < 3){
			if(!inProcess){
				i++;
				if(i%2 == 0){
						StartCoroutine(MoveDoors((doors.transform.position + howMuch),1));
				}else{
						StartCoroutine(MoveDoors((doors.transform.position - howMuch),1));
				}
			}
		}
	}

	IEnumerator MoveDoors(Vector3 targetPosition, float speed){
		inProcess = true;
		GetComponent<Renderer>().material.color = Color.yellow;
		while (doors.transform.position != targetPosition){
			float step = speed * Time.deltaTime;
			doors.transform.position = Vector3.MoveTowards(doors.transform.position, targetPosition, step);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		GetComponent<Renderer>().material.color = Color.white;
		inProcess = false;
	}
}
