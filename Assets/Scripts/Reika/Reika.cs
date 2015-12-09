using UnityEngine;
using System.Collections;

public class Reika : MonoBehaviour {

	void OnTriggerEnter(Collider c) {
		c.GetComponent<Rigidbody>().gameObject.SendMessage("IsInHole");
	}
}
