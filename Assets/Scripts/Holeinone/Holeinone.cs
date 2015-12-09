using UnityEngine;
using System.Collections;

public class Holeinone : MonoBehaviour {

	public void Play () {
		StartCoroutine("RealPlay");
	}
	
	IEnumerator RealPlay () {
		for(int times = 0; times < 10; times++) {
			Debug.Log("jeejee" + times);
			GetComponent<GUITexture>().enabled = !GetComponent<GUITexture>().enabled;
			yield return new WaitForEndOfFrame();
		}
		GetComponent<GUITexture>().enabled = true;
		yield return new WaitForSeconds(1.5f);
		
		GetComponent<GUITexture>().enabled = false;
		
	}
}
