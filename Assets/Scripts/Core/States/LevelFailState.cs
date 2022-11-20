using Core.LevelFinished;
using ScreenMachine;

namespace States
{
    public class LevelFailState : IStateBase
    {
        private readonly LevelFinishedRepository _levelFinishedRepository;

        public LevelFailState(LevelFinishedRepository levelFinishedRepository)
        {
            _levelFinishedRepository = levelFinishedRepository;
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
            //TODO: show lose popup
            //TODO: add views to states of screen machine (world view and ui view)
            _levelFinishedRepository.GetLevelFailPopup();
        }

        public void OnDestroy()
        {
        }

        public void OnUpdate()
        {
        }
    }
}