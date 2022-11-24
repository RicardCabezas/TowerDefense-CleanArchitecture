using Core.Turrets.Configs;
using Core.Turrets.Entities;
using Events;
using UnityEngine;

namespace Core.Creeps.UseCase
{
    public class CreepReceivedRegularProjectileUseCase : ICreepReceivedProjectile
    {
        private readonly CreepRepository _creepRepository;
        private readonly ProjectilesRepository _turretsRepository;
        private readonly DestroyCreepUseCase _destroyCreepUseCase;

        public CreepReceivedRegularProjectileUseCase()
        {
            _turretsRepository = ServiceLocator.Instance.GetService<ProjectilesRepository>();
            _creepRepository = ServiceLocator.Instance.GetService<CreepRepository>();
            _destroyCreepUseCase = new DestroyCreepUseCase();
        }

        public void Execute(int creepInstanceId, int projectileInstanceId)
        {
            var projectileConfig = _turretsRepository.GetProjectileConfig<RegularProjectile>(projectileInstanceId);
            var creep = _creepRepository.GetCreepEntity(creepInstanceId);
            creep.Health -= projectileConfig.Damage;

            if (creep.Health <= 0)
                _destroyCreepUseCase.Destroy(creepInstanceId);

        }
    }
    
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