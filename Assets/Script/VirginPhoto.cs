using UnityEngine;
using System.Collections;

public class VirginPhoto : MonoBehaviour {
	
	public Style style;

	public void Awake() {
		style.RandomizeStyle();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			style.RandomizeStyle();
		}
	}
}
