using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPointerIsClicking : MonoBehaviour
{

    public CanvasSliderEvents[] sliderEvents;
    public bool sliderIsClicked;

    private void Update()
    {
        for (int i = 0; i < sliderEvents.Length; i++)
        {
            if (sliderEvents[i].isClicking)
            {
                sliderIsClicked = true;
                break;
            }
            else
            {
                sliderIsClicked = false;
            }
        }
    }
}
