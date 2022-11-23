using System;

namespace Core.Turrets.Configs
{
    [Serializable]
    public class TurretConfig
    {
        public float Cost;
        public string Id;
        public string PrefabId { get; set; }
    }
}