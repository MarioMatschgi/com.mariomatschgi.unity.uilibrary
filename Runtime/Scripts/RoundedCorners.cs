using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[AddComponentMenu("MM UI/RoundedCorners")]
public class RoundedCorners : RoundedCornersBase
{
	public override string cacheFolderPath { get { return "Assets/RoundedCornersMaterials"; } }
	private static readonly int Props = Shader.PropertyToID("_WidthHeightRadius");

	public float radius;

	protected override void Refresh()
	{
		base.Refresh();
		
		var rect = ((RectTransform)transform).rect;
		material.SetVector(Props, new Vector4(rect.width, rect.height, radius, 0));
	}
}
