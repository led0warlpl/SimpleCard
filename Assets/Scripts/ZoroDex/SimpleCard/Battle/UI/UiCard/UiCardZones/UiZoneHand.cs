using UnityEngine.EventSystems;

namespace ZoroDex.SimpleCard.Battle.UI.Card{
    /// <summary>
    ///     GameController hand zone.
    /// </summary>
    public class UiZoneHand : UiBaseDropZone
    {
        protected override void OnPointerUp(PointerEventData eventData) => CardHand?.Unselect();

    }
}