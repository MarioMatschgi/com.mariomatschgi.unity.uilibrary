using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
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

#if UNITY_EDITOR
    [UnityEditor.MenuItem("GameObject/MM UI/SimpleSlider", false, 10)]
    static void OnCreate()
    {
#pragma warning disable CS0618 // Type or member is obsolete

        Transform _parent = UnityEditor.Selection.activeTransform;
        Canvas _canvas = _parent == null ? null : _parent.GetComponentsInParent<Canvas>(true)[0];
        // If parents canvas is null search for a canvas in scene
        if (_canvas == null)
        {
            // Search
            _canvas = (Canvas)(FindObjectsOfTypeAll(typeof(Canvas))[0]);
            _parent = _canvas == null ? null : _canvas.transform;
        }
        // If search wasn't successful, create new canvas
        if (_canvas == null)
        {
            // Create
            _canvas = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster)).GetComponent<Canvas>();
            if ((Canvas)(FindObjectsOfTypeAll(typeof(EventSystem))[0]) == null)
                _ = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule)).GetComponent<EventSystem>();

            // Setup
            _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            _parent = _canvas.transform;
        }

        GameObject _sliderObj = (GameObject)Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Packages/com.mariomatschgi.unity.uilibrary/Prefabs/RoundedSlider.prefab", typeof(GameObject)), _parent);
        _sliderObj.transform.name = "RoundedSlider";

#pragma warning restore CS0618 // Type or member is obsolete
    }
#endif

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
