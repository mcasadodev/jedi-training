using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CanvasSliderEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.white;
    [SerializeField] private Color downColor = Color.white;
    //[SerializeField] private UnityEvent OnClick = new UnityEvent();

    private Selectable element = null;
    private CanvasPointerIsClicking cpIsClicking;
    public bool isHovering = false;
    public bool isClicking = false;

    private void Awake()
    {
        element = GetComponent<Selectable>();
        cpIsClicking = GetComponent<CanvasPointerIsClicking>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (cpIsClicking.sliderIsClicked)
            return;

        if (isClicking)
            element.image.color = downColor;
        else
            element.image.color = enterColor;

        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (cpIsClicking.sliderIsClicked)
            return;

        if (isClicking)
            element.image.color = downColor;
        else
            element.image.color = normalColor;

        isHovering = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (cpIsClicking.sliderIsClicked)
            return;

        element.image.color = downColor;

        isClicking = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (cpIsClicking.sliderIsClicked)
            return;

        if (isHovering)
            element.image.color = enterColor;
        else
            element.image.color = normalColor;

        isClicking = false;
    }
    public void OnPointerStay(PointerEventData eventData)
    {
        element.image.color = enterColor;
    }
}