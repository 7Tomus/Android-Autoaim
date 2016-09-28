using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{

	void Start ()
	{
		StartCoroutine ("Fade");
	}

	void OnTriggerEnter (Collider c)
	{
		switch (c.tag) {
		case "Enemy":
			{
				if ((c.GetComponent<Stats> ().changeHp (-1)) <= 0) {
					c.GetComponent<CubeEnemy> ().Death ();
				}
				Destroy (gameObject);
				break;
			}
		case "Obstacle":
			{
				Destroy (gameObject);
				break;
			}
		default:
			{
				Destroy (gameObject);
				break;
			}
		}
	}

	IEnumerator Fade ()
	{
		yield return new WaitForSeconds (8);
		Destroy (gameObject);
	}
}
