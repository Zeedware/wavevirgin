using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SatisifactionController : MonoBehaviour {


	public Scrollbar satisfactionMeter;
	public Image satisfactionBar;
	public float satisfactionPoin , maxSatisfactionPoin, decreaseSpeed, falsePenalty, trueBonus;

	void OnEnable () {
		GameEvent.onTouchPeopleE += GameEvent_onTouchPeopleE;
	}
	void OnDisable () {
		GameEvent.onTouchPeopleE -= GameEvent_onTouchPeopleE;
	}

	void GameEvent_onTouchPeopleE (bool isRight)
	{
		if (isRight) {
			SetSatisfactionMeter (trueBonus);
			SetDecreaseSatisfactionSpeed (-0.1f);
		} else {
			SetSatisfactionMeter (falsePenalty);
			SetDecreaseSatisfactionSpeed (1f);
		}
	}
	public void ResetAllValue()
	{
		satisfactionPoin = maxSatisfactionPoin;
		SetDecreaseSatisfactionSpeed (-100f);
	}
	public void SetDecreaseSatisfactionSpeed(float value)
	{
		decreaseSpeed += value;
		decreaseSpeed = Mathf.Clamp (decreaseSpeed, 1, 100);

	}
	
	void Update () {
		satisfactionPoin -= Time.deltaTime * decreaseSpeed;
		satisfactionMeter.value = satisfactionPoin/maxSatisfactionPoin;
		satisfactionBar.fillAmount = satisfactionPoin / maxSatisfactionPoin;
		if(satisfactionMeter.value <= 0)
			UI_Controller.Instance.GotoView (VIEW_STATE.GAMEOVER);

	}

	void RefreshSatisfactionMeter()
	{
		satisfactionPoin = maxSatisfactionPoin;
	}

	public void SetSatisfactionMeter(float value)
	{
		satisfactionPoin += value;
		satisfactionPoin = Mathf.Clamp (satisfactionPoin, 0, maxSatisfactionPoin);

		if (satisfactionPoin <= 0) {
			Debug.Log ("Game Over Bruuh..");
			UI_Controller.Instance.GotoView (VIEW_STATE.GAMEOVER);
		}
	}
}
