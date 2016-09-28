using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public int hp;
	[HideInInspector]
	public bool combatMode;

	public int changeHp(int howMuch){
		hp += howMuch;
		return hp;
	}
}
