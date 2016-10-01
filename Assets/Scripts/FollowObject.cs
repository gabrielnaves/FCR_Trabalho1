using UnityEngine;

/// <summary> Makes an object follow a given object at a given offset value. </summary>
public class FollowObject : MonoBehaviour
{
    public GameObject followed;
    public Vector3 offset;

    private Vector3 followedPos;

    void Start() {
        UpdatePosition();
    }

    void Update() {
        UpdatePosition();
    }

    void UpdatePosition() {
        if (followed != null) {
            followedPos = followed.transform.position;
            transform.position = followedPos + offset;
        }
    }
}