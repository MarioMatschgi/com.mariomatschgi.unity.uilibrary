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
                public List<string> values;
                public TMP_Text valueLabel;
                [Space]
                public bool isSelected;
                [Space]
                public Button leftArrowBtn;
                public Button rightArrowBtn;

                [HideInInspector]
                public Slider slider;


                private Color leftArrowSC;
                private Color rightArrowSC;
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
                    // Setup slider
                    slider = GetComponent<Slider>();
                    slider.minValue = 0;
                    slider.maxValue = values.Count - 1;
                    slider.onValueChanged.AddListener(delegate { OnValueChanged(slider.value); });

                    UpdateValue(Mathf.RoundToInt(slider.value));

                    // Set standard colors
                    leftArrowSC = leftArrowBtn.image.color;
                    rightArrowSC = rightArrowBtn.image.color;
                }

                void Start()
                {

                }

                public void OnSelect(BaseEventData eventData)
                {
                    isSelected = true;

                    leftArrowBtn.image.color = leftArrowSC * slider.colors.selectedColor;
                    rightArrowBtn.image.color = rightArrowSC * slider.colors.selectedColor;
                }

                public void OnDeselect(BaseEventData eventData)
                {
                    isSelected = false;

                    leftArrowBtn.image.color = leftArrowSC * slider.colors.normalColor;
                    rightArrowBtn.image.color = rightArrowSC * slider.colors.normalColor;
                }

                public void OnValueChanged(float _value)
                {
                    UpdateValue(Mathf.RoundToInt(_value));

                    // Animate Arrows
                    if (previousValue > _value)
                        leftArrowBtn.OnSubmit(null);
                    else if (previousValue < _value)
                        rightArrowBtn.OnSubmit(null);

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
        }
    }
}