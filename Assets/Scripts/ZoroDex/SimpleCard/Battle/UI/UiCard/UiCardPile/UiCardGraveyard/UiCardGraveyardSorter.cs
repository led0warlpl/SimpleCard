using System;
using System.Collections.Generic;
using UnityEngine;
using ZoroDex.SimpleCard.Battle.Controller;


namespace ZoroDex.SimpleCard.Battle.UI.Card
{
 
    /// <summary>
    ///     Sorts the graveyard.
    /// </summary>
    [RequireComponent(typeof(UiCardGraveyard))]
    public class UiCardGraveyardSorter : MonoBehaviour
    {

        [SerializeField][Tooltip("World point where the graveyard is positioned")]
        Transform graveyardPosition;

        UiCardParameters parameters;
        
        IUiCardPile Graveyard { get; set; }


        void Awake()
        {
            Graveyard = GetComponent<UiCardGraveyard>();
            Graveyard.OnPileChanged += Sort;
        }

        public void Sort(IUiCard[] cards)
        {
            if (cards == null)
                throw new ArgumentException("Can't sort a card lils null");

            var lastPos = cards.Length - 1;
            var lastCard = cards[lastPos];
            var gravePos = graveyardPosition.position + new Vector3(0, 0, -5);
            var backGravPos = graveyardPosition.position;
            
            //move last
            lastCard.Motion.MoveToWithZ(gravePos, parameters.MovementSpeed);
            //
            // move other
            for (var i = 0; i < cards.Length - 1; i++)
            {
                var card = cards[i];
                card.Motion.MoveToWithZ(backGravPos, parameters.MovementSpeed);
            }
        }

    }
}