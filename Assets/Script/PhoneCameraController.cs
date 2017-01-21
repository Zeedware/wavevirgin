using UnityEngine;
using System.Collections;

public class PhoneCameraController : MonoBehaviour {

	private static PhoneCameraController instance;

	public static PhoneCameraController Instance {
		get {
			return instance;
		}
	}

	private void Awake() {
		instance = this;
	}

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

		PhoneController.Instance.SwipeLeftAnimation();
	}

	public void SwipeRight() {
		for (int i = 0; i < virginPhoto.Length; ++i) {
			virginPhoto[i].TriggerSwipeRight();
		}

		PhoneController.Instance.SwipeRightAnimation();
	}

	public bool IsRight(Style style) {
		for (int i = 0; i < 3; ++i) {
			if (virginPhoto[i].photoID == 1) {
				return virginPhoto[i].IsRight(style);
			}
		}

		return false;
	}
}
