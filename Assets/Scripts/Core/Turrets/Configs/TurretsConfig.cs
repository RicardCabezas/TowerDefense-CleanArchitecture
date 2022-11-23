using System;

namespace Core.Turrets.Configs
{
    [Serializable]
    public class TurretsConfig
    {
        public string ThumbnailPrefabId;
        
        public TurretConfig[] Turrets;
    }
}