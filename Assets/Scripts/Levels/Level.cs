using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	
	private float tweenTime = 2.0f;
	private PlayLevelButton[] levelButtons;
	private SmoothFollow followCam;
	private Vector3 camOrigPos;
	private Quaternion camOrigRot;
	private Star[] stars;
	private Pallo currentBall;
	
	public Transform ballSpawnPoint;
	public Pallo ball;
	
	// Use this for initialization
	void Start () {
		levelButtons = FindObjectsOfType(typeof(PlayLevelButton)) as PlayLevelButton[];
		followCam = Camera.main.GetComponent<SmoothFollow>();
		camOrigPos = Camera.main.transform.position;
		camOrigRot = Camera.main.transform.rotation;
		stars = GetComponentsInChildren<Star>();
	}
	
	// Update is called once per frame
	public void Play() {
		foreach(PlayLevelButton b in levelButtons) {
			b.gameObject.active = false;
		}
		StartCoroutine("ZoomIn");
		
		currentBall = Instantiate(ball, ballSpawnPoint.position, Quaternion.identity) as Pallo;
		currentBall.level = this;
		followCam.target = currentBall.transform;
		followCam.enabled = true;
		
		foreach(Star star in stars) {
			star.Play();
		}
	}
	
	IEnumerator ZoomIn() {
		float targetTime = Time.time + tweenTime;
		while(Time.time < targetTime) {
			Camera.main.orthographicSize += (3.0f - Camera.main.orthographicSize) * 0.2f;
			yield return new WaitForEndOfFrame();
		}	
		Camera.main.orthographicSize = 3.0f;
	}
	
	IEnumerator ZoomOut() {
		float targetTime = Time.time + tweenTime;
		while(Time.time < targetTime) {
			Camera.main.orthographicSize += (10.0f - Camera.main.orthographicSize) * 0.2f;
			Camera.main.transform.position += (camOrigPos - Camera.main.transform.position) * 0.2f;
			Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, camOrigRot,0.2f);
			yield return new WaitForEndOfFrame();
		}
		Camera.main.orthographicSize = 10.0f;
		Camera.main.transform.position = camOrigPos;
		Camera.main.transform.rotation = camOrigRot;
	}
	
	public void WonLevel() {
		GetComponent<AudioSource>().Play();
		foreach(PlayLevelButton b in levelButtons) {
			b.gameObject.active = true;
		}
		foreach(Star star in stars) {
			star.End();
		}
		StartCoroutine("ZoomOut");
		followCam.enabled = false;
	}
}
