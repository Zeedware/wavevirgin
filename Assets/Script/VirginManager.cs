using UnityEngine;
using System.Collections;

public class VirginManager : MonoBehaviour {

	private static VirginManager instance;

	public static VirginManager Instance {
		get {
			return instance;
		}
	}

	private const int virginCount = 20;
	private VirginController[] virginController;
	public int virginCounter;
	public GameObject prefab;

	public bool isEarthquake;

	private void Awake() {
		instance = this;
		Transform virginManagerTransform = transform;
		virginController = new VirginController[virginCount];

		for (int i = 0; i < virginCount; ++i) {
			virginController[i] = ((GameObject) GameObject.Instantiate(prefab, virginManagerTransform)).GetComponent<VirginController>();
			virginController[i].Init(this);
		}
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha6)) {
			EarthquakeBegin(virginController[0].style);
		}
		if (Input.GetKeyDown(KeyCode.Alpha7)) {
			EarthquakeEnd();
		}
	}

	public void EarthquakeUpdate(Style style) {
		if (isEarthquake) {
			for (int i = 0; i < virginCount; ++i) {
				virginController[i].TriggerEarthquake(style);
			}
		}
	}

	public void EarthquakeBegin(Style style) {
		isEarthquake = true;
		for (int i = 0; i < virginCount; ++i) {
			virginController[i].TriggerInitialEarthquake(style);
		}
	}

	public void EarthquakeEnd() {
		isEarthquake = false;
		for (int i = 0; i < virginCount; ++i) {
			virginController[i].TriggerWalk();
		}
	}

	public int GetVirginCounter() {
		return --virginCounter;
	}
}
