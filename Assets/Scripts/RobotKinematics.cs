using UnityEngine;

/// <summary>
/// Moves the robot according to the speed on each wheel.
/// </summary>
/// The equations used here were taken from the "Kinematics.pdf" file. This file can
/// be found on the "Reference Material" folder in this project.
public class RobotKinematics : MonoBehaviour {

    public RobotWheel[] wheels;
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

        xSpeed = -(1 / Mathf.Sqrt(3)) * wheelRadius * wheels[1].angularSpeed +
                  (1 / Mathf.Sqrt(3)) * wheelRadius * wheels[2].angularSpeed;

        ySpeed = -(2f / 3f) * wheelRadius * wheels[0].angularSpeed +
                  (1f / 3f) * wheelRadius * wheels[1].angularSpeed +
                  (1f / 3f) * wheelRadius * wheels[2].angularSpeed;

        angularSpeed = (wheelRadius / (3 * wheelDistanceToCenter)) * wheels[0].angularSpeed +
                       (wheelRadius / (3 * wheelDistanceToCenter)) * wheels[1].angularSpeed +
                       (wheelRadius / (3 * wheelDistanceToCenter)) * wheels[2].angularSpeed;

        rigidBody2d.velocity = new Vector2(xSpeed, ySpeed);
        rigidBody2d.angularVelocity = angularSpeed;
    }
}
