using System;

namespace Core.Creeps.Configs
{
    [Serializable]
    public class CreepInWaveConfig
    {
        public int SpawnDelayInMiliseconds;
        public string CreepId; //TODO: accept an asset
        public string SpawnPointId;
    }
}
