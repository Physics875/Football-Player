using UnityEngine;

public class CMController : ControlMovement
{
    public MoveToBall moveBall;

    public Timer timer;

    private void Start()
    {
        toBall = true;
        isDirecting = true;
    }

    private void Update()
    {
        lastRotation = transform.rotation;

        CMMoveToBall();

        DoYouChangeDirection();
    }

    private void FixedUpdate()
    {
        ControllerTouchBall();
        FixBugAddDragInfinity();
    }

    void ControllerTouchBall()
    {
        if (!isNotMoving)
        {
            if (isTouching)
            {
                moveBall.rb2d.AddForce(check.up * moveBall.speedBall * Time.deltaTime, ForceMode2D.Impulse);
            }
            else if (!isTouching && toBall)
            {
                moveBall.rb2d.drag += moveBall.increaseDrag;

                if (rb2d.drag >= moveBall.reasonableDrag)
                {
                    moveBall.rb2d.drag = moveBall.reasonableDrag;
                }
            }
        }

        if (!toBall && !isTouching && isDirecting && !isNotMoving) // khi khong dieu khien direction va CM tien toi ball
            toBall = true;
    }

    void CMMoveToBall()
    {
        if (!isTouching && toBall)
        {
            normalSpeed -= Time.deltaTime;

            if (normalSpeed <= 1f)
            {
                normalSpeed = 2f;
            }

            transform.position = Vector2.MoveTowards(transform.position, moveBall.transform.position, normalSpeed * Time.deltaTime);
        }
    }
  
    void DoYouChangeDirection()
    {
        if (DirectRotateBall.insDirection.movementDirection == Vector2.zero)
        {
            isNotMoving = true;
            spriteDirection.enabled = false;
        }
        else
        {
            isNotMoving = false;
            spriteDirection.enabled = true;
        }
    }

    void StartTouch()
    {
        isTouching = true;
        isDirecting = true;
        toBall = false;
        
        moveBall.rb2d.drag = 5f;
        transform.rotation = DirectRotateBall.insDirection.lastRotation;
        DirectRotateBall.insDirection.transform.rotation = transform.rotation;
    }

    void CMIsMovingToBall()
    {
        isTouching = false;
        isDirecting = true;
        toBall = true;
    }

    void ChangeDirWithBall()
    {
        if (toBall && !isTouching && isDirecting && isNotMoving)
        {
            moveBall.rb2d.AddForce(check.up * moveBall.speedBall * Time.deltaTime, ForceMode2D.Impulse);
            moveBall.rb2d.drag = 5f;
            DirectRotateBall.insDirection.transform.rotation = transform.rotation;
            
            isTouching = false;
            toBall = false;
        }
    }

    void FixBugAddDragInfinity()
    {
        if (isTouching && isDirecting && isNotMoving && !toBall)
        {
            moveBall.rb2d.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !isNotMoving)
        {
            StartTouch();
        }
        if (collision.gameObject.CompareTag("Ball") && toBall && !isTouching && isDirecting && isNotMoving)
        {
            ChangeDirWithBall();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !isNotMoving)
        {
            CMIsMovingToBall();
        }
    }
}
