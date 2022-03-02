using UnityEngine;
using UnityEngine.EventSystems;

public class BetterButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isHold = false;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isHold = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isHold = false;
    }
}