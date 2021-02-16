﻿using UnityEngine;

namespace ZoroDex.SimpleCard.Battle.UI.Character
{
    /// <summary>
    ///     Main components of an UI character.
    /// </summary>
    public interface IUiCharacterComponents
    {
        Camera MainCamera { get; }
        SpriteRenderer Renderer { get; }
        Collider Collider { get; }
        Rigidbody Rigidbody { get; }
        IMouseInput Input { get; }
        MonoBehaviour MonoBehaviour { get; }
        GameObject gameObject { get; }
        Transform transform { get; }
        
    }
}