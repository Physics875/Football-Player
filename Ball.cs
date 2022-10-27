using UnityEngine;

public class MoveToBall : MonoBehaviour
{
    public static MoveToBall instance;

    public Rigidbody2D rb2d;
    
    public float speedBall; // 100f
    
    public float speedDribble; // 5f
    
    public float speedLogical; // 5f
    
    public float reasonableDrag; // 5f
    
    public float increaseDrag; // 0.2f
    
    private void Awake()
    {
        instance = this;
    }
}
