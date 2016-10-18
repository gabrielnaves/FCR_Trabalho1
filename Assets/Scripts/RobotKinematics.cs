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

        xSpeed = Mathf.Sqrt(3)*wheelRadius*wheels[2].angularSpeed/3f -
                 Mathf.Sqrt(3)*wheelRadius*wheels[1].angularSpeed/3f;

        ySpeed = wheelRadius*wheels[1].angularSpeed/3f -
                 2*wheelRadius*wheels[0].angularSpeed/2f +
                 wheelRadius*wheels[2].angularSpeed/3f;

        angularSpeed = wheelRadius*wheels[0].angularSpeed/(3*wheelDistanceToCenter) +
                       wheelRadius*wheels[1].angularSpeed/(3*wheelDistanceToCenter) +
                       wheelRadius*wheels[2].angularSpeed/(3*wheelDistanceToCenter);

        rigidBody2d.velocity = new Vector2(xSpeed, ySpeed);
        rigidBody2d.angularVelocity = angularSpeed * Mathf.Rad2Deg;
    }
}
