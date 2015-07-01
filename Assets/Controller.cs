using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	float nextx = 3; // kertoo seuraavan piipun paikan X suunnassa.
	float previous = 2f; // kertoo viime piipun paikan Y suunnassa.
	float plusmiinus = 0.5f; // kuinka paljon piippu saa siirtyä Y suunnassa ylös tai alas päin.
	public List<GameObject> que;

	public int pisteett = 0;
	GameObject teksti;

	float widthi = 0.48f;


	void hankaluus(){
		if (nextx <= 50) {
			nextx+=6*widthi;
		}
		if (nextx > 50 && nextx < 100) {
			nextx += Random.Range (widthi*2,5*widthi);
			plusmiinus = 0.75f;
		}
		if (nextx >= 100) {
			nextx += widthi;
			plusmiinus = 0.25f;
		}

	}

	void updatepipe(GameObject p){
									// 1.5 ja 2.5
		float random = Random.Range (previous - plusmiinus, previous + plusmiinus);
		if (random < 2.73f) // ettei mee alle minimin.
			random = 2.73f;
		if (random > 4.71f) // ettei mee yli maximin.
			random = 4.71f;

		p.transform.position = new Vector2 (nextx, random);
		previous = random;
		hankaluus ();

	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		teksti = GameObject.Find ("Canvas/Text");

		GameObject tmp = Instantiate (Resources.Load ("background")) as GameObject;
		tmp.GetComponent<bg> ().resetti ();
		for(int i = 0;i<15;i++)
			Instantiate (Resources.Load ("background"));

		tmp = Instantiate (Resources.Load ("ground")) as GameObject;
		tmp.GetComponent<ground> ().resetti ();

		for (int i = 0; i<15; i++)
			Instantiate (Resources.Load ("ground"));


		float distansi = (Mathf.Abs (Camera.main.ViewportToWorldPoint (new Vector3 (-1, 0, 0)).x) + Mathf.Abs (Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x)) * 2;
		for(float i = 0;i<distansi;i += widthi){
			tmp = Instantiate(Resources.Load ("pipup")) as GameObject;
			updatepipe(tmp);
		}






	}
	public void lpiste(){
		Debug.Log ("asd");
		pisteett++;

	}
	// Update is called once per frame
	void Update () {

		teksti.GetComponent<Text> ().text = "Pisteet: " + pisteett;

		if (Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x + widthi >= nextx) {
			if(que.Count > 0){
				updatepipe(que[0]);
				que.RemoveAt(0);
			}


		}
	}
}
