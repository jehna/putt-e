using UnityEngine;
using System.Collections;

public class PlayLevelButton : MonoBehaviour {
	
	public Level level;
	private Transform t;
	private Vector3 origPos;
	private Vector3 origScale;
	
	// Use this for initialization
	void Start () {
		t = level.transform;
	}
	
	// Update is called once per frame
	void OnMouseEnter () {
		Vector3 p = origPos = t.position;
		Vector3 s = origScale = t.localScale;
		p.y += 0.2f;
		s *= 1.4f;
		t.position = p;
		t.localScale = s;
	}
	void OnMouseExit() {
		t.position = origPos;
		t.localScale = origScale;
	}
	
	void OnMouseUp() {
		OnMouseExit();
		level.Play();
	}
}
