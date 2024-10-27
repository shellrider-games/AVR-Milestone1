using UnityEngine;

public class ControllableBetween2Points : MonoBehaviour
{
    private enum Direction
    {
        FORWARD,
        NEUTRAL,
        BACKWARD
    }
    
    [SerializeField][Range(0,1)] private float speed;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    private float t;
    private Direction currentDirection;
    
    private void Start()
    {
        t = 0.5f;
        transform.position = Vector3.Lerp(point1.position, point2.position, t);
        currentDirection = Direction.NEUTRAL;
    }
    
    private void Update()
    {
        if(currentDirection == Direction.NEUTRAL) {return;}
        float scale = 1f;
        if (currentDirection == Direction.BACKWARD) { scale *= -1; }
        t = Mathf.Clamp(t + speed * scale * Time.deltaTime, 0f, 1f);
        transform.position = Vector3.Lerp(point1.position, point2.position, t);
    }
    
    public void ChangeCurrentDirectionForward()
    {
        currentDirection = Direction.FORWARD;
    }
    public void ChangeCurrentDirectionBackwards()
    {
        currentDirection = Direction.BACKWARD;
    }
    public void ChangeCurrentDirectionForwardNeutral()
    {
        currentDirection = Direction.NEUTRAL;
    }
    
}
