namespace ScreenMachine
{
    public interface IStateBase
    {
        string GetId();
        
        void OnBringToFront();
        
        void OnSendToBack();
        
        void OnCreate();
        
        void OnDestroy();
        
        void OnUpdate();
    }
}