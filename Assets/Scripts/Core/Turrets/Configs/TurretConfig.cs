using System;
using UnityEngine;

namespace Core.Turrets.Configs
{
    [Serializable]
    public class TurretConfig
    {
        public float Cost;
        
        public string Id;
        
        public Color ThumbnailColor;
        
        public string PrefabId;
    }
}