using ScreenMachine;

namespace States
{
    public class GameplayState : IStateBase
    {
        private readonly ScreenMachineImplementation _screenMachine;
        private readonly SpawnWaveUseCase _spawnWaveUseCase;

        public GameplayState(ScreenMachineImplementation screenMachine, SpawnWaveUseCase spawnWaveUseCase)
        {
            _screenMachine = screenMachine; //TODO: improve this dependency
            _spawnWaveUseCase = spawnWaveUseCase;
        }

        public string GetId() => "";

        public void OnBringToFront()
        {
        }

        public void OnSendToBack()
        {
        }

        public void OnCreate()
        {
            _spawnWaveUseCase.SpawnCreepsInWave();
        }

        public void OnDestroy()
        {
        }

        public void OnUpdate()
        {
        }
    }
}