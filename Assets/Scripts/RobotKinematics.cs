using UnityEngine;

/// <summary>
/// Moves the robot according to the speed on each wheel.
/// </summary>
/// The equations used here were taken from the "Kinematics.pdf" file. This file can
/// be found on the "Reference Material" folder in this project.
public class RobotKinematics : MonoBehaviour {

    public float angSpeedWheel1 = 0f;
    public float angSpeedWheel2 = 0f;
    public float angSpeedWheel3 = 0f;
    public float wheelRadius = 0.1f;
    public float wheelDistanceToCenter = 0.2f;


    private Rigidbody2D rigidBody2d;

    void Start () {
        rigidBody2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate() {
        float xSpeed;
        float ySpeed;
        float angularSpeed;

        xSpeed = -(1 / Mathf.Sqrt(3)) * wheelRadius * angSpeedWheel2 +
                  (1 / Mathf.Sqrt(3)) * wheelRadius * angSpeedWheel3;

        ySpeed = -(2f / 3f) * wheelRadius * angSpeedWheel1 +
                  (1f / 3f) * wheelRadius * angSpeedWheel2 +
                  (1f / 3f) * wheelRadius * angSpeedWheel3;

        angularSpeed = (wheelRadius / (3 * wheelDistanceToCenter)) * angSpeedWheel1 +
                       (wheelRadius / (3 * wheelDistanceToCenter)) * angSpeedWheel2 +
                       (wheelRadius / (3 * wheelDistanceToCenter)) * angSpeedWheel3;

        rigidBody2d.velocity = new Vector2(xSpeed, ySpeed);
        rigidBody2d.angularVelocity = angularSpeed;
    }
}
