using Core.Turrets.Configs;
using Core.Turrets.Entities;
using Events;
using UnityEngine;

namespace Core.Creeps.UseCase
{
    public class CreepReceivedRegularProjectileUseCase : ICreepReceivedProjectile //TODO: create a frozen implementation that debuffs spead
    {
        private readonly CreepRepository _creepRepository;
        private readonly ProjectilesRepository _turretsRepository;

        public CreepReceivedRegularProjectileUseCase()
        {
            _turretsRepository = ServiceLocator.Instance.GetService<ProjectilesRepository>();
            _creepRepository = ServiceLocator.Instance.GetService<CreepRepository>();
        }
        public void Execute(int creepInstanceId, int projectileInstanceId)
        {
            var projectileConfig = _turretsRepository.GetProjectileConfig<RegularProjectile>(projectileInstanceId);
            var creep = _creepRepository.GetCreepEntity(creepInstanceId);
            creep.Health -= projectileConfig.Damage;

            if (creep.Health <= 0) //TODO: implement death
            {
                Debug.Log("Creep died");
            }
        }
    }
}