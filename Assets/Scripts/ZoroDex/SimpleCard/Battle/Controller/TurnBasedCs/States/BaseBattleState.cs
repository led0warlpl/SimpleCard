﻿


using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle.Controller
{
    /// <summary>
    ///     The base of all the battle states. States work as controllers to provide access to a functionality in the model.
    /// </summary>
    public abstract class BaseBattleState :IState,IListener,GameEvents.IRestartGame
    {

        protected BaseBattleState(TurnBasedFsm fsm, IGameData gameData, Configurations configurations)
        {
            Fsm = fsm;
            GameData = gameData;
            Configurations = configurations;
            
            //Subscribe game events
            GameEvents.Instance.AddListener(this);
            IsInitialized = true;

        }

        #region Properties

        protected Configurations Configurations { get; }
        protected  IGameData GameData { get; }
        public TurnBasedFsm Fsm { get; set; }
        public bool IsInitialized { get; }
        

        #endregion

        #region Operations

        public virtual void OnClear()
        {
            //Unsubscribe game events
            if(GameEvents.Instance)
                GameEvents.Instance.RemoveListener(this);
        }
        
        public virtual void OnInitialize(){}
        
        public virtual void OnEnterState(){}
        
        public virtual void OnExitState(){}

        public virtual void OnUpdate()
        {
            
        }
        
        public virtual void OnNextState(IState next){}

        protected virtual void OnNextState(BaseBattleState nextState)
        {
            
            Fsm.PopState();
            Fsm.PushState(nextState);
            
        }

        public void OnRestart() => OnClear();

        #endregion
    }
}