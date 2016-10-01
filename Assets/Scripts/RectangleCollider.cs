using UnityEngine;

[ExecuteInEditMode]
public class RectangleCollider : MonoBehaviour {

	public float width;
	public float height;

	private EdgeCollider2D edgeCollider;

	void Start() {
		edgeCollider = GetComponent<EdgeCollider2D>();
		if (edgeCollider == null)
			AddColliderToGameObject();
		GenerateCollider();
	}

	// Generating on update is useful for editing collider by hand, this method should not execute during play mode.
#if UNITY_EDITOR
	void Update() {
		if (!Application.isPlaying) {
			if (edgeCollider == null)
				AddColliderToGameObject();
			GenerateCollider();
		}
	}
#endif

	private void AddColliderToGameObject() {
		edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
	}

	private void GenerateCollider() {
		Vector2[] points = new Vector2[5];
		points[0] = new Vector2(-width/2, -height/2);
		points[1] = new Vector2(width/2, -height/2);
		points[2] = new Vector2(width/2, height/2);
		points[3] = new Vector2(-width/2, height/2);
		points[4] = new Vector2(-width/2, -height/2);
		edgeCollider.points = points;
	}
}
