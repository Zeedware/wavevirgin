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
	public GameplayUIController gameplayUI;
	public SatisifactionController satisfaction;
	public GameObject mainMenu, gamePlay, gameOver;
	public Button playButton, quitButton, playAgainButton, mainMenuButton;

	void Start()
	{
		
		mainMenuButton.onClick.AddListener (GotoMainMenu);
		playButton.onClick.AddListener (GotoGamePlay);
		playButton.onClick.AddListener (GotoGamePlay);
		playAgainButton.onClick.AddListener (GotoGamePlay);
		quitButton.onClick.AddListener (Quit);

		GotoMainMenu ();
	}

	void GotoMainMenu()
	{
		GotoView (VIEW_STATE.MAIN_MENU);
	}
	void GotoGamePlay()
	{
		gameplayUI.RestartGameplay ();
		satisfaction.ResetAllValue ();
		GotoView (VIEW_STATE.GAMEPLAY);
	}

	void GotoGameOver()
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
			mainMenu.SetActive (false);
			gamePlay.SetActive (true);
			gameOver.SetActive (false);
			break;
		case VIEW_STATE.GAMEOVER:
			mainMenu.SetActive (false);
			gamePlay.SetActive (false);
			gameOver.SetActive (true);
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

