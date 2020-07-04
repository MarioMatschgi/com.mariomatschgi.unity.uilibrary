using System;
using UnityEngine;
using UnityEngine.UI;

namespace MM.Libraries.UI
{
	[ExecuteInEditMode]
	[AddComponentMenu("MM UI/RoundedCornersIndependent")]
	public class RoundedCornersIndependent : RoundedCornersBase
	{
		public RoundedCornerRadii radii;
		Vector4 c_radii;

		[HideInInspector, SerializeField] private Vector4 rect2props;
		private readonly int prop_halfSize = Shader.PropertyToID("_halfSize");
		private readonly int prop_radiuses = Shader.PropertyToID("_r");
		private readonly int prop_rect2props = Shader.PropertyToID("_rect2props");
		private static readonly Vector2 wNorm = new Vector2(.7071068f, -.7071068f);
		private static readonly Vector2 hNorm = new Vector2(.7071068f, .7071068f);

		private void RecalculateProps(Vector2 size)
		{
			CalcRadii(size);

			var _halfWidth = Vector2.Dot(new Vector2(size.x, -size.y + c_radii.x + c_radii.z), wNorm) * .5f;
			rect2props.z = _halfWidth;

			var _halfHeight = Vector2.Dot(new Vector2(size.x, size.y - c_radii.w - c_radii.y), hNorm) * .5f;
			rect2props.w = _halfHeight;

			var _origin = new Vector2(c_radii.x - (size.x / 2), size.y / 2) +
			              (hNorm * Vector2.Dot(new Vector2(size.x - c_radii.x - c_radii.y, 0), hNorm)) +
			              wNorm * _halfWidth + hNorm * -_halfHeight;
			rect2props.x = _origin.x;
			rect2props.y = _origin.y;
		}

		void CalcRadii(Vector2 size)
		{
			c_radii.x = radii.topLeft.Remap(0, 100, 0, Mathf.Min(size.x, size.y));
			c_radii.y = radii.topRight.Remap(0, 100, 0, Mathf.Min(size.x, size.y));
			c_radii.z = radii.bottomRight.Remap(0, 100, 0, Mathf.Min(size.x, size.y));
			c_radii.w = radii.bottomLeft.Remap(0, 100, 0, Mathf.Min(size.x, size.y));
		}

		protected override void Refresh()
		{
			base.Refresh();

			var _rect = ((RectTransform) transform).rect;
			RecalculateProps(_rect.size);

			material.SetVector(prop_rect2props, rect2props);
			material.SetVector(prop_halfSize, _rect.size * .5f);
			material.SetVector(prop_radiuses, c_radii);
		}
	}
}