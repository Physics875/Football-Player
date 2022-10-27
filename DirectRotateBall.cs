using UnityEngine;

public class DirectRotateBall : MonoBehaviour
{
    public static DirectRotateBall insDirection;
    public CMController CMRotate;

    public Vector2 movementDirection;
    public Quaternion lastRotation;
    
    private float leftRight;
    private float upDown;

    private void Awake()
    {
        insDirection = this;
    }

    private void Update()
    {
        DirectController();
        lastRotation = transform.rotation;
    }

    void DirectController()
    {
        if (CMRotate.isDirecting)
        {
            leftRight = Input.GetAxis("Horizontal");
            upDown = Input.GetAxis("Vertical");

            movementDirection = new Vector2(leftRight, upDown);

            movementDirection.Normalize();

            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);

            if (movementDirection != Vector2.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, CMRotate.rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
