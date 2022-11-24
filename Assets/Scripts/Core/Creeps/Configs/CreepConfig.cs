using System;

namespace Core.Creeps.Configs
{
    [Serializable]
    public class CreepConfig
    {
        public float Speed;
        public float Health;
        public string PrefabId;
        public string Id;
        public float Damage;
        public int Reward;
    }
}
