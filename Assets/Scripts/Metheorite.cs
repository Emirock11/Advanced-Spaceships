using UnityEngine;
using System.Collections;

public class Metheorite : MonoBehaviour {

  private int Life = 5;

  public Transform ExplosionParticleSystem;
  public GameObject Item;
  public GameObject Ship;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Bullet") {
      TakeDamage(other.gameObject);
    } else if (other.gameObject.tag == "Bullet2")
    {
      TakeMoreDamage(other.gameObject);
    }
  }

  void TakeDamage(GameObject bullet) {
    Destroy(bullet);
    Life--;
    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    CancelInvoke("ResetColor");
    Invoke("ResetColor", 1);
    if (Life <= 0) {
      Instantiate(ExplosionParticleSystem, transform.position, Quaternion.identity);
      Destroy(gameObject);  
      ShowItem();
    }
  }
  
  void TakeMoreDamage(GameObject bullet) {
    Destroy(bullet);
    Life-=2;
    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    CancelInvoke("ResetColor");
    Invoke("ResetColor", 1);
    if (Life <= 0) {
      Instantiate(ExplosionParticleSystem, transform.position, Quaternion.identity);
      Destroy(gameObject);  
      ShowItem();
    }
  }

    void ShowItem()
    {
      Ship.SendMessage("AddScore");
      int random = Random.Range(0, 100);
      if (random > 25)
      {
        Instantiate(Item, transform.position, Quaternion.identity);
      }
    }

  void ResetColor() {
    gameObject.GetComponent<Renderer>().material.color = Color.white;
  }


}
