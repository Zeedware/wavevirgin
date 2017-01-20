using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class VirginController : MonoBehaviour {

	private Vector2[] edgePosition = new Vector2[] {
		new Vector2(-10, -2.448951f),
		new Vector2(10, -2.448951f),
	};

	public VirginManager virginManager;
	public float virginSpeed;
	public Transform virginTransform;
	public Rigidbody2D virginRigidbody;
	public Style style;
	public bool isDragged;
	public bool isDraggedBegin;

	public Vector3 mouseBeginPosition;
	public Vector3 mousePosition;

	public void Awake() {
		SpawnInitial();
		style.Init(virginManager.GetVirginCounter());
	}

	public void SpawnInitial() {
		virginTransform.position = new Vector3 (Random.Range(-10f, 10f), -2.448951f, Random.Range(0, 2f));
		virginRigidbody.velocity = new Vector2 (Random.Range(-3f, 3f) * Random.Range(0, 2) == 0 ? -1 : 1, 0);
		style.RandomizeStyle();
	}

	public void SpawnEdge() {
		bool isEdgeLeft = Random.Range(0, 2) == 0;
		virginRigidbody.velocity = new Vector2(3 * (isEdgeLeft ? 1 : -1), 0);
		virginTransform.position = edgePosition[isEdgeLeft ? 0 : 1] + new Vector2(Random.Range(-1f, 1f), 0);
		style.RandomizeStyle();
	}

	public void Update() {
		if (isDragged) {
			mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, mousePosition.z);
			virginTransform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		}
	}

	public void OnBeginDrag(BaseEventData data) {
		isDraggedBegin = true;
		mousePosition = Input.mousePosition;
		mousePosition.z = virginTransform.position.z + 10;
	}

	public void OnDrag(BaseEventData data) {
		if (isDraggedBegin && (mouseBeginPosition - Input.mousePosition).sqrMagnitude > 10) {
			isDraggedBegin = false;
			isDragged = true;
			virginRigidbody.velocity = Vector3.zero;
		} 
	}

	public void OnEndDrag(BaseEventData data) {
		isDragged = false;
	}

	public void OnPointerClick(BaseEventData data) {
		if (!isDragged) {

		}
	}
}
