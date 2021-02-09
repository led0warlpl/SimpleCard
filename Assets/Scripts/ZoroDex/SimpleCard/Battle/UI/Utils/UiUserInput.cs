using UnityEngine;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     Enable and Disable a CanvasGroup
    /// </summary>
    public interface IUiUserInput
    {
        void Disable();
        void Enable();
    }

    /// <summary>
    ///     Class used to manage the UiUserInput upon a CanvaGroup
    /// </summary>
    public class UiUserInput : MonoBehaviour, IUiUserInput
    {
        private CanvasGroup CanvasGroup { get; set; }

        void IUiUserInput.Disable() => CanvasGroup.interactable = false;
        void IUiUserInput.Enable() => CanvasGroup.interactable = true;

        void Awke() => CanvasGroup = GetComponent<CanvasGroup>();

    }
}