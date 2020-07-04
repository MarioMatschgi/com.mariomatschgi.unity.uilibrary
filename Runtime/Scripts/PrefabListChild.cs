using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MM.Libraries.UI
{
    public interface IPrefabListChild
    {
        void Setup();
    }

    public class PrefabListChild : MonoBehaviour, IPrefabListChild
    {
        public void Setup()
        {

        }
    }
}