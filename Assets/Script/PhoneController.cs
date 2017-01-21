using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PhoneController : MonoBehaviour {

	private static PhoneController instance;

	public static PhoneController Instance {
		get {
			return instance;
		}
	}

	private void Awake() {
		instance = this;
		phoneTransform = transform;
	}

	private const float HIDE_TIME = 1f / 0.25f;

	public Animator phoneAnimator;
	public Vector3 showPosition;
	public Vector3 hidePosition;
	private Transform phoneTransform;
	public PhoneCameraController phoneCameraController;

	private bool isShowing;
	private bool isHiding;

	private bool isUp = true;

	public bool isDragged;
	public bool isDraggedBegin;

	public Vector3 mouseBeginPosition;

	public void OnBeginDrag(BaseEventData data) {
		isDraggedBegin = true;
		mouseBeginPosition = Input.mousePosition;
	}

	public void OnDrag(BaseEventData data) {
		if (isDraggedBegin && (-Input.mousePosition).sqrMagnitude > 10f) {
			isDraggedBegin = false;
			isDragged = true;
		} 
	}

	public void OnEndDrag(BaseEventData data) {
		isDragged = false;
		if ((mouseBeginPosition - Input.mousePosition).x > 0) {
			phoneCameraController.SwipeLeft();

		} else {
			phoneCameraController.SwipeRight();
		}
	}

	private void Update() {

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			TriggerShowPhone();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			TriggerHidePhone();
		}
	}

	public void OnClick() {
		if (!isDragged) {
			if (isUp) {
				TriggerHidePhone();

			} else {
				TriggerShowPhone();
			}
		}
	}

	public void SwipeLeftAnimation() {
		phoneAnimator.SetTrigger("SwipeLeft");
	}

	public void SwipeRightAnimation() {
		phoneAnimator.SetTrigger("SwipeRight");
	}

	public void IdleAnimation() {
		phoneAnimator.SetTrigger("Idle");
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
		isUp = true;
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
		isUp = false;
	}
}
