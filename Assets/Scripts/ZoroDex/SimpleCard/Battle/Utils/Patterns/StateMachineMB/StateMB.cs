using UnityEngine;

namespace ZoroDex.SimpleCard.Battle.Utils.Patterns.StateMachineMB
{
    
    public abstract class StateMB<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        ///     Reference for the parent Finite StateMB Machine
        /// </summary>
        public T Fsm { get; private set; }

        /// <summary>
        ///     Called by the GameControllerMB's Awake
        /// </summary>
        public virtual void OnAwake()
        {
            
        }

        /// <summary>
        ///     Called by the GameControllerMB's Start
        /// </summary>
        public virtual void OnStart()
        {
            
        }

        /// <summary>
        ///     Called by the GameControllerMB's Update
        /// </summary>
        public virtual void OnUpdate()
        {
            
        }

        /// <summary>
        ///     Called right after enter the state
        /// </summary>
        public virtual void OnEnterState() => Log("OnEnterState <---------", "green");

        /// <summary>
        ///     Called right after left the state
        /// </summary>
        public virtual void OnExitState() => Log("OnExitState <---------", "red");

        /// <summary>
        ///     Setter for Internal StateMB Machine
        /// </summary>
        /// <param name="stateMachine"></param>
        public void InjectStateMachine(StateMachineMB<T> stateMachine)
        {
            Fsm = stateMachine as T;
            Log("BaseStateMachine Assigned");
        }

        void Log(string log, string colorName = "black")
        {
            log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
            Debug.Log(log);
        }

    }
}