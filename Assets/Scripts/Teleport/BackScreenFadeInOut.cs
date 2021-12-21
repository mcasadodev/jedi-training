using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackScreenFadeInOut : MonoBehaviour
{
    public Image fadeImage;

    public void ActivateImage()
    {
        StartCoroutine(FadeImage(2, 255));
    }

    public void DeactivateImage()
    {
        StartCoroutine(FadeImage(2, 0));
    }

    public void ActivateDeactivateImage()
    {
        StartCoroutine(FadeImage2(0.25f));
    }

    IEnumerator FadeImage(float secs, int alpha)
    {
        fadeImage.color = new Color(0, 0, 0, alpha);
        yield return new WaitForSeconds(secs);
    }

    IEnumerator FadeImage2(float secs)
    {
        fadeImage.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(secs);
        fadeImage.color = new Color(0, 0, 0, 0);
    }
}
