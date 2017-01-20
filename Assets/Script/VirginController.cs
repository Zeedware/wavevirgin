using UnityEngine;
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
}
