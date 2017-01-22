using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Style {

	public const int maxStyle = 22;

	public int styleType;
    public int styleClass;
    public enum classType { cewek=0, pria=1, om=2, tante=3, goat=4 };

    public GameObject[] styleGameObject;

	public GameObject[] normalGameObject;
	public GameObject[] activeGameObject;
	public GameObject[] profileGameObject;

	private SpriteRenderer[] normalSpriteRenderer;
	private SpriteRenderer[] activeSpriteRenderer;
	private SpriteRenderer[] profileSpriteRenderer;

	public void Init(int orderInLayer) {
		normalSpriteRenderer = new SpriteRenderer[maxStyle];
		activeSpriteRenderer = new SpriteRenderer[maxStyle];
		profileSpriteRenderer = new SpriteRenderer[maxStyle];

		for (int i = 0; i < maxStyle; ++i) {
			normalSpriteRenderer[i] = normalGameObject[i].GetComponent<SpriteRenderer>();
			activeSpriteRenderer[i] = activeGameObject[i].GetComponent<SpriteRenderer>();
			profileSpriteRenderer[i] = profileGameObject[i].GetComponent<SpriteRenderer>();

			normalSpriteRenderer[i].sortingOrder = orderInLayer;
			activeSpriteRenderer[i].sortingOrder = orderInLayer;
			profileSpriteRenderer[i].sortingOrder = orderInLayer;
		}
	}

	public void InitPhoto() {
		normalSpriteRenderer = new SpriteRenderer[maxStyle];
		activeSpriteRenderer = new SpriteRenderer[maxStyle];
		profileSpriteRenderer = new SpriteRenderer[maxStyle];

		for (int i = 0; i < maxStyle; ++i) {
			normalSpriteRenderer[i] = normalGameObject[i].GetComponent<SpriteRenderer>();
			activeSpriteRenderer[i] = activeGameObject[i].GetComponent<SpriteRenderer>();
			profileSpriteRenderer[i] = profileGameObject[i].GetComponent<SpriteRenderer>();
		}
	}

    private void setStyleClass(int input)
    {
        if (input <= 9)
        {
            styleClass = 0;

        }
        else if (input <= 14)
        {
            styleClass = 1;
        }
        else if (input <= 17)
        {
            styleClass = 2;
		}
		else if (input <= 21)
		{
			styleClass = 3;
		}
		else if (input <= maxStyle)
		{
			styleClass = 4;
		}
    }

	private void SetStyleType() {
		if (VirginManager.Instance.gameMode == GameMode.Normal) {
			styleType = Random.Range(0, 21);
		} else if (VirginManager.Instance.gameMode == GameMode.Girl) {
			styleType = Random.Range(0, 10);
		} else if (VirginManager.Instance.gameMode == GameMode.GirlBoy) {
			styleType = Random.Range(0, 15);
		} else if (VirginManager.Instance.gameMode == GameMode.GirlBoyOldies) {
			styleType = Random.Range(0, 21);
		} else if (VirginManager.Instance.gameMode == GameMode.GirlBoyOldiesGoat) {
			styleType = Random.Range(0, 22);
		} 
	}

	public void RandomizeStyle() {
		SetStyleType();

        setStyleClass(styleType);

        for (int i = 0; i < maxStyle; ++i) {
			styleGameObject[i].SetActive(i == styleType);

			normalGameObject[i].SetActive(i == styleType);
			activeGameObject[i].SetActive(false);
			profileGameObject[i].SetActive(false);
		}
	}

	public void RandomizePhoto() {
		if (VirginManager.Instance.gameMode == GameMode.Girl) {
			styleType = Random.Range(0, 10);

		} else {
			styleType = Random.Range(0, 14);
		}

        setStyleClass(styleType);

        for (int i = 0; i < maxStyle; ++i) {
			styleGameObject[i].SetActive(i == styleType);

			normalGameObject[i].SetActive(false);
			activeGameObject[i].SetActive(false);
			profileGameObject[i].SetActive(i == styleType);
		}
	}

	public void SetOrder(int order) {
		profileSpriteRenderer[styleType].sortingOrder = order;
	}

	public static bool operator ==(Style x, Style y) {
		return x.styleType == y.styleType;
	}

	public static bool operator !=(Style x, Style y) {
		return x.styleType != y.styleType;
	}

	public override bool Equals(object o) 
	{
		try {
			return this == (Style) o;

		} catch  {
			return false;
		}
	}

	public override int GetHashCode() {
		return 4;
	}

}
