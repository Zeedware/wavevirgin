﻿using UnityEngine;
using System.Collections;

public class PhoneCameraController : MonoBehaviour {

	public VirginPhoto[] virginPhoto;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			SwipeLeft();
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			SwipeRight();
		}
	}

	public void SwipeLeft() {
		for (int i = 0; i < virginPhoto.Length; ++i) {
			virginPhoto[i].TriggerSwipeLeft();
		}
	}

	public void SwipeRight() {
		for (int i = 0; i < virginPhoto.Length; ++i) {
			virginPhoto[i].TriggerSwipeRight();
		}
	}
}
