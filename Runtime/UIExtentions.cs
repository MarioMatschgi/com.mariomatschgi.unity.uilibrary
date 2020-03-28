using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIExtentions
{


    #region Extention Methodes
    /*
     *
     *  Extention Methodes
     * 
     */

    #region Fade out

    /// <summary>
    /// Fades this Image out with a duration of <paramref name="_time"/> seconds.
    /// If <paramref name="_setAlphaAtBeginningToo"/> is set to true, the alpha value will get set first, else it will fade starting at the current alpha
    /// </summary>
    /// <param name="_image"></param>
    /// <param name="_time"></param>
    /// <param name="_setAlphaAtBeginningToo"></param>
    public static void FadeOut(this Image _image, float _time, bool _setAlphaAtBeginningToo)
    {
        _image.gameObject.SetActive(true);
        _image.StartCoroutine(FadeOutIE(_image, _time, _setAlphaAtBeginningToo));
    }
    static IEnumerator FadeOutIE(Image image, float time, bool setAlphaAtBeginningToo)
    {
        float timeForAnim = time;
        Color color;

        if (setAlphaAtBeginningToo)
        {
            color = image.color;
            color.a = 1;
            image.color = color;
        }

        while (timeForAnim > 0)
        {
            color = image.color;
            color.a -= Time.deltaTime / time;
            image.color = color;

            timeForAnim -= Time.deltaTime;
            yield return null;
        }
        color = image.color;
        color.a = 0;
        image.color = color;
    }

    /// <summary>
    /// Fades this CanvasGroup out with a duration of <paramref name="_time"/> seconds.
    /// If <paramref name="_setAlphaAtBeginningToo"/> is set to true, the alpha value will get set first, else it will fade starting at the current alpha
    /// </summary>
    /// <param name="_canvasGroup"></param>
    /// <param name="_time"></param>
    /// <param name="_setAlphaAtBeginningToo"></param>
    public static void FadeOut(this CanvasGroup _canvasGroup, float _time, MonoBehaviour _mb, bool _setAlphaAtBeginningToo)
    {
        _canvasGroup.gameObject.SetActive(true);
        _mb.StartCoroutine(FadeOutIE(_canvasGroup, _time, _setAlphaAtBeginningToo));
    }
    static IEnumerator FadeOutIE(CanvasGroup _canvasGroup, float time, bool setAlphaAtBeginningToo)
    {
        float timeForAnim = time;

        if (setAlphaAtBeginningToo)
            _canvasGroup.alpha = 1;

        while (timeForAnim > 0)
        {
            _canvasGroup.alpha -= Time.deltaTime / time;

            timeForAnim -= Time.deltaTime;
            yield return null;
        }
        _canvasGroup.alpha = 0;
    }

    #endregion


    #region Fade in

    /// <summary>
    /// Fades this Image in with a duration of <paramref name="_time"/> seconds.
    /// If <paramref name="_setAlphaAtBeginningToo"/> is set to true, the alpha value will get set first, else it will fade starting at the current alpha
    /// </summary>
    /// <param name="_image"></param>
    /// <param name="_time"></param>
    /// <param name="_setAlphaAtBeginningToo"></param>
    public static void FadeIn(this Image _image, float _time, bool _setAlphaAtBeginningToo)
    {
        _image.gameObject.SetActive(true);
        _image.StartCoroutine(FadeInIE(_image, _time, _setAlphaAtBeginningToo));
    }
    static IEnumerator FadeInIE(Image image, float time, bool setAlphaAtBeginningToo)
    {
        float timeForAnim = time;
        Color color;

        if (setAlphaAtBeginningToo)
        {
            color = image.color;
            color.a = 0;
            image.color = color;
        }

        while (timeForAnim > 0)
        {
            color = image.color;
            color.a += Time.deltaTime / time;
            image.color = color;

            timeForAnim -= Time.deltaTime;
            yield return null;
        }
        color = image.color;
        color.a = 1;
        image.color = color;
    }

    /// <summary>
    /// Fades this CanvasGroup in with a duration of <paramref name="_time"/> seconds.
    /// If <paramref name="_setAlphaAtBeginningToo"/> is set to true, the alpha value will get set first, else it will fade starting at the current alpha
    /// </summary>
    /// <param name="_canvasGroup"></param>
    /// <param name="_time"></param>
    /// <param name="_setAlphaAtBeginningToo"></param>
    public static void FadeIn(this CanvasGroup _canvasGroup, float _time, MonoBehaviour _mb, bool _setAlphaAtBeginningToo)
    {
        _canvasGroup.gameObject.SetActive(true);
        _mb.StartCoroutine(FadeInIE(_canvasGroup, _time, _setAlphaAtBeginningToo));
    }
    static IEnumerator FadeInIE(CanvasGroup _canvasGroup, float time, bool setAlphaAtBeginningToo)
    {
        float timeForAnim = time;

        if (setAlphaAtBeginningToo)
            _canvasGroup.alpha = 0;

        while (timeForAnim > 0)
        {
            _canvasGroup.alpha += Time.deltaTime / time;

            timeForAnim -= Time.deltaTime;
            yield return null;
        }
        _canvasGroup.alpha = 1;
    }

    #endregion


    #endregion
}
