using UnityEngine;
using UnityEngine.EventSystems;

public class UITask : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = transform.parent.GetChild(0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = transform.parent.parent;
    }
}
