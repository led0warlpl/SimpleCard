﻿using UnityEngine;
using UnityEngine.EventSystems;
using ZoroDex.SimpleCard.Battle.UI.UiPlayerHand;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    /// <summary>
    ///     Base zones where the user can drop a UI Card.
    /// </summary>
    [RequireComponent(typeof(IMouseInput))]
    public abstract class UiBaseDropZone : MonoBehaviour
    {
        protected IUiPlayerHand CardHand { get; set; }
        protected IMouseInput Input { get; set; }

        protected virtual void Awae()
        {
            CardHand = transform.parent.GetComponentInChildren<IUiPlayerHand>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerUp += OnPointerUp;
            
        }
        
        protected virtual void OnPointerUp(PointerEventData eventData){}
        
        
    }
}