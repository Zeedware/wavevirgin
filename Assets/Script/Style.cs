﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Style {

	public HairStyle hairStyle;
	public DressStyle dressStyle;

	public GameObject[] hairGameObject;
	public GameObject[] dressGameObject;

	public void Init(int orderInLayer) {
		for (int i = 0; i < (int)HairStyle.Count; ++i) {
			hairGameObject[i].GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
		}

		for (int i = 0; i < (int)DressStyle.Count; ++i) {
			dressGameObject[i].GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
		}
	}

	public void RandomizeStyle() {
		hairStyle = (HairStyle) Random.Range(0, (int) HairStyle.Count);
		dressStyle = (DressStyle) Random.Range(0, (int) DressStyle.Count);

		for (int i = 0; i < (int)HairStyle.Count; ++i) {
			hairGameObject[i].SetActive(i == (int) hairStyle);
		}

		for (int i = 0; i < (int)DressStyle.Count; ++i) {
			dressGameObject[i].SetActive(i == (int) dressStyle);
		}
	}
}