using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class CanvasPointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.white;
    [SerializeField] private Color downColor = Color.white;
    //[SerializeField] private UnityEvent OnClick = new UnityEvent();

    private Selectable element = null;
    private CanvasPointerIsClicking cpIsClicking;
    public bool isHovering = false;
    public bool isClicking = false;
    public int numberHovers = 0;
    public int numberClicks = 0;
    public bool handL, handR;

    private void Awake()
    {
        element = GetComponent<Selectable>();
        cpIsClicking = GetComponent<CanvasPointerIsClicking>();
    }

    private void Update()
    {
        numberHovers = Mathf.Clamp(numberHovers, 0, 2);
        numberClicks = Mathf.Clamp(numberClicks, 0, 2);

        if (Input.GetButton("primaryButton_L"))
            handL = true;
        else
            handL = false;

        if (Input.GetButton("primaryButton_R"))
            handR = true;
        else
            handR = false;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (cpIsClicking.sliderIsClicked)
            return;

        numberHovers++;

        if (handL == true && handR == true && numberClicks == 2)
        {
            isClicking = false;
            numberHovers = 0;
            if (numberHovers == 2)
                isClicking = true;
        }

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

        numberHovers--;

        if (numberHovers < 2 || numberClicks <= 2)
        {
            if (numberHovers == 0)
                isHovering = false;
            //numberClicks--;
            if (numberClicks == 0)
                isClicking = false;
        }

        if (isClicking && numberClicks > 0 && isHovering)
        {
            element.image.color = downColor;
            if (handL == false && handR == false)
                numberClicks--;
        }
        else if (numberHovers > 0)
            element.image.color = enterColor;
        else
            element.image.color = normalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (cpIsClicking.sliderIsClicked)
            return;

        numberClicks++;

        element.image.color = downColor;

        isClicking = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (cpIsClicking.sliderIsClicked)
            return;

        if (handL == false && handR == false)
            numberClicks = 0;

        if (numberClicks == 0)
            isClicking = false;

        if (isHovering)
        {
            if (numberHovers == 1 && numberClicks == 2 && (handR != handL))
            {
                isClicking = false;
            }
            if (isClicking)
                element.image.color = downColor;
            else
                element.image.color = enterColor;
        }
        else
            element.image.color = normalColor;

    }
}