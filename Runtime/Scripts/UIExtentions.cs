using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MM.Libraries.UI
{
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
        static IEnumerator FadeOutIE(Image _image, float _time, bool _setAlphaAtBeginningToo)
        {
            float timeForAnim = _time;
            Color color;

            if (_setAlphaAtBeginningToo)
            {
                color = _image.color;
                color.a = 1;
                _image.color = color;
            }

            while (timeForAnim > 0)
            {
                color = _image.color;
                color.a -= Time.deltaTime / _time;
                _image.color = color;

                timeForAnim -= Time.deltaTime;
                yield return null;
            }
            color = _image.color;
            color.a = 0;
            _image.color = color;
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
        static IEnumerator FadeOutIE(CanvasGroup _canvasGroup, float _time, bool _setAlphaAtBeginningToo)
        {
            float timeForAnim = _time;

            if (_setAlphaAtBeginningToo)
                _canvasGroup.alpha = 1;

            while (timeForAnim > 0)
            {
                _canvasGroup.alpha -= Time.deltaTime / _time;

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
        static IEnumerator FadeInIE(Image _image, float _time, bool _setAlphaAtBeginningToo)
        {
            float timeForAnim = _time;
            Color color;

            if (_setAlphaAtBeginningToo)
            {
                color = _image.color;
                color.a = 0;
                _image.color = color;
            }

            while (timeForAnim > 0)
            {
                color = _image.color;
                color.a += Time.deltaTime / _time;
                _image.color = color;

                timeForAnim -= Time.deltaTime;
                yield return null;
            }
            color = _image.color;
            color.a = 1;
            _image.color = color;
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
        static IEnumerator FadeInIE(CanvasGroup _canvasGroup, float _time, bool _setAlphaAtBeginningToo)
        {
            float timeForAnim = _time;

            if (_setAlphaAtBeginningToo)
                _canvasGroup.alpha = 0;

            while (timeForAnim > 0)
            {
                _canvasGroup.alpha += Time.deltaTime / _time;

                timeForAnim -= Time.deltaTime;
                yield return null;
            }
            _canvasGroup.alpha = 1;
        }

        #endregion


        #endregion
    }
}