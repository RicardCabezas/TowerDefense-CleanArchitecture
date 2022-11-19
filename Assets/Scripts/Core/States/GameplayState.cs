using ScreenMachine;

namespace States
{
    public class GameplayState : IStateBase
    {
        private readonly ScreenMachineImplementation _screenMachine;
        private readonly WavesService _wavesService;

        public GameplayState(ScreenMachineImplementation screenMachine, WavesService wavesService)
        {
            _screenMachine = screenMachine; //TODO: improve this dependency
            _wavesService = wavesService;
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
            _wavesService.PrepareWaves();
        }

        public void OnDestroy()
        {
        }

        public void OnUpdate()
        {
        }
    }
}