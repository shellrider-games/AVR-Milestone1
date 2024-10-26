using UnityEngine;

public class LeverStatePrinter : MonoBehaviour
{
    public void PrintAbove()
    {
        Debug.Log("Lever reached Above Position");
    }

    public void PrintBetween()
    {
        Debug.Log("Lever reached Between Position");
    }
    
    public void PrintBelow()
    {
        Debug.Log("Lever reached Below Position");
    }
}
