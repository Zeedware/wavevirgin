using UnityEngine;
using System.Collections;

public class VirginPhoto : MonoBehaviour {

	private const float HIDE_TIME = 1f / 0.25f;

	public Vector3[] photoStartPosition;
	public Transform virginTransform;

	public int photoID;
	public VirginController virginController;
	public SpriteRenderer spriteRenderer;

	private bool isMoving;
	private bool isAdded;

	private void Awake() {
		RandomizeTarget();
	}

	public void RandomizeTarget() {
		virginController.RandomizePhoto();
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
		if (photoID < 0) {
			RandomizeTarget();
		}

		spriteRenderer.sortingOrder = (photoID * 2 + 0);
		virginController.SetPhotoOrder(photoID * 2 + 1);

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
		if (photoID + 1 >= 3) {
			RandomizeTarget();
		}

		photoID = (photoID + 1) % 3;
		Vector3 startPosition = virginTransform.localPosition;

		spriteRenderer.sortingOrder = (photoID * 2 + 0);
		virginController.SetPhotoOrder(photoID * 2 + 1);

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
		return virginController.IsRight(style);
	}
}
