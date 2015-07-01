using UnityEngine;
using System.Collections;

public class ground : MonoBehaviour {
	static float nextx = -9;
	public float arvo = 3f;
	
	public void resetti(){
		nextx = -9;
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
