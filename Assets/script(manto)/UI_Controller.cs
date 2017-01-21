using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Controller : MonoBehaviour {

	static UI_Controller _instance;
	public static UI_Controller Instance{
		get{ 
			if (!_instance)
				_instance = FindObjectOfType<UI_Controller> ();
			return _instance;
		}
	}

	public GameObject mainMenu, gamePlay, gameOver;
	public Button playButton, quitButton, playAgainButton, mainMenuButton;

	void Start()
	{
		
		playButton.onClick.AddListener (GotoMainMenu);
		mainMenuButton.onClick.AddListener (GotoMainMenu);
		playButton.onClick.AddListener (GotoGamePlay);
		playAgainButton.onClick.AddListener (GotoGamePlay);

		quitButton.onClick.AddListener (Quit);
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.G))
			GotoMainMenu ();
		if (Input.GetKeyDown (KeyCode.H))
			GotoGamePlay ();
		if (Input.GetKeyDown (KeyCode.I))
			GotoGameOver ();
	}
	void GotoMainMenu()
	{
		GotoView (VIEW_STATE.MAIN_MENU);
	}
	void GotoGamePlay()
	{
		GotoView (VIEW_STATE.GAMEPLAY);
	}void GotoGameOver()
	{
		GotoView (VIEW_STATE.GAMEOVER);
	}

	void Quit()
	{
		Application.Quit ();
	}

	public void GotoView (VIEW_STATE state)
	{
		switch (state) {
		case VIEW_STATE.MAIN_MENU:
			mainMenu.SetActive (true);
			gamePlay.SetActive (false);
			gameOver.SetActive (false);
			break;
		case VIEW_STATE.GAMEPLAY:
			mainMenu.SetActive (true);
			gamePlay.SetActive (false);
			gameOver.SetActive (false);
			break;
		case VIEW_STATE.GAMEOVER:
			mainMenu.SetActive (true);
			gamePlay.SetActive (false);
			gameOver.SetActive (false);
			break;
			
		}
	}

}

public enum VIEW_STATE
{
	MAIN_MENU,
	GAMEPLAY,
	GAMEOVER,
}

