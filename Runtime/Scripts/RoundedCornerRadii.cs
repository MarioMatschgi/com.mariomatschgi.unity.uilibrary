using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MM.Libraries.UI
{
    [Serializable]
    public class RoundedCornerRadii
    {
        [Range(0, 100)] public float topLeft;
        [Range(0, 100)] public float topRight;
        [Range(0, 100)] public float bottomLeft;
        [Range(0, 100)] public float bottomRight;
    }
}