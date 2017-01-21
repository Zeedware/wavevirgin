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

	public bool IsRight(Style style) {
		return phoneCameraController.IsRight(style);
	}
}
