using UnityEngine;
using System.Collections;

public class pisteet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			GameObject.Find ("Controller").GetComponent<Controller>().pisteett++;

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
