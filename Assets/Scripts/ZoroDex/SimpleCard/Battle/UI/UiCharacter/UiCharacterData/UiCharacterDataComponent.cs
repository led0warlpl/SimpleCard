using System;
using ZoroDex.SimpleCard.Data.Character;

namespace ZoroDex.SimpleCard.Battle.UI.Character
{

    /// <summary>
    ///     Data stored inside the an UI character.
    /// </summary>
    public interface IUiCharacterData
    {
        IRuntimeCharacter RuntimeData { get; }
        ICharacterData StaticData { get; }
        Action<ICharacterData> OnSetData { get; set; }
        void SetData(IRuntimeCharacter character);

    }
    
    public class UiCharacterDataComponent 
    {
        
    }
}