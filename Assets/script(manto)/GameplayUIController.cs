﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour {

	public Text scoreText;
	public int currentScore;
	public GameObject particleContainer;
	public ParticleSystem touchParticle_Right, touchParticle_False;
	public Button skill_earthShake;

	void OnEnable()
	{
		GameEvent.onAddScoreE += GameEvent_onAddScoreE;
		GameEvent.onEarthShakeE += GameEvent_onEarthShakeE;
	}


	void OnDisable()
	{
		GameEvent.onAddScoreE -= GameEvent_onAddScoreE;
		GameEvent.onEarthShakeE -= GameEvent_onEarthShakeE;

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
		scoreText.text = "Score : " + currentScore.ToString ();
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

	IEnumerator PlayParticle(bool isRight)
	{
		Vector3 particlePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		particleContainer.transform.position = new Vector3 (particlePosition.x, particlePosition.y, particleContainer.transform.position.z);
		particleContainer.SetActive (true);
		ParticleSystem particle;

		if (isRight)
			particle = touchParticle_Right;
		else
			particle = touchParticle_False;

		particle.Play ();
		yield return new WaitForSeconds (1);
		particle.Stop ();
		particleContainer.SetActive (false);
	}
}