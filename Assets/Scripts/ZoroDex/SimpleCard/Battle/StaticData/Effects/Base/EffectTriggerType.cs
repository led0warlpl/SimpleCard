namespace ZoroDex.SimpleCard.Data.Effects
{
    public enum EffectTriggerType
    {
        // Deck
        OnPlay, // Relic Done
        OnDraw, // Relic Done
        OnDiscard, // Relic Done
        OnDeckShuffle, // Relic Done
        
        // Turn
        OnPlayerStartTurn, // Relic DOne
        OnPlayerFinishTurn, // Relic Done
        
        // Character
        OnPlayerDamageTaken, // Pushed to ticket
        OnPlayerMinionSummon, // Relic Done
        OnPlayerMinionDeath, // Relic Done
        
        OnEnemyMinionSummon, // Relic Done
        OnEnemyMinionDeath, // Relic Done
        
        //Draw Cards
        OnDrawMinionCard, // Relic Done
        OnDrawSpellCard, // Relic Done
        OnDrawPowerCard, // Relic Done
        OnDrawCurseCard, // Relic Done
        
        //Play Card
        OnPlayMinionCard,
        OnPlaySpellCard,
        OnPlayPowerCard,
        OnPlayCurseCard,
        
        //Discard Cards
        OnDiscardMinionCard,
        OnDiscardSpellCard,
        OnDiscardPowerCArd,
        OnDiscardCurseCArd,
        
        //Adventure
        OnEnterBattle,
        
        //These conditions can't use the normal game event listeners. Need to code another way
        OnEnterReward,
        OnEnterShop,
        OnEnterTreasure,
        OnEnterChance
        
    }
}