using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SatisifactionController : MonoBehaviour {


	public Scrollbar satisfactionMeter;
	public float satisfactionPoin , maxSatisfactionPoin, decreaseSpeed, falsePenalty, trueBonus;

	void OnEnable () {
		GameEvent.onTouchPeopleE += GameEvent_onTouchPeopleE;
	}
	void OnDisable () {
		GameEvent.onTouchPeopleE -= GameEvent_onTouchPeopleE;
	}

	void GameEvent_onTouchPeopleE (bool isRight)
	{
		if (isRight)
			SetSatisfactionMeter (trueBonus);
		else
			SetSatisfactionMeter (falsePenalty);

	}
	
	void Update () {
		satisfactionPoin -= Time.deltaTime * decreaseSpeed;
		satisfactionMeter.value = satisfactionPoin/maxSatisfactionPoin;
	}

	void RefreshSatisfactionMeter()
	{
		satisfactionPoin = maxSatisfactionPoin;
	}

	void SetSatisfactionMeter(float value)
	{
		satisfactionPoin += value;
		satisfactionPoin = Mathf.Clamp (satisfactionPoin, 0, maxSatisfactionPoin);

		if (satisfactionPoin <= 0)
			Debug.Log ("Game Over Bruuh..");
	}
}
