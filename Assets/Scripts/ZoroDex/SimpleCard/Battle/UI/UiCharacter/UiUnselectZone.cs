using UnityEngine;

namespace ZoroDex.SimpleCard.Battle.UI.Character
{
    public interface IClickZone
    {
        Collider Collider { get; }
        void Enable();
        void Disable();
    }
    
    public class UiUnselectZone
    {
        
    }
}