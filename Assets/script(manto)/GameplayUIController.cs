using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour {

	public Text scoreText, resultScoreText;
	public int currentScore;
	public GameObject particleContainer;
	public Button skill_earthShake;
	public ParticlePool particlePool;

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
		skill_earthShake.onClick.AddListener (ActivateSkill_1);
	}

	void GameEvent_onEarthShakeE ()
	{
		Debug.Log ("SKILL EARTH SHAKE");
	}

	void ActivateSkill_1()
	{
		GameEvent.OnEarthShake ();
	}

	void GameEvent_onAddScoreE (int score)
	{
		currentScore += score;
		scoreText.text += "\n" + currentScore.ToString ();
		resultScoreText.text = currentScore.ToString ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			GameEvent.OnAddScore (1);
			GameEvent.OnTouchPeople (true);
			StartCoroutine (PlayParticle (true));
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			GameEvent.OnTouchPeople (false);
			StartCoroutine (PlayParticle (false));
		}
	}

	void GameEvent_onTouchPeopleE (bool isRight)
	{
		StartCoroutine (PlayParticle (isRight));
		Debug.Log ("play particle");

	}
	IEnumerator PlayParticle(bool isRight)
	{
		Vector3 particlePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		ParticleSystem particle = particlePool.GetAvailableParticle(isRight);
		particle.gameObject.transform.position = new Vector3 (particlePosition.x, particlePosition.y, particleContainer.transform.position.z);
		particle.gameObject.SetActive (true);
		particle.Play ();
		yield return new WaitForSeconds (1);
		particle.Stop ();
		particle.gameObject.SetActive (false);
	}
}
