using UnityEngine;
using System.Collections;

public class SHIAI : MonoBehaviour
{

	public float radioVision;
	public bool damage = false;

	public Transform SpawnBulletPosition;

	public Transform Bullet;

	public bool IsSecondaryWeapon = false;

	public GameObject ShipMesh;

	public GameObject Player;

	private Vector3 initialPosition;

	// Use this for initialization
	void Start ()
	{
		//Player = GameObject.FindGameObjectWithTag("Player");
		InvokeRepeating("Shoot", 0,3);
	}
	
	// Update is called once per frame

	private void Update()
	{
        /*Vector3 target = initialPosition;
		float dist = Vector3.Distance(Player.transform.position, transform.position);
		if (dist < radioVision)
		{
			target = Player.transform.position;
		}*/
        
	}

	void Shoot()
	{
      
		Instantiate(Bullet, SpawnBulletPosition.position, Quaternion.identity);
      
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bullet2") {
			Damaged();
		}
	}

	void Damaged() {
		if (damage) {
			return;
		}
		damage = true;
		ShipMesh.GetComponent<Renderer>().material.color = Color.red;
		Invoke("NotDamaged", 2);
	}

	void NotDamaged() {
		damage = false;
		ShipMesh.GetComponent<Renderer>().material.color = Color.white;
	}
}
