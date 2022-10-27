using UnityEngine;

public class MoveToBall : MonoBehaviour
{
    public static MoveToBall instance;

    public Rigidbody2D rb2d;
    
    public float speedBall;
    
    public float speedDribble;
    
    public float speedLogical;
    
    public float reasonableDrag;
    
    public float increaseDrag;
    
    private void Awake()
    {
        instance = this;
    }
}
