using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class RoundedCorners : MonoBehaviour
{
	public static readonly string cacheFolderPath = "Assets/RoundedCornersMaterials";
	private static readonly int Props = Shader.PropertyToID("_WidthHeightRadius");

	public Material material;
	public float radius;

	void Reset()
	{
		Refresh();
		NewMaterial();
	}

	void OnRectTransformDimensionsChange(){
		Refresh();
	}

	void OnDestroy()
	{
		GetComponent<Image>().material = null;
	}

	void OnValidate(){
		Refresh();
	}

	public void NewMaterial()
	{
		Material _material = new Material(Shader.Find(this is RoundedCornersIndependent ? "UI/RoundedCorners/RoundedCornersIndependent" : "UI/RoundedCorners/RoundedCorners"));
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
			RoundedCorners[] _roundedCorners = (RoundedCorners[])FindObjectsOfTypeAll(typeof(RoundedCorners));
				
			foreach (string _filePath in Directory.GetFiles(cacheFolderPath))
			{
				if (!_filePath.EndsWith(".mat"))
					continue;

				string _fileName = _filePath.Split('/').Last();
				if (!_roundedCorners.Any(o => o.GetInstanceID() + ".mat" == _fileName))	// Don't change
				{
					File.Delete(_filePath);
					File.Delete(_filePath.Replace(".mat", ".mat.meta"));
					AssetDatabase.Refresh();
					
					Debug.Log("Deleted material " + _filePath);
				}
			}
		}
	}

	protected virtual void Refresh(){
		var rect = ((RectTransform)transform).rect;
		
		if (material == null)
			NewMaterial();
		
		material.SetVector(Props, new Vector4(rect.width, rect.height, radius, 0));
	}
}
