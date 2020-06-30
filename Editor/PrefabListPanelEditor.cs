#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MM.Libraries.UI
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(PrefabListPanel))]
    public class PrefabListPanelEditor : Editor
    {
        private PrefabListPanel listPanel;


        #region Callback Methodes

        /*
         *
         *  Callback Methodes
         * 
         */

        void Awake()
        {
            listPanel = (PrefabListPanel) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Regenerate children"))
                listPanel.RegenerateChildren(true);
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
}

#endif