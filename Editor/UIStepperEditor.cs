#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Reflection;
using MM.Extentions;
using MM.Helper;

namespace MM
{
    namespace Libraries
    {
        namespace UI
        {
            [CustomEditor(typeof(UIStepper))]
            [CanEditMultipleObjects]
            public class UIStepperEditor : Editor
            {
                // Private
                UIStepper stepper;


                #region Callback Methodes
                /*
                 *
                 *  Callback Methodes
                 * 
                 */

                void OnEnable()
                {
                    stepper = (UIStepper)base.target;
                }

                public override void OnInspectorGUI()
                {
                    base.OnInspectorGUI();

                    if (stepper.slider == null)
                        stepper.Setup(false);

                    EditorGUILayout.Space();

                    EditorGUILayout.BeginHorizontal("box");
                    EditorGUILayout.BeginVertical();
                    EditorGUILayout.LabelField("Slider values", EditorStyles.boldLabel);

                    ColorBlock _colorBlock = stepper.slider.colors;
                    _colorBlock.normalColor = EditorGUILayout.ColorField("Normal color", _colorBlock.normalColor);
                    _colorBlock.highlightedColor = EditorGUILayout.ColorField("Highlighted color", _colorBlock.highlightedColor);
                    _colorBlock.pressedColor = EditorGUILayout.ColorField("Pressed color", _colorBlock.pressedColor);
                    _colorBlock.selectedColor = EditorGUILayout.ColorField("Selected color", _colorBlock.selectedColor);
                    _colorBlock.disabledColor = EditorGUILayout.ColorField("Disabled color", _colorBlock.disabledColor);
                    _colorBlock.colorMultiplier = EditorGUILayout.FloatField("Color multiplier", _colorBlock.colorMultiplier);
                    _colorBlock.fadeDuration = EditorGUILayout.FloatField("Fade duration", _colorBlock.fadeDuration);
                    stepper.slider.colors = _colorBlock;
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndHorizontal();

                    stepper.UpdateColors();
                    EditorUtility.SetDirty(stepper.leftArrowImg);
                    EditorUtility.SetDirty(stepper.rightArrowImg);
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
#endif