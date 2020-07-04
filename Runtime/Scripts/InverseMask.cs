using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace MM.Libraries.UI
{
    public class InverseMask : Image
    {
        public override Material materialForRendering
        {
            get
            {
                Material result = base.materialForRendering;
                result.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
                return result;
            }
        }
    }
}