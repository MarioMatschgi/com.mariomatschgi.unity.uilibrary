using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MM.Libraries.UI
{
    public class PrefabListPanel : MonoBehaviour
    {
        public delegate void OnStartSetupEvent(IPrefabListChild[] _children);
        public OnStartSetupEvent OnStartSetup;
        public delegate void OnEndSetupEvent(IPrefabListChild[] _children);
        public OnEndSetupEvent OnEndSetup;
    
        [Header("General")] 
        public int amount;
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

            IPrefabListChild[] _tmpChildren = gameObject.GetComponentsInDirectChildren<IPrefabListChild>().ToArray();//GetComponentsInChildren<IPrefabListChild>(true);
            List<IPrefabListChild> _children = new List<IPrefabListChild>();
            if (_tmpChildren == null)
                _tmpChildren = new IPrefabListChild[0];
            
            // Dont add duplicates to list
            for (int i = 0; i < _tmpChildren.Length; i++)
                for (int j = 0; j < _tmpChildren.Length; j++)
                    if ( !((MonoBehaviour)_tmpChildren[i]).gameObject.Equals(((MonoBehaviour)_tmpChildren[j]).gameObject) )
                        if (!_children.Contains(_tmpChildren[i]))
                            _children.Add(_tmpChildren[i]);

            List<GameObject> _toDestroy = new List<GameObject>();
            for (int i = 0; i < _children.Count - amount; i++)
                _toDestroy.Add(transform.GetChild(i).gameObject);

            for (int i = 0; i < _toDestroy.Count; i++)
                DestroyImmediate(_toDestroy[i]);

            for (int i = 0; i < amount - _children.Count; i++)
                InstantiatePrefab(_editor);

            _children = GetComponentsInChildren<IPrefabListChild>(true).ToList();
            
            OnStartSetup?.Invoke(_children.ToArray());

            foreach (IPrefabListChild _child in _children)
                _child.Setup();
            
            OnEndSetup?.Invoke(_children.ToArray());
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
            GameObject _go = null;
            if (_editor)
#if UNITY_EDITOR
                _go = ((GameObject) UnityEditor.PrefabUtility.InstantiatePrefab(prefab, transform));
#endif
            else
                _go = Instantiate(prefab, transform);

            if (_go.GetComponent<IPrefabListChild>() == null)
                _go.AddComponent<PrefabListChild>();
        }

        #endregion
    }
}