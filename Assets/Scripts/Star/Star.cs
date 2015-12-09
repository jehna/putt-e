using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	
	void Awake() {
		End();
	}
	
	// Use this for initialization
	public void Play () {
		GetComponent<Renderer>().enabled = true;
		GetComponent<Animation>().enabled = true;
	}
	
	public void End() {
		GetComponent<Renderer>().enabled = false;
		GetComponent<Animation>().enabled = false;
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider c) {
		if(!GetComponent<Renderer>().enabled) return;
		GetComponent<AudioSource>().Play();
		End();
	}
}
