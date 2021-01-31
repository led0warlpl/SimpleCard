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
        
    }
}