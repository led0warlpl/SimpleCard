using ZoroDex.SimpleCard.Battle;
using ZoroDex.SimpleCard.Data.Deck;
using ZoroDex.SimpleCard.Data.Team;
using Tools;
using ZoroDex.SimpleCard.Data.Character;
using ZoroDex.SimpleCard.Data.Effects;

namespace ZoroDex.SimpleCard
{
    /// <summary>
    ///     A concrete player class.
    /// </summary>
    public class Player : IPlayer
    {
        public Player(PlayerSeat seat, TeamData teamData = null, LibraryData deckData = null,
            Configurations configurations = null)
        {
            Configurations = configurations;
            Seat = seat;
            Hand = new Collection<IRuntimeCard>();

            if (teamData != null)
                Team = new Team(this, teamData);

            if (deckData != null)
                Library = new Library(this, deckData, configurations);

            Graveyard = new Graveyard(this);

            #region Mechanics

            DrawMechanics = new DrawMechanics(this);
            DiscardMechanics = new DiscardMechanics(this);
            PlayCardMechanics = new PlayCardMechanics(this);
            StartTurnMechanics = new StartTurnMechanics(this);
            FinishTurnMecahnics = new FinishTurnMecahnics(this);
            SpawnMechanics = new SpawnMechanics(this);
            ManaMechanics = new ManaMechanics(this);

            #endregion

        }

        #region Properties

        public ILibrary Library { get; }
        public Graveyard Graveyard { get; }
        public ITeam Team { get; }
        public Collection<IRuntimeCard> Hand { get; }
        public Configurations Configurations { get; }
        public PlayerSeat Seat { get; }


        #endregion

        public void DoSpawn(int amount, ICharacterData data, IEffectable source) =>
            SpawnMechanics.DoSpawn(amount, data, source);


        #region Mechanics

        public DrawMechanics DrawMechanics { get; }
        public DiscardMechanics DiscardMechanics { get; }
        public PlayCardMechanics PlayCardMechanics { get; }
        public StartTurnMechanics StartTurnMechanics { get; }
        public FinishTurnMecahnics FinishTurnMecahnics { get; }
        public SpawnMechanics SpawnMechanics { get; }
        public ManaMechanics ManaMechanics { get; }

        #endregion

        #region Draw

        void IPlayer.DrawStartingHand() => DrawMechanics.DrawStartingHand();

        void IDrawable.DoDraw(int amount, IEffectable source) => DrawMechanics.DoDraw(amount, source);
        public bool Draw() => DrawMechanics.Draw();

        #endregion

        #region Discard

        void IDiscardable.DoDiscard(int amount, IEffectable source) => DiscardMechanics.DoDiscard(amount, source);

        public bool Discard(IRuntimeCard card) => DiscardMechanics.Discard(card);


        #endregion

        #region Play

        bool IPlayer.Play(IRuntimeCard card) => PlayCardMechanics.Play(card);

        public bool CanPlay(IRuntimeCard card) => PlayCardMechanics.CanPlay(card);

        #endregion

        #region Turn

        void IPlayer.FinishTurn() => FinishTurnMecahnics.FinishTurn();

        void IPlayer.StartTurn() => StartTurnMechanics.StartTurn();

        #endregion

        public int Mana => ManaMechanics.Mana;

        public bool HasMana(int amount) => ManaMechanics.HasMana(amount);
        public void ConsumeMana(int amount) => ManaMechanics.ConsumeMana(amount);

        public void ReplanishMana() => ManaMechanics.ReplenishMana();
    }
}