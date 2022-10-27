using UnityEngine;

public class ControlMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float speedProtectBall;

    public float normalSpeed;

    public float rotationSpeed;

    protected float speed;
    protected float leftRight;
    protected float upDown;
    protected Quaternion lastRotation; // with Player has been inherited, this set to < 100 

    public bool toBall;
    public bool isTouching;
    public bool isDirecting;
    public bool isNotMoving;

    public Transform check; // check ball direction
    public SpriteRenderer spriteDirection;
}
