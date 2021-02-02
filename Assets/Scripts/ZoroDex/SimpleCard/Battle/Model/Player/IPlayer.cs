using Tools;
using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard
{
    public interface IPlayer : ITargetable,IDrawable,IDiscardable,ISpawner,IManaManipulator
    {
        Configurations Configurations { get; }
        Collection<IRuntimeCard> Hand { get; }
        PlayerSeat Seat { get; }
        ILibrary Library { get; }
        Graveyard Graveyard { get; }
        
        ITeam Team { get; }
        int Mana { get; }
        void StartTurn();
        void FinishTurn();
        void DrawStartingHand();
        bool Draw();
        bool Play(IRuntimeCard card);
        bool CanPlay(IRuntimeCard card);
        bool Discard(IRuntimeCard card);

    }
}