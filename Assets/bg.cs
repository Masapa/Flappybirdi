using UnityEngine;
using System.Collections;

public class bg : MonoBehaviour {
	static float nextx = -6;
	public float arvo = 2.6f;

	public void resetti(){
		nextx = -6;
	}
	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (nextx, transform.position.y);
		nextx += arvo;
	
	}

	void OnBecameInvisible(){
		if (Camera.main) {
			if(transform.position.x < Camera.main.transform.position.x){
				transform.position = new Vector2 (nextx, transform.position.y);
				nextx += arvo;

			}
		}

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
