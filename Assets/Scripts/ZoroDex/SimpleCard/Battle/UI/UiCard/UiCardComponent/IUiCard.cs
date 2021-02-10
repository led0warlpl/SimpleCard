using ZoroDex.SimpleCard.Battle.UI.UiPlayerHand;
using ZoroDex.SimpleCard.Patterns;
using ZoroDex.SimpleCard.Tools.UI;

namespace ZoroDex.SimpleCard.Battle.UI.Card
{
    /// <summary>
    ///     A complete UI Card.
    /// </summary>
    public interface IUiCard :IStateMachineHandler,IUiCardComponents,IUiMotion
    {
        IUiCard Data { get; }
        IUiPlayerHand Hand { get; }
        bool IsInitialized { get; }
        bool IsDragging { get; }
        bool IsHovering { get; }
        bool IsDisabled { get; }
        void Initialize();
        void Disable();
        void Enable();
        void Select();
        void Unselect();
        void Hover();
        void Draw();
        void Discard();
        void Play();
        void Restart();
        void Target();

    }
}