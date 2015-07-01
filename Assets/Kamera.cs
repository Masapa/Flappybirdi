using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {
	GameObject bird;
	// Use this for initialization
	void Start () {
		bird = GameObject.Find ("bird");
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform lintu = bird.transform;

		transform.position = new Vector3(lintu.position.x,transform.position.y,transform.position.z);


	}
}
