using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private static GameController instance;

	public static GameController Instance {
		get {
			return instance;
		}
	}

	private void Awake() {
		instance = this;
	}

	public PhoneCameraController phoneCameraController;
	public Animator cameraAnimator;

	public bool IsRight(Style style) {
		return phoneCameraController.IsRight(style);
	}

	public void CameraIdle() {
		cameraAnimator.SetTrigger("Idle");
	}

	public void CameraEarthquake() {
		cameraAnimator.SetTrigger("Earthquake");
	}
}
