using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoAnimado : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 escalaOriginal;
    public Vector3 escalaHover = new Vector3(1.1f, 1.1f, 1.1f);

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = escalaHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = escalaOriginal;
    }
}