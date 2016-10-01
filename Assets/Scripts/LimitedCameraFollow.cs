using UnityEngine;

/*
 * The code for this class was taken from here:
 * http://answers.unity3d.com/questions/501893/calculating-2d-camera-bounds.html
 * 
 * NOTE: This class assumes that cameraLimits is positioned at the origin. It won't work properly otherwise.
 */
public class LimitedCameraFollow : MonoBehaviour {

	public Transform followedObject;
	public RectangleCollider cameraLimits;

	private float minX, maxX, minY, maxY;

	void Start() {
		CalculateStuff();
	}

	void Update() {
		CalculateStuff();

		Vector3 newPos = followedObject.position;
		newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
		newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
		newPos.z = -10;
		transform.position = newPos;
	}

	private void CalculateStuff() {
		float verticalExtent = GetComponent<Camera>().orthographicSize;    
		float horizontalExtent = verticalExtent * Screen.width / Screen.height;
		
		// Calculations assume map is position at the origin
		minX = horizontalExtent - cameraLimits.width / 2f;
		maxX = cameraLimits.width / 2f - horizontalExtent;
		minY = verticalExtent - cameraLimits.height / 2f;
		maxY = cameraLimits.height / 2f - verticalExtent;
	}
}
