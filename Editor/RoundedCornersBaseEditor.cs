#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace MM.Libraries.UI
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RoundedCorners))]
    public class RoundedCornersEditor : Editor
    {


        #region Callback Methodes

        /*
         *
         *  Callback Methodes
         * 
         */

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            RoundedCornersBase _roundedCorners = ((RoundedCornersBase) target);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Generate a new material"))
            {
                _roundedCorners.NewMaterial();

                Debug.Log("A material was generated!");
            }

            if (GUILayout.Button("Select the current material"))
            {
                EditorGUIUtility.PingObject(_roundedCorners.material);
            }

            if (GUILayout.Button("Refresh the material folder"))
            {
                _roundedCorners.RefreshMaterialFolder();

                Debug.Log("The material folder was refreshed!");
            }

            EditorGUILayout.EndHorizontal();
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

    [CanEditMultipleObjects]
    [CustomEditor(typeof(RoundedCornersIndependent))]
    public class RoundedCornersIndependentEditor : RoundedCornersEditor { }
}

#endif