using UnityEngine;
using System.Collections;

public class VirginManager : MonoBehaviour {

	private static VirginManager instance;

	public static VirginManager Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<VirginManager>();
			}
			return instance;
		}
	}

	private const int virginCount = 20;
	private VirginController[] virginController;
	public int virginCounter;
	public GameObject prefab;

	public bool isEarthquake;
	public float earthquakeCooldown = -1;

	public GameMode gameMode = GameMode.Girl;

	private void Awake() {
		instance = this;
		Transform virginManagerTransform = transform;
		virginController = new VirginController[virginCount];
		virginCounter = -100;
		for (int i = 0; i < virginCount; ++i) {
			virginController[i] = ((GameObject) GameObject.Instantiate(prefab, virginManagerTransform)).GetComponent<VirginController>();
			virginController[i].Init(this);
        }
        ChangeGameMode(GameMode.Girl);
    }

	private void Update() {
		if (Input.GetKeyDown(KeyCode.P)) {
			ChangeGameMode(GameMode.Normal);
		}
		if (Input.GetKeyDown(KeyCode.O)) {
			ChangeGameMode(GameMode.Girl);
		}
		if (Input.GetKeyDown(KeyCode.I)) {
			ChangeGameMode(GameMode.GirlBoy);
		}
		if (Input.GetKeyDown(KeyCode.U)) {
			ChangeGameMode(GameMode.GirlBoyOldiesGoat);
		}
		if (Input.GetKeyDown(KeyCode.Y)) {
			ChangeGameMode(GameMode.GirlBoyOldiesGoat);
		}

		if (earthquakeCooldown > 0) {
			earthquakeCooldown -= Time.deltaTime;

			if (earthquakeCooldown < 0) {

			}
		}
	}

	public void ChangeGameMode(GameMode gameMode) {
		this.gameMode = gameMode;
		for (int i = 0; i < virginCount; ++i) {
			virginController[i].ChangeGameMode();
		}

		PhoneCameraController.Instance.RandomizePhoto();
	}

	public void EarthquakeUpdate(Style style) {
		if (isEarthquake) {
			for (int i = 0; i < virginCount; ++i) {
				virginController[i].TriggerEarthquake(style);
			}
		}
	}

	public bool IsEarthquakeReady() {
		Debug.Log(earthquakeCooldown < 0);
		return earthquakeCooldown < 0;
	}

	public void EarthquakeBegin(Style style) {
		isEarthquake = true;
		for (int i = 0; i < virginCount; ++i) {
			virginController[i].TriggerInitialEarthquake(style);
		}
		GameController.Instance.CameraEarthquake();
        AudioManager.Instance.playQuake();

		StartCoroutine(DoEarthquake());
    }

	public IEnumerator DoEarthquake() {
		earthquakeCooldown = 2000;

		yield return new WaitForSeconds(5);

		EarthquakeEnd();
		earthquakeCooldown = 15;
	}

	public void EarthquakeEnd() {
		isEarthquake = false;
		for (int i = 0; i < virginCount; ++i) {
			virginController[i].TriggerWalk();
		}
		GameController.Instance.CameraIdle();
        AudioManager.Instance.stopQuake();
	}

	public int GetVirginCounter() {
		return --virginCounter;
	}
}
