using UnityEngine;
using System.Collections;

public class VirginPhoto : MonoBehaviour {

	private const float HIDE_TIME = 1f / 0.5f;

	public Vector3[] photoStartPosition;
	public Transform virginTransform;

	public int photoID;
	public Style style;

	public SpriteRenderer[] spriteRenderer;

	private bool isMoving;
	private bool isAdded;

	public void RandomizeTarget() {
		style.RandomizeStyle();
	}

	public void TriggerSwipeLeft() {
		StartCoroutine(SwipeLeft());
	}

	private IEnumerator SwipeLeft() {
		if (isMoving) {
			isAdded = true;
			yield return null;

		} else {
			isMoving = true;
		}

		Vector3 startPosition = virginTransform.localPosition;
		photoID = photoID - 1;

		for (int i = 0; i < 3; ++i) {
			spriteRenderer[i].sortingOrder = photoID * 3 + i;
		}

		photoID = (photoID + 3) % 3;

		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * HIDE_TIME) {
			if (isAdded) {
				isAdded = false;
				yield break;
			}

			virginTransform.localPosition = Mathfx.EaseOutCubic(startPosition, photoStartPosition[photoID], i);
			yield return null;
		}

		isMoving = false;
		virginTransform.localPosition = photoStartPosition[photoID];
	}

	public void TriggerSwipeRight() {
		StartCoroutine(SwipeRight());
	}

	public IEnumerator SwipeRight() {
		if (isMoving) {
			isAdded = true;
			yield return null;

		} else {
			isMoving = true;
		}

		yield return null;
		photoID = (photoID + 1) % 3;
		Vector3 startPosition = virginTransform.localPosition;

		for (int i = 0; i < 3; ++i) {
			spriteRenderer[i].sortingOrder = photoID * 3 + i;
		}

		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * HIDE_TIME) {
			if (isAdded) {
				isAdded = false;
				yield break;
			}

			virginTransform.localPosition = Mathfx.EaseOutCubic(startPosition, photoStartPosition[photoID], i);
			yield return null;
		}

		isMoving = false;
		virginTransform.localPosition = photoStartPosition[photoID];
	}

	public bool IsRight(Style style) {
		return this.style == style;
	}
}
