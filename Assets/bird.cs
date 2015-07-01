using UnityEngine;
using System.Collections;

public class bird : MonoBehaviour {

	Animator flap;
	Rigidbody2D rb;
	GameObject panel;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		panel = GameObject.Find ("Canvas/Panel");
		panel.SetActive (false);
		flap = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	
	}
	bool jump = false;
	// Update is called once per frame
	void Update () {
		if (paussi)
			panel.SetActive (true);


		if (Input.GetKeyDown (KeyCode.Space)) {

			jump = true;
		}
		

	}
	public float hyppy = 175f;

	bool paussi = false;
	void kuolit(){
		Time.timeScale = 0;
		paussi = true;


	}

	void OnCollisionEnter2D(){
		kuolit ();

	}

	void FixedUpdate(){
		//
		rb.velocity = new Vector2 (1.25f, rb.velocity.y);
		//


		if (jump) {
			if(transform.position.y + 0.25f < Camera.main.ViewportToWorldPoint(Vector2.up).y){
				flap.Play("flap");

				rb.velocity = new Vector2(rb.velocity.x,0);
				rb.AddForce(Vector2.up * hyppy);
			}
			jump = false;
		}

		float angle = Mathf.Atan2 (rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);


	}
}
