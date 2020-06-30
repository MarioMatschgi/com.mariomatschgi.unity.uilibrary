using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MM.Libraries.UI
{
    public class PrefabListPanel : MonoBehaviour
    {
        [Header("General")] public int amount;
        public GameObject prefab;


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

        }

        #endregion

        #region Gameplay Methodes

        /*
         *
         *  Gameplay Methodes
         *
         */

        public void RegenerateChildren(bool _editor, bool _forceRegenerate = false)
        {
            if (_forceRegenerate)
                for (int i = 0; i < transform.childCount; i++)
                    Destroy(transform.GetChild(i));

            IPrefabListChild[] _children = GetComponentsInChildren<IPrefabListChild>(true);
            if (_children == null)
                _children = new IPrefabListChild[0];

            List<GameObject> _toDestroy = new List<GameObject>();
            for (int i = 0; i < _children.Length - amount; i++)
                _toDestroy.Add(transform.GetChild(i).gameObject);

            for (int i = 0; i < _toDestroy.Count; i++)
                DestroyImmediate(_toDestroy[i]);

            for (int i = 0; i < amount - _children.Length; i++)
                InstantiatePrefab(_editor);
        }

        #endregion

        #region Helper Methodes

        /*
         *
         *  Helper Methodes
         * 
         */

        void InstantiatePrefab(bool _editor)
        {
            if (_editor)
#if UNITY_EDITOR
                ((GameObject) UnityEditor.PrefabUtility.InstantiatePrefab(prefab, transform))
                    .AddComponent<PrefabListChild>();
#endif
            else
                Instantiate(prefab, transform).AddComponent<PrefabListChild>();
        }

        #endregion
    }
}