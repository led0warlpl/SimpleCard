using System;
using UnityEngine;

namespace ZoroDex.SimpleCard
{
    public class Configurations : ScriptableObject
    {


        public float TimeStartTurn => PlayerTurn.TimeStartTurn;
        public float TimeOutTurn => PlayerTurn.TimeOutTurn;
        
        public bool withStartingHands;
        public bool WithStartingHands => withStartingHands;
        
        // ----------------------------------------------------------

        #region PlayerHandler Turn

        public PlayerTurnEvents PlayerTurn = new PlayerTurnEvents();
        
        [Serializable]
        public class PlayerTurnEvents
        {
            [Range(6f, 12f)] [Tooltip("Total player turn time")]
            public float TimeOutTurn;

            [Range(0.01f, 2f)] [Tooltip("Time until player starts the turn after the animation")]
            public float TimeStartTurn;
        }
        

        #endregion
        // -------------------------------------------------------------
        
    }
}