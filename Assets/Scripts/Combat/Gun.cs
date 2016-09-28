using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float rpm;
	public int projectileSpeed;
	public Transform spawn;
	public Rigidbody projectile;
	private float secondsBetweenShots;
	private float nextPossibleShotTime;
	private int magazine;
	private Stats stats;

	void Start () {
		stats = GetComponent<Stats>();
		secondsBetweenShots = 60/rpm;
		magazine = 3;
	}

	public void Shoot(){
		if(CanShoot() && stats.combatMode){
			magazine--;
			Rigidbody newProjectile = Instantiate(projectile, spawn.position, spawn.rotation) as Rigidbody;
			newProjectile.AddForce(spawn.forward * projectileSpeed);
			if(magazine<=0){
				magazine = 3;
				nextPossibleShotTime = Time.time + secondsBetweenShots;
			}
		}

	}

	private bool CanShoot(){
		bool canShoot = true;
		if(Time.time<nextPossibleShotTime){
			canShoot = false;
		}
		return canShoot;
	}
}
