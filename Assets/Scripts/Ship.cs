using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

  public bool damage = false;

  public Transform SpawnBulletPosition;

  public Transform Bullet;

  public Transform Bullet2;

  public bool IsSecondaryWeapon = false;

  public GameObject ShipMesh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
    if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) {
      Shoot();
    }

	    if (Input.GetKeyDown(KeyCode.C))
	    {
	        IsSecondaryWeapon = !IsSecondaryWeapon;
	    }
	  
	}

  void Shoot()
  {

      Transform balita;

      if (IsSecondaryWeapon)
      {
          balita = Bullet2;
      }
      else
      {
          balita = Bullet;
      }
      
    Instantiate(balita, SpawnBulletPosition.position, Quaternion.identity);
      
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Metheorite") {
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
