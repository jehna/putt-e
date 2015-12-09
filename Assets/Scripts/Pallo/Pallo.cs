using UnityEngine;
using System.Collections;

public class Pallo : MonoBehaviour {
	
	private Holeinone holeInOne;
	
	public Level level;
	public int putteja = 0;
	
	void Start() {
		holeInOne = FindObjectOfType(typeof(Holeinone)) as Holeinone;
	}
	
	// Use this for initialization
	void IsInHole () {
		if(putteja == 1) holeInOne.Play();
		level.WonLevel();
		Destroy(gameObject);
	}
}
