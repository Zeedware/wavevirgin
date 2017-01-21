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
		Style targetStyle = virginPhoto[0].virginController.style;
		for (int i = 0; i < virginPhoto.Length; ++i) {
			virginPhoto[i].TriggerSwipeLeft();
			if (virginPhoto[i].photoID == 0) {
				targetStyle = virginPhoto[i].virginController.style;
			} 
		}

		VirginManager.Instance.EarthquakeUpdate(targetStyle);
		PhoneController.Instance.SwipeLeftAnimation();
	}

	public void SwipeRight() {
		Style targetStyle = virginPhoto[0].virginController.style;
		for (int i = 0; i < virginPhoto.Length; ++i) {
			virginPhoto[i].TriggerSwipeRight();
			if (virginPhoto[i].photoID == 0) {
				targetStyle = virginPhoto[i].virginController.style;
			} 
		}

		VirginManager.Instance.EarthquakeUpdate(targetStyle);
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
