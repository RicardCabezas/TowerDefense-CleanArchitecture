using System;
using UnityEngine;

namespace Core.Turrets.Configs
{
    [Serializable]
    public class TurretConfig
    {
        public int Cost;
        
        public string Id;
        
        public Color ThumbnailColor;
        
        public string PrefabId;
        public float Cooldown;
        public string ProjectileId;
    }
}