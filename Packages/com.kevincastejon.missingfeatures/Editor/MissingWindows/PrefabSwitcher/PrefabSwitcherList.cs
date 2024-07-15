using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KevinCastejon.MissingFeatures.MissingWindows.Experimental
{
    [CreateAssetMenu]
    public class PrefabSwitcherList : ScriptableObject
    {
        [SerializeField] private GameObject[] _prefabs;
        public GameObject[] Prefabs { get => _prefabs; }
    }
}