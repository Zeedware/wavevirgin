using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class VirginController : MonoBehaviour {

    AudioManager audioManager;

	public const float maxArea = 13f;
	public const float maxSpeed = 2f;
	public const float minSpeed = 0.75f;
	public bool isPhoto;

	private Vector2[] edgePosition = new Vector2[] {
		new Vector2(-maxArea, -3.073636f),
		new Vector2(maxArea, -3.073636f),
	};

	public VirginManager virginManager;
	public float virginSpeed;
	public Animator virginAnimator;
	public Transform virginTransform;
	public Rigidbody2D virginRigidbody;
	public Transform styleTransform;
	public Style style;
	public bool isDragged;
	public bool isDraggedBegin;

	public Vector3 mouseBeginPosition;
	public Vector3 mousePosition;
	private Vector3 oldVelocity;

	public BoxCollider2D virginCollider;
	public bool isActive;
	public float forceAmount;

	public void Init(VirginManager virginManager) {
		this.virginManager = virginManager;
	}

	public void Start() {
		if (isPhoto) {
			style.InitPhoto();

		} else {
			SpawnInitial();
			style.Init(virginManager.GetVirginCounter());
		}
	}

	public bool IsRight(Style style) {
		return this.style == style;
	}

	public void RandomizePhoto() {
		style.RandomizePhoto();
	}

	public void SetPhotoOrder(int order) {
		style.SetOrder(order);
	}

	public void SpawnInitial() {
		virginCollider.enabled = true;
		virginRigidbody.isKinematic = false;
		isActive = true;
		bool isEdgeLeft = Random.Range(0, 2) == 0;
		styleTransform.localScale = new Vector3((isEdgeLeft ? -1 : 1), 1, 1);
		virginTransform.localEulerAngles = Vector3.zero;

		virginTransform.position = new Vector3 (Random.Range(-maxArea, maxArea), -2.79851f, Random.Range(0, 2f));
		virginRigidbody.velocity = new Vector2 (Random.Range(0, maxSpeed) * (isEdgeLeft ? 1 : -1), 0);
		style.RandomizeStyle();

		virginAnimator.speed = Random.Range(0.25f, 0.75f);
		oldVelocity = virginRigidbody.velocity;
		TriggerWalk();
	}

	public void SpawnEdge() {
		virginCollider.enabled = true;
		virginRigidbody.isKinematic = false;
		isActive = true;
		bool isEdgeLeft = Random.Range(0, 2) == 0;
		styleTransform.localScale = new Vector3((isEdgeLeft ? -1 : 1), 1, 1);
		virginTransform.localEulerAngles = Vector3.zero;

		virginRigidbody.velocity = new Vector2(Random.Range(minSpeed, maxSpeed) * (isEdgeLeft ? 1 : -1), 0);
		virginTransform.position = edgePosition[isEdgeLeft ? 0 : 1] + new Vector2(Random.Range(-1f, 1f), 0);
		style.RandomizeStyle();
		virginAnimator.speed = Random.Range(0.25f, 0.75f);
		oldVelocity = virginRigidbody.velocity;
		TriggerWalk();
	}

	public void Update() {
		if (!isPhoto) {
			if (isDragged) {
				mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, mousePosition.z);
				virginTransform.position = Camera.main.ScreenToWorldPoint(mousePosition);
			}

			if (Input.GetKeyDown (KeyCode.F))
				virginRigidbody.AddForce (new Vector2 (100, 0), ForceMode2D.Force);
		}
	}

	public void OnBeginDrag(BaseEventData data) {
		if (!isPhoto && EventSystem.current.IsPointerOverGameObject()) {
			isDraggedBegin = true;
			mousePosition = Input.mousePosition;
			mousePosition.z = virginTransform.position.z + 10;
            //mouseBeginPosition = Input.mousePosition;
            if (style.styleClass == 0)
            {
                AudioManager.Instance.playSfx("cewekbuang");
            }
            else if (style.styleClass == 1)
            {
                AudioManager.Instance.playSfx("priabuang");
            }
            else if (style.styleClass == 2)
            {
                AudioManager.Instance.playSfx("ombuang");
            }
            else if (style.styleClass == 3)
            {
                AudioManager.Instance.playSfx("tantebuang");
            }
        }
	}

	public void OnDrag(BaseEventData data) {
		if (!isPhoto && EventSystem.current.IsPointerOverGameObject()) {
			if (isDraggedBegin && (mouseBeginPosition - Input.mousePosition).sqrMagnitude > 10f) {
				isDraggedBegin = false;
				isDragged = true;
				virginRigidbody.velocity = Vector3.zero;
				mousePosition = Input.mousePosition;
				mousePosition.z = virginTransform.position.z + 10;
			} 
		}
	}

	public void OnEndDrag(BaseEventData data) {
		if (!isPhoto && EventSystem.current.IsPointerOverGameObject() && isDragged) {
			isActive = false;
			isDragged = false;
			Vector3 newMousePosition = Input.mousePosition - mousePosition;
			virginRigidbody.AddForce (new Vector2 (newMousePosition.x * forceAmount, newMousePosition.y*forceAmount), ForceMode2D.Force);
        }
	}

	public void OnPointerClick(BaseEventData data) {
		if (!isPhoto && EventSystem.current.IsPointerOverGameObject() && isActive) {
			if (!isDragged) {
				if (GameController.Instance.IsRight(style)) {
					OnCorrect();

				} else {
					OnWrong();
				}
			}
		}
	}

	public void OnCorrect() {
		isActive = false;
		virginAnimator.SetTrigger("Correct");
        if (style.styleClass==0)
        {
            AudioManager.Instance.playSfx("cewekcorrect");
        }else if (style.styleClass == 1)
        {
            AudioManager.Instance.playSfx("priacorrect");
        }
        
		PhoneCameraController.Instance.SwipeLeft();
		GameEvent.OnTouchPeople(true);
	}

	public void OnWrong() {
		isActive = false;
		virginAnimator.SetTrigger("Wrong");
        if (style.styleClass == 0)
        {
            AudioManager.Instance.playSfx("cewekwrong");
        }
        else if (style.styleClass == 1)
        {
            AudioManager.Instance.playSfx("priawrong");
        }
        else if (style.styleClass == 2)
        {
            AudioManager.Instance.playSfx("omwrong");
        }
        else if (style.styleClass == 3)
        {
            AudioManager.Instance.playSfx("tantewrong");
        }
		PhoneCameraController.Instance.SwipeRight();
		GameEvent.OnTouchPeople(false);
	}

	public void OnCorrectAnimation() {
		virginAnimator.speed = 1;
		SpawnEdge();
	}

	public void OnWrongAnimation() {
		virginAnimator.speed = 1;
		SpawnEdge();
	}

	public void TriggerInitialEarthquake(Style style) {
		oldVelocity = virginRigidbody.velocity;
		virginRigidbody.velocity = Vector3.zero;
		TriggerEarthquake(style);
	}

	public void TriggerEarthquake(Style style) {
		if (!isActive) {
			return;
		}

		if (style == this.style) {
			virginCollider.enabled = true;
			virginRigidbody.isKinematic = false;
			virginAnimator.SetTrigger("Survive");

		} else {
			virginCollider.enabled = false;
			virginRigidbody.isKinematic = true;
			virginAnimator.SetTrigger("Earthquake");
		}
	}

	public void TriggerWalk() {
		if (!isActive) {
			return;
		}

		virginRigidbody.velocity = oldVelocity;
		virginAnimator.SetTrigger ("Walk");
		virginCollider.enabled = true;
		virginRigidbody.isKinematic = false;
	}

	public void ChangeGameMode() {
		style.RandomizeStyle();
	}
}
