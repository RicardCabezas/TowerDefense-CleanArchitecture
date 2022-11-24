using Core.Creeps.Entities;
using Core.Turrets.Configs.Projectiles;
using Core.Turrets.Entities;

namespace Core.Creeps.UseCase
{
    public class CreepReceivedFrozenProjectileUseCase : ICreepReceivedProjectile
    {
        private readonly CreepRepository _creepRepository;
        private readonly ProjectilesRepository _turretsRepository;

        public CreepReceivedFrozenProjectileUseCase()
        {
            _turretsRepository = ServiceLocator.ServiceLocator.Instance.GetService<ProjectilesRepository>();
            _creepRepository = ServiceLocator.ServiceLocator.Instance.GetService<CreepRepository>();
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