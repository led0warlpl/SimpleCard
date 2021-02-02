namespace ZoroDex.SimpleCard.Battle
{
    public interface IPlayerTurn
    {
        bool IsAi { get; }
        bool isUser { get; }
        bool IsMyTurn { get; }
        PlayerSeat Seat { get; }
        IPlayer Player { get; }
        bool PassTurn();
        void Attack(AttackMechanics.RuntimeAttackData attackData);

    }
}