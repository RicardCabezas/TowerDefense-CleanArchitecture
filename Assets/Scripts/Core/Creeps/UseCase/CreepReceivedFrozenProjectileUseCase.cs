using Core.Turrets.Configs;
using Core.Turrets.Entities;
using Events;

namespace Core.Creeps.UseCase
{
    public class CreepReceivedFrozenProjectileUseCase : ICreepReceivedProjectile
    {
        private readonly CreepRepository _creepRepository;
        private readonly ProjectilesRepository _turretsRepository;

        public CreepReceivedFrozenProjectileUseCase()
        {
            _turretsRepository = ServiceLocator.Instance.GetService<ProjectilesRepository>();
            _creepRepository = ServiceLocator.Instance.GetService<CreepRepository>();
        }

        public void Execute(int creepInstanceId, int projectileInstanceId)
        {
            var projectileConfig = _turretsRepository.GetProjectileConfig<FrozenProjectile>(projectileInstanceId);
            var creep = _creepRepository.GetCreepEntity(creepInstanceId);
            creep.CurrentSpeed -= projectileConfig.SpeedDebuff;

            if (creep.CurrentSpeed < 0)
                creep.CurrentSpeed = 0;
        }
    }
}