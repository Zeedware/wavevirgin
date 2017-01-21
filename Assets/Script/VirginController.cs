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
		new Vector2(-maxArea, -2.448951f),
		new Vector2(maxArea, -2.448951f),
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

	public float forceAmount;

	public void Awake() {
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
		bool isEdgeLeft = Random.Range(0, 2) == 0;
		styleTransform.localScale = new Vector3((isEdgeLeft ? -1 : 1), 1, 1);
		virginTransform.localEulerAngles = Vector3.zero;

		virginTransform.position = new Vector3 (Random.Range(-maxArea, maxArea), -2.79851f, Random.Range(0, 2f));
		virginRigidbody.velocity = new Vector2 (Random.Range(0, maxSpeed) * (isEdgeLeft ? 1 : -1), 0);
		style.RandomizeStyle();

		virginAnimator.speed = Random.Range(0.25f, 0.75f);
		virginAnimator.SetTrigger("Walk");
	}

	public void SpawnEdge() {
		bool isEdgeLeft = Random.Range(0, 2) == 0;
		styleTransform.localScale = new Vector3((isEdgeLeft ? -1 : 1), 1, 1);
		virginTransform.localEulerAngles = Vector3.zero;

		virginRigidbody.velocity = new Vector2(Random.Range(minSpeed, maxSpeed) * (isEdgeLeft ? 1 : -1), 0);
		virginTransform.position = edgePosition[isEdgeLeft ? 0 : 1] + new Vector2(Random.Range(-1f, 1f), 0);
		style.RandomizeStyle();
		virginAnimator.speed = Random.Range(0.25f, 0.75f);
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
			mouseBeginPosition = Input.mousePosition;
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
		if (!isPhoto && EventSystem.current.IsPointerOverGameObject()) {
			isDragged = false;
//			Debug.Log ("mouse position : " + mousePosition);
//			Debug.Log ("new mouse position : " + Input.mousePosition);
			Vector3 newMousePosition = Input.mousePosition - mousePosition;
//			Debug.Log ("new delta mouse position : " + newMousePosition);
			virginRigidbody.AddForce (new Vector2 (newMousePosition.x * forceAmount, newMousePosition.y*forceAmount), ForceMode2D.Force);

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

	public void OnPointerClick(BaseEventData data) {
		if (!isPhoto && EventSystem.current.IsPointerOverGameObject()) {
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
		virginAnimator.SetTrigger("Correct");
        if (style.styleClass==0)
        {
            AudioManager.Instance.playSfx("cewekcorrect");
        }else if (style.styleClass == 1)
        {
            AudioManager.Instance.playSfx("priacorrect");
        }
        
	}

	public void OnWrong() {
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
    }

	public void OnCorrectAnimation() {
		virginAnimator.speed = 1;
		SpawnEdge();
	}

	public void OnWrongAnimation() {
		virginAnimator.speed = 1;
		SpawnEdge();
	}
}
