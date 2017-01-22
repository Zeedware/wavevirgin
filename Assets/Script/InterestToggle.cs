using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InterestToggle : MonoBehaviour {

    public GameMode gameMode;
    public Text gameModeText;

	public void OnValueChanged(bool isOn)
    {
        if (isOn)
        {
            VirginManager.Instance.ChangeGameMode(gameMode);
            gameModeText.color = Color.white;
        } else
        {

            gameModeText.color = Color.black;

        }

    }
}
