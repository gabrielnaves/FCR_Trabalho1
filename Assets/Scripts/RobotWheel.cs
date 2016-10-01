using UnityEngine;

public class RobotWheel : MonoBehaviour {

    public float angularSpeed = 0f;

    public void UpdateSpeed(float speed) {
        angularSpeed = speed;
    }
}
