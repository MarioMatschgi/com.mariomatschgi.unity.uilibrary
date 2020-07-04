using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace MM.Libraries.UI
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Image))]
    public class RoundedCornersBase : MonoBehaviour
    {
        public virtual string cacheFolderPath
        {
            get { return "Assets/RoundedCornersMaterials"; }
        }

        public Material material;

        protected void Reset()
        {
            Refresh();
            NewMaterial();
        }

        protected void OnRectTransformDimensionsChange()
        {
            Refresh();
        }

        protected void OnDestroy()
        {
            GetComponent<Image>().material = null;
        }

        protected void OnValidate()
        {
            Refresh();
        }

        public void NewMaterial()
        {
            Material _material = new Material(Shader.Find(this is RoundedCornersIndependent
                ? "UI/RoundedCorners/RoundedCornersIndependent"
                : "UI/RoundedCorners/RoundedCorners"));
            Directory.CreateDirectory(cacheFolderPath);
            AssetDatabase.CreateAsset(_material, cacheFolderPath + "/" + GetInstanceID() + ".mat");

            GetComponent<Image>().material = _material;
            material = _material;

            Refresh();
            RefreshMaterialFolder();
        }

        public void RefreshMaterialFolder()
        {
            if (Directory.Exists(cacheFolderPath))
            {
#pragma warning disable 618
                RoundedCornersBase[] _roundedCorners =
                    (RoundedCornersBase[]) FindObjectsOfTypeAll(typeof(RoundedCornersBase));
#pragma warning restore 618

                foreach (string _filePath in Directory.GetFiles(cacheFolderPath))
                {
                    if (!_filePath.EndsWith(".mat"))
                        continue;

                    string _fileName = _filePath.Split('/').Last();
                    if (!_roundedCorners.Any(o => o.GetInstanceID() + ".mat" == _fileName)) // Don't change
                    {
                        File.Delete(_filePath);
                        File.Delete(_filePath.Replace(".mat", ".mat.meta"));
                        AssetDatabase.Refresh();

                        Debug.Log("The material " + _fileName + " was deleted!");
                    }
                }
            }
        }

        protected virtual void Refresh()
        {
            if (material == null)
                NewMaterial();
        }
    }
}