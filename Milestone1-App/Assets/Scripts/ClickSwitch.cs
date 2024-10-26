using UnityEngine;
using UnityEngine.Events;

public class ClickSwitch : MonoBehaviour
{
    private bool isPushed;
    [SerializeField] private UnityEvent onSwitchPressed;

    public void SwitchDown()
    {
        if (!isPushed)
        {
            onSwitchPressed.Invoke();
        }
        isPushed = true;
    }

    public void SwitchUp()
    {
        isPushed = false;
    }


}
