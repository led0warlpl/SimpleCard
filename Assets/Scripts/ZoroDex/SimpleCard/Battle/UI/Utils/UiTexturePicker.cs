using System.Linq;
using Extensions;
using UnityEngine;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     Picks a Texture randomly when it Awakes.
    /// </summary>
    public class UiTexturePicker : MonoBehaviour
    {
        [SerializeField] private Sprite[] Sprites;
        [SerializeField] private SpriteRenderer MyRenderer { get; set; }

        void Awake()
        {
            MyRenderer = GetComponent<SpriteRenderer>();

            if (Sprites.Length > 0)
                MyRenderer.sprite = Sprites.ToList().RandomItem();
        }

    }
}