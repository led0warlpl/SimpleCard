using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     Interface for all the Unity Mouse Input System.
    /// </summary>
    public interface IMouseInput : IPointerClickHandler,
        IBeginDragHandler,
        IDragHandler,
        IEndDragHandler,
        IDropHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        //clicks
        new Action<PointerEventData> OnPointerClick { get; set; }
        new Action<PointerEventData> OnPointerDown { get; set; }
        new Action<PointerEventData> OnPointerUp { get; set; }
        
        //drag
        new Action<PointerEventData> OnBeginDrag { get; set; }
        new Action<PointerEventData> OnDrag { get; set; }
        new Action<PointerEventData> OnEndDrag { get; set; }
        new Action<PointerEventData> OnDrop { get; set; }
        
        //enter
        new Action<PointerEventData> OnPointerEnter { get; set; }
        new Action<PointerEventData> OnPointerExit { get; set; }
        
        Vector2 MousePosition { get;  }
        DragDirection DragDirection { get; }
        
    }

    public enum DragDirection
    {
        None,
        Down,
        Left,
        Top,
        Right
    }
        
    /// <summary>
    ///     Wrap of all the Unity Input System into a Monobehaviour.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class UiMouseInputProvider : MonoBehaviour,IMouseInput
    {

        void Awake()
        {
            // Currently using PhysicsRaycaster, but can be also considered PhysicsRaycaster2D.
            if (Camera.main.GetComponent<PhysicsRaycaster>() == null)
                throw new Exception(GetType() + "needs an " + typeof(PhysicsRaycaster) + " on the MainCamera");
        }

        /// <summary>
        ///     While dragging returns the direction of the movement.
        /// </summary>
        /// <returns></returns>
        DragDirection GetDragDirection()
        {
            var currentPosition = Input.mousePosition;
            var normalized = (currentPosition - oldDragPosition).normalized;
            oldDragPosition = currentPosition;

            if (normalized.x > 0)
                return DragDirection.Right;

            if (normalized.x < 0)
                return DragDirection.Left;

            if (normalized.y > 0)
                return DragDirection.Top;

            return normalized.y < 0 ? DragDirection.Down : DragDirection.None;

        }

        Action<PointerEventData> IMouseInput.OnPointerDown { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnPointerUp { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnPointerClick { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnBeginDrag { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnDrag { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnEndDrag { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnDrop { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnPointerEnter { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnPointerExit { get; set; } = eventData => { };

        private Vector3 oldDragPosition;
        DragDirection IMouseInput.DragDirection => GetDragDirection();
        Vector2 IMouseInput.MousePosition => Input.mousePosition;

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) =>
            ((IMouseInput) this).OnBeginDrag.Invoke(eventData);

        void IDragHandler.OnDrag(PointerEventData eventData) => ((IMouseInput) this).OnDrag.Invoke(eventData);

        void IEndDragHandler.OnEndDrag(PointerEventData eventData) => ((IMouseInput) this).OnEndDrag(eventData);

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerClick(eventData);

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerDown(eventData);

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerUp(eventData);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerEnter.Invoke(eventData);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerExit.Invoke(eventData);


        void IDropHandler.OnDrop(PointerEventData eventData) =>
            ((IMouseInput) this).OnDrop(eventData);
    }
}