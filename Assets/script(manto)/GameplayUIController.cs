using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour {

	public int TOTAL_SNACHED_VIRGIN = 0;
	public Text scoreText, resultScoreText, totalSnachedText;
	public int currentScore;
	public GameObject particleContainer;
	public Button skill_earthShake;
	public ParticlePool particlePool;
	public VirginManager virginManager;
	public Image cooldownMask;
	public float cooldownTime = 10f;
	bool cooldownSkill;
	void OnEnable()
	{
		GameEvent.onAddScoreE += GameEvent_onAddScoreE;
		GameEvent.onEarthShakeE += GameEvent_onEarthShakeE;
		GameEvent.onTouchPeopleE += GameEvent_onTouchPeopleE;
	}

	void OnDisable()
	{
		GameEvent.onAddScoreE -= GameEvent_onAddScoreE;
		GameEvent.onEarthShakeE -= GameEvent_onEarthShakeE;
		GameEvent.onTouchPeopleE -= GameEvent_onTouchPeopleE;
	}
	void Start()
	{
		skill_earthShake.onClick.AddListener (GameEvent_onEarthShakeE);
	}
	public void RestartGameplay()
	{
		currentScore = 0;
		GameEvent_onAddScoreE (0);
//		virginManager.
	}
	public void GameEvent_onEarthShakeE ()
	{
		if (!cooldownSkill) {
			particlePool.PlayRubbleParticle ();
			virginManager.EarthquakeBegin (PhoneCameraController.Instance.virginPhoto [1].virginController.style);
			cooldownSkill = true;
		}
	}

	void ActivateSkill_1()
	{
		GameEvent.OnEarthShake ();
	}

	void GameEvent_onAddScoreE (int score)
	{
		currentScore += score;
		TOTAL_SNACHED_VIRGIN += score;
		scoreText.text = currentScore.ToString ();
		resultScoreText.text = currentScore.ToString ();
		totalSnachedText.text = TOTAL_SNACHED_VIRGIN.ToString ();
	}

	void Update()
	{
		if (cooldownSkill) {
			CheckCoooldown ();				
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			GameEvent.OnTouchPeople (true);
			GameEvent_onTouchPeopleE (true);
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			GameEvent.OnTouchPeople (false);
			GameEvent_onTouchPeopleE (false);
		}
	}

	void CheckCoooldown()
	{
		cooldownMask.gameObject.SetActive (true);
		cooldownMask.fillAmount -= Time.deltaTime/cooldownTime;
		if (cooldownMask.fillAmount <= 0) {
			cooldownSkill = false;
			cooldownMask.gameObject.SetActive (false);
			cooldownMask.fillAmount = 1f;
		}
	}

	void GameEvent_onTouchPeopleE (bool isRight) {
		if(isRight)
			GameEvent.OnAddScore (1);
		if (gameObject.activeInHierarchy) {
			StartCoroutine (PlayParticle (isRight));
		}
	}

	IEnumerator PlayParticle(bool isRight) {
		Vector3 particlePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		ParticleSystem particle = particlePool.GetAvailableParticle (isRight);
		particle.gameObject.transform.position = new Vector3 (particlePosition.x, particlePosition.y, particleContainer.transform.position.z);
		particle.gameObject.SetActive(true);
			particle.Play();
			yield return new WaitForSeconds(1);
			particle.Stop();
			particle.gameObject.SetActive(false);
		yield return null;
	}
}
