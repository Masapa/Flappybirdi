using UnityEngine;
using System.Collections;

public class pipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnBecameInvisible(){
		if (GameObject.Find ("Controller")) {
			if(transform.position.x < Camera.main.transform.position.x){
				GameObject.Find ("Controller").GetComponent<Controller>().que.Add (gameObject);

			}

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
