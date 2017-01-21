using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Style {

	public const int maxStyle = 21;

	public int styleType;
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

	public void RandomizeStyle() {
		styleType = Random.Range(0, maxStyle);

		for (int i = 0; i < maxStyle; ++i) {
			styleGameObject[i].SetActive(i == styleType);

			normalGameObject[i].SetActive(i == styleType);
			activeGameObject[i].SetActive(false);
			profileGameObject[i].SetActive(false);
		}
	}

	public void RandomizePhoto() {
		styleType = Random.Range(0, maxStyle);

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
