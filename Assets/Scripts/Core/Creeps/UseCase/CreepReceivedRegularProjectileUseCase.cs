using Core.Creeps.Entities;
using Core.Turrets.Configs.Projectiles;
using Core.Turrets.Entities;

namespace Core.Creeps.UseCase
{
    public class CreepReceivedRegularProjectileUseCase : ICreepReceivedProjectile
    {
        private readonly CreepRepository _creepRepository;
        private readonly ProjectilesRepository _turretsRepository;
        private readonly DestroyCreepUseCase _destroyCreepUseCase;

        public CreepReceivedRegularProjectileUseCase()
        {
            _turretsRepository = ServiceLocator.ServiceLocator.Instance.GetService<ProjectilesRepository>();
            _creepRepository = ServiceLocator.ServiceLocator.Instance.GetService<CreepRepository>();
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
}