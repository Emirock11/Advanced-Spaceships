using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScore : MonoBehaviour {

    public int Life = 100;
    public int Score = 0;

    // Use this for initialization
    void Start () {
		
    }
    private void OnGUI()
    {
        GUILayout.Label("Vida:  " + Life);
        GUILayout.Label("Score:  " + Score);

    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("CHOQUEEEE");
        Debug.Log(other.gameObject.tag);
        
        if (other.gameObject.tag == "BulletIA")
        {
            Life = Life - 10;
        }
        if (other.gameObject.tag == "Metheorite")
        {
            Life = Life - 5;
        }
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
            Destroy(other);
            if(Life+10 <= 100) Life = Life + 10;
            Score += 10;
        }

    }

    public void AddScore()
    {
        int score = 100;
        Score += score;
    }

    // Update is called once per frame
    void Update () {
		
    }
}