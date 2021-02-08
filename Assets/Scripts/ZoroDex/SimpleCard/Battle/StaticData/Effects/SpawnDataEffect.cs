﻿using UnityEngine;
using ZoroDex.SimpleCard.Data.Character;

namespace ZoroDex.SimpleCard.Data.Effects
{
    [CreateAssetMenu(menuName = Path+"/Spawn")]
    public class SpawnDataEffect : BaseEffectData
    {
        [SerializeField] [Tooltip("Character who will be spawned")]
        private CharacterData characterData;

        public override void Apply(ITargetable target, IEffectable source)
        {
            var spawner = target as ISpawner;
            spawner.DoSpawn(Amount, characterData, source);
        }

        public CharacterData GetCharacterSpawnedFromEffect() => characterData;
    }
}