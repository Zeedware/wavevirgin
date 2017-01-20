using UnityEngine;
using System.Collections;

public class PhoneController : MonoBehaviour {

	private const float HIDE_TIME = 1f / 0.5f;

	public Vector3 showPosition;
	public Vector3 hidePosition;
	private Transform phoneTransform;

	private bool isShowing;
	private bool isHiding;

	private void Awake() {
		phoneTransform = transform;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			TriggerShowPhone();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			TriggerHidePhone();
		}
	}

	public void TriggerShowPhone() {
		StartCoroutine(ShowPhone());
	}

	private IEnumerator ShowPhone() {
		isShowing = true;
		yield return null;
		Vector3 startPosition = phoneTransform.localPosition;
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * HIDE_TIME) {
			if (isHiding) {
				isShowing = false;
				yield break;
			}

			phoneTransform.localPosition = Mathfx.EaseOutCubic(startPosition, showPosition, i);
			yield return null;
		}

		isShowing = false;
		phoneTransform.localPosition = showPosition;
	}

	public void TriggerHidePhone() {
		StartCoroutine(HidePhone());
	}

	public IEnumerator HidePhone() {
		isHiding = true;
		yield return null;
		Vector3 startPosition = phoneTransform.localPosition;
		for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * HIDE_TIME) {
			if (isShowing) {
				isHiding = false;
				yield break;
			}

			phoneTransform.localPosition = Mathfx.EaseOutCubic(startPosition, hidePosition, i);
			yield return null;
		}

		isHiding = false;
		phoneTransform.localPosition = hidePosition;
	}
}
