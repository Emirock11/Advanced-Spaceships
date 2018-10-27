using UnityEngine;
using System.Collections;

public class SpawnerMovement : MonoBehaviour {

  public Transform MinimumBoundary;
  public Transform MaxBoundary;
	public GameObject Ship;

  public float TimeForNextPosition = 3;

  public Transform Metheorite;

	// Use this for initialization
	void Start () {
    ChangePosition();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0.0f, Time.deltaTime * 2.0f, 0.0f));
	}

  void ChangePosition() {
    float x = Random.Range(MinimumBoundary.position.x, MaxBoundary.position.x);
    Vector3 currentPosition = transform.position;
    currentPosition.x = x;
    transform.position = currentPosition;

    TimeForNextPosition *= .9f;
    TimeForNextPosition = Mathf.Clamp(TimeForNextPosition, .5f, 3);

	  GameObject meteorito = Instantiate(Metheorite, transform.position, Quaternion.identity).gameObject;
	  meteorito.GetComponent<Metheorite>().Ship = Ship;

    Invoke("ChangePosition", TimeForNextPosition);
  }
}
