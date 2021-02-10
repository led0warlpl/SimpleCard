using UnityEngine;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    public interface IUiCardComponents
    {
        Camera MainCamera { get; }
        MeshRenderer[] MRenderers { get; }
        MeshRenderer MRenderer { get; }
        SpriteRenderer[] Renderers { get; }
        SpriteRenderer Renderer { get; }
        Collider Collider { get; }
        Rigidbody Rigidbody { get; }
        IMouseInput Input { get; }
        MonoBehaviour MonoBehaviour { get; }
        GameObject gameObject { get; }
        Transform transform { get; }
        
    }
}