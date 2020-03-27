using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.IO;

namespace MM
{
    namespace Libraries
    {
        namespace UI
        {
            [RequireComponent(typeof(Slider))]
            [AddComponentMenu("MM UI/Stepper")]
            public class UIStepper : MonoBehaviour, ISelectHandler, IDeselectHandler
            {
                [Header("General")]
                public ColorMode colorMode = ColorMode.Images;
                [Space]
                public List<string> values;
                public TMP_Text valueLabel;
                [Space]
                public bool isSelected;
                [Space]
                public Image leftArrowImg;
                public Image rightArrowImg;

                [HideInInspector]
                public Slider slider;


                private float previousValue;


                #region Callback Methodes
                /*
                 *
                 *  Callback Methodes
                 * 
                 */

#if UNITY_EDITOR
                [UnityEditor.MenuItem("GameObject/MM UI/Stepper", false, 10)]
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

                    GameObject _stepperObj = (GameObject)Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath("Packages/com.mariomatschgi.unity.uilibrary/Prefabs/Stepper.prefab", typeof(GameObject)), _parent);
                    _stepperObj.transform.name = "Stepper";

#pragma warning restore CS0618 // Type or member is obsolete
                }
#endif

                void Awake()
                {
                    Setup(true);
                }

                void Start()
                {

                }

                public void OnSelect(BaseEventData eventData)
                {
                    isSelected = true;

                    UpdateColors();
                }

                public void OnDeselect(BaseEventData eventData)
                {
                    isSelected = false;

                    UpdateColors();
                }

                public void OnValueChanged(float _value)
                {
                    UpdateValue(Mathf.RoundToInt(_value));

                    // Animate Arrows
                    if (previousValue > _value)
                        ExecuteEvents.Execute(leftArrowImg.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
                    else if (previousValue < _value)
                        ExecuteEvents.Execute(rightArrowImg.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);

                    // Set previousValue to _value
                    previousValue = _value;
                }

                void Update()
                {

                }

                #endregion

                #region Gameplay Methodes
                /*
                 *
                 * 
                 *  Gameplay Methodes
                 *
                 *  
                 */

                public void Setup(bool _fullSetup)
                {
                    // Setup slider
                    slider = GetComponent<Slider>();
                    slider.minValue = 0;
                    slider.maxValue = values.Count - 1;
                    if (_fullSetup)
                        slider.onValueChanged.AddListener(delegate { OnValueChanged(slider.value); });

                    UpdateValue(Mathf.RoundToInt(slider.value));

                    UpdateColors();
                }

                public void UpdateColors()
                {
                    // Update Arrow color
                    if (leftArrowImg != null && rightArrowImg != null)
                    {
                        Color _color = slider.colors.normalColor;
                        if (isSelected)
                            _color = slider.colors.selectedColor;

                        switch (colorMode)
                        {
                            case ColorMode.Images:
                                leftArrowImg.color = _color;
                                rightArrowImg.color = _color;

                                valueLabel.color = slider.colors.normalColor;

                                break;

                            case ColorMode.Text:
                                leftArrowImg.color = slider.colors.normalColor;
                                rightArrowImg.color = slider.colors.normalColor;

                                valueLabel.color = _color;

                                break;

                            case ColorMode.ImagesAndText:
                                leftArrowImg.color = _color;
                                rightArrowImg.color = _color;

                                valueLabel.color = _color;

                                break;
                        }
                    }
                }

                public void UpdateValue(int _value)
                {
                    if (_value < 0 || _value > values.Count - 1)
                        return;

                    slider.value = _value;
                    valueLabel.text = values[_value];
                }

                #endregion

                #region Helper Methodes
                /*
                 *
                 *  Helper Methodes
                 * 
                 */

                #endregion
            }

            public enum ColorMode
            {
                Images,
                Text,
                ImagesAndText,
            }
        }
    }
}