using UnityEngine;
using UnityEngine.Events;
public class DetectZRotationOverUnder : MonoBehaviour
{
    private enum Position
    {
        BETWEEN,
        OVER,
        BELOW
    }
    
    [SerializeField] private float upperLimit;
    [SerializeField] private float lowerLimit;

    [SerializeField] private UnityEvent onOverUpperLimit;
    [SerializeField] private UnityEvent onBelowLowerLimit;
    [SerializeField] private UnityEvent onBetweenLimits;

    private Position currentPosition;
    
    void Start()
    {
        Debug.Assert(upperLimit > lowerLimit, "Please make sure that upperLimit is bigger than lowerLimit");
        ChangeCurrentPosition(DeterminePosition());
    }
    
    void Update()
    {
        Position nextPosition = DeterminePosition();
        if (currentPosition != nextPosition)
        {
            ChangeCurrentPosition(nextPosition);
        }
    }

    private float ClampAngle(float angle)
    {
        angle %= 360;
        angle -= angle > 180 ? 360 : 0;
        return angle;
    }
    
    private Position DeterminePosition()
    {
        Position nextPosition;
        float zAngle = ClampAngle(transform.rotation.eulerAngles.z);
        if (zAngle >= upperLimit)
        {
            nextPosition = Position.OVER;
        }
        else if (zAngle <= lowerLimit)
        {
            nextPosition = Position.BELOW;
        }
        else
        {
            nextPosition = Position.BETWEEN;
        }
        return nextPosition;
    }

    private void ChangeCurrentPosition(Position nextPosition)
    {
        switch (nextPosition)
        {
            case Position.OVER:
                onOverUpperLimit.Invoke();
                break;
            case Position.BETWEEN:
                onBetweenLimits.Invoke();
                break;
            case Position.BELOW:
                onBelowLowerLimit.Invoke();
                break;
        }
        currentPosition = nextPosition;
    }
}
