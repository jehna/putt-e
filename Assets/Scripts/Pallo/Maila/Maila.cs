using UnityEngine;
using System.Collections;

public class Maila : MonoBehaviour {
	
	public float power;
	
	public Pallo pallo;
	
	public Transform puttiSuunta;
	
	private Transform palloTrans;
	private Rigidbody palloRigid;
	
	private bool started = false;
	
	// Use this for initialization
	void Start () {
		palloTrans = pallo.transform;
		palloRigid = pallo.GetComponent<Rigidbody>();
		puttiSuunta.gameObject.SetActiveRecursively(false);
		StartCoroutine("StartDelay");
	}
	
	IEnumerator StartDelay() {
		yield return new WaitForSeconds(1);
		started = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!started) return;
		Ray ray;
		RaycastHit hit;
		if(Input.GetMouseButtonDown(0)) {
			puttiSuunta.position = transform.position;
		}
		if(Input.GetMouseButton(0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100)) {
				puttiSuunta.gameObject.SetActiveRecursively(true);
				puttiSuunta.LookAt(hit.point + (Vector3.up * (palloTrans.position.y - hit.point.y)));
				float d = Vector3.Distance(hit.point, palloTrans.position);
				puttiSuunta.localScale = new Vector3(d * 3.0f, 1.0f, d * -3.0f);
			    //Debug.DrawLine(hit.point, palloTrans.position, Color.red);
			}
		} else {
			puttiSuunta.gameObject.active = false;	
		}
		if(Input.GetMouseButtonUp(0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			puttiSuunta.gameObject.SetActiveRecursively(false);
			if (Physics.Raycast(ray, out hit, 100)) {
				GetComponent<AudioSource>().Play();
				Vector3 dir = hit.point - palloTrans.position;
				dir.y = palloTrans.position.y;
			    palloRigid.velocity = dir * power;
				pallo.putteja++;
			}
		}
	}
		
}
