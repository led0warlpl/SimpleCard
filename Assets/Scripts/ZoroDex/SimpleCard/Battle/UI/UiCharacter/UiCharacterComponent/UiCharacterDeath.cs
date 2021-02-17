using System.Collections;
using UnityEngine;
using ZoroDex.SimpleCard.Data.Character;

namespace ZoroDex.SimpleCard.Battle.UI.Character
{
    public class UiCharacterDeath : UiListener,GameEvents.IDoKill
    {
        const float TimeUntilRemoveUnit = 1;
        IUiCharacterData MyData { get; set; }

        void GameEvents.IDoKill.OnKill(IRuntimeCharacter target)
        {
            if (target == MyData.RuntimeData && gameObject.activeSelf)
                StartCoroutine(RemoveEffectively(target));
        }

        void Awake() => MyData = GetComponent<IUiCharacterData>();

        IEnumerator RemoveEffectively(IRuntimeCharacter target)
        {
            yield return new WaitForSeconds(TimeUntilRemoveUnit);
            //TODO: CharacterFactory 
        }

    }
}