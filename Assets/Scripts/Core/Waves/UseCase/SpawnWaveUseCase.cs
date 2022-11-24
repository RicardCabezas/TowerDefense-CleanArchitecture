using System.Threading.Tasks;
using Core.Creeps.Entities;
using Core.Creeps.Events;
using Core.SpawnerPoints.Entities;
using Core.Waves.Entity;
using Events;

namespace Core.Waves.UseCase
{
    public class SpawnWaveUseCase
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly WavesRepository _wavesRepository;
        private readonly CreepRepository _creepRepository;
        private readonly SpawnerPointsRepository _spawnerPointsRepository;

        public SpawnWaveUseCase(WavesRepository wavesRepository)
        {
            _eventDispatcher = ServiceLocator.ServiceLocator.Instance.GetService<IEventDispatcher>();
            _wavesRepository = wavesRepository;
            _creepRepository = ServiceLocator.ServiceLocator.Instance.GetService<CreepRepository>();
            _spawnerPointsRepository = ServiceLocator.ServiceLocator.Instance.GetService<SpawnerPointsRepository>();
        }

        public async void SpawnCreepsInWave()
        {
            var nextWave = _wavesRepository.GetNextWave();
        
            foreach (var creep in nextWave.CreepsConfig)
            {
                await Task.Delay(creep.SpawnDelayInMiliseconds);
            
                var spawnerPosition = _spawnerPointsRepository.GetSpawnerPointPosition(creep.SpawnPointId);
                var creepEntity = _creepRepository.SpawnNewCreep(creep.CreepId, spawnerPosition);
            
                _eventDispatcher.Dispatch(new CreepSpawnedEvent(creepEntity));
            }
        }
    }
}