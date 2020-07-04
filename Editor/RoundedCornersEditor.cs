using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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

        RoundedCorners _roundedCorners = ((RoundedCorners)target);
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate a new material"))
        {
            _roundedCorners.NewMaterial();
        }
        if (GUILayout.Button("Select the current material"))
        {
            EditorGUIUtility.PingObject(_roundedCorners.material);
        }
        if (GUILayout.Button("Refresh the material folder"))
        {
            _roundedCorners.RefreshMaterialFolder();
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
