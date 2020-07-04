using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class SimpleSlider : MonoBehaviour
{ 
    [Header("General")]
    [Range(0, 1)]
    public float value;
    
    [Header("Outlets")]
    public Image backgroundImage;
    public Image fillImage;
    public RectTransform handle;


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    void Start()
    {
        
    }

    void Update()
    {
        float _w = ((RectTransform) transform).rect.width;
        float _val = (Mathf.Clamp01(value) * (_w - handle.rect.width) + handle.rect.width / 2).Remap(0, _w, 0, 1);
        backgroundImage.fillAmount = 1 - _val;
        fillImage.fillAmount = _val;
        handle.anchoredPosition = new Vector2(value.Remap(0, 1, 0, _w - handle.rect.width), handle.anchoredPosition.y);
    }

    #endregion

    #region Gameplay Methodes
    /*
     *
     *  Gameplay Methodes
     *
     */

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    #endregion
}
