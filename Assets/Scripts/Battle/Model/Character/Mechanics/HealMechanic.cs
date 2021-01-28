﻿namespace SimpleCardGames.Battle
{
    public class HealMechanic : CharMechanic
    {
        public HealMechanic(IRuntimeCharacter character) : base(character)
        {
        }

        public int DoHeal(IHealable target, int bonusHeal) => target.TakeHeal(Character, bonusHeal);
    }
}