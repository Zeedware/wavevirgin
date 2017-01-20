using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {
	
	public void OnTriggerEnter2D(Collider2D other) {
		other.GetComponent<VirginController>().SpawnEdge();
	}
}
