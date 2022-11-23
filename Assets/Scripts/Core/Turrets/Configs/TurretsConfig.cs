using System;

namespace Core.Turrets.Configs
{
    [Serializable]
    public class TurretsConfig
    {
        public string ThumbnailPrefabId;

        public ProjectilesConfiguration ProjectilesConfiguration;
        
        public TurretConfig[] Turrets;
    }
}