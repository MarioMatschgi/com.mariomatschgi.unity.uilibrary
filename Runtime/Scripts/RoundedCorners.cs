using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace MM.Libraries.UI
{
	[ExecuteInEditMode]
	[AddComponentMenu("MM UI/RoundedCorners")]
	public class RoundedCorners : RoundedCornersBase
	{
		public override string cacheFolderPath
		{
			get { return "Assets/RoundedCornersMaterials"; }
		}

		private static readonly int Props = Shader.PropertyToID("_WidthHeightRadius");

		[Range(0, 50)] public float radius;

		protected override void Refresh()
		{
			base.Refresh();

			var _rect = ((RectTransform) transform).rect;
			float _r = radius.Remap(0, 50, 0, Mathf.Min(_rect.width, _rect.height));
			material.SetVector(Props, new Vector4(_rect.width, _rect.height, _r, 0));
		}
	}
}