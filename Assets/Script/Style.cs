using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Style {

	public const int maxStyle = 15;

	public int styleType;
	public GameObject[] normalGameObject;
	public GameObject[] activeGameObject;
	public GameObject[] profileGameObject;

	public SpriteRenderer[] normalSpriteRenderer;
	public SpriteRenderer[] activeSpriteRenderer;
	public SpriteRenderer[] profileSpriteRenderer;

	public void Init(int orderInLayer) {
		for (int i = 0; i < maxStyle; ++i) {
			normalSpriteRenderer[i].sortingOrder = orderInLayer;
			activeSpriteRenderer[i].sortingOrder = orderInLayer;
			profileSpriteRenderer[i].sortingOrder = orderInLayer;
		}
	}

	public void RandomizeStyle() {
		styleType = Random.Range(0, maxStyle);

		for (int i = 0; i < maxStyle; ++i) {
			normalGameObject[i].SetActive(i == styleType);
			activeGameObject[i].SetActive(i == styleType);
			profileGameObject[i].SetActive(i == styleType);
		}
	}

	public void SetStyle() {

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
