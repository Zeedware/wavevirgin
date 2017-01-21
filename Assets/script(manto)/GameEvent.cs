using UnityEngine;
using System.Collections;

public class GameEvent {

	public delegate void OnAddScore_Handler(int score);
	public static event OnAddScore_Handler onAddScoreE;
	public static void OnAddScore(int score)
	{
		if (onAddScoreE != null)
			onAddScoreE (score);		
	}

	public delegate void OnEartShake_Handle();
	public static event OnEartShake_Handle onEarthShakeE;
	public static void OnEarthShake()
	{
		if (onEarthShakeE != null)
			onEarthShakeE ();		
	}

	public delegate void OnTouchPeople_Handle(bool isRight);
	public static event OnTouchPeople_Handle onTouchPeopleE;
	public static void OnTouchPeople(bool isRight)
	{
		if (onTouchPeopleE != null)
			onTouchPeopleE (isRight);
	}

}
