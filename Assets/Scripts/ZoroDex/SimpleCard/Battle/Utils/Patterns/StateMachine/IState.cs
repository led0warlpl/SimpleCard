﻿namespace ZoroDex.SimpleCard.Patterns
{
    public interface IState
    {
        bool IsInitialized { get; }
        void OnInitialize();
        void OnEnterState();
        void OnExitState();
        void OnUpdate();
        void OnClear();
        void OnNextState(IState next);

    }
}