using System;
using System.Collections.Generic;

namespace ScreenMachine
{
    public class ScreenMachineImplementation
    {
        private Stack<IStateBase> _screenStack;

        public ScreenMachineImplementation()
        {
            _screenStack = new Stack<IStateBase>();
        }

        public void PopState()
        {
            PopStateLocally();
        }

        public void PresentState(IStateBase state)
        {
            while (_screenStack.Count != 0)
            {
                PopStateLocally();
            }

            PushStateLocally(state);
        }

        public void PushState(IStateBase state)
        {
            if (_screenStack.Count != 0)
            {
                var previousState = _screenStack.Peek();
                previousState.OnSendToBack();
            }

            PushStateLocally(state);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_screenStack.Count == 0)
            {
                throw new NotSupportedException("Trying to call OnUpdate on the screenstack but it's empty!");
            }

            var currentState = _screenStack.Peek();
            currentState.OnUpdate();
        }

        private void PushStateLocally(IStateBase state)
        {
            _screenStack.Push(state);
            state.OnCreate();
        }

        private void PopStateLocally()
        {
            var state = _screenStack.Pop();
            state.OnDestroy();
            
            if (_screenStack.Count != 0)
            {
                var nextState = _screenStack.Peek();
                nextState.OnBringToFront();
            }
        }
        
        //TODO: add input locker
    }
}