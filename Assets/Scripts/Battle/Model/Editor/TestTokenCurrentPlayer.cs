﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using SimpleCardGames.Battle;
using SimpleCardGames.Infrastructure;

namespace SimpleCardGames.Tests
{
    public class GameLogicTests
    {
        public class TokenCurrentPlayerTest
        {
            [Test]
            public void CreateTokenWithZeroPlayers_ArgumentError()
            {
                var emptyList = new List<IPlayer>();

                void CreateBrokenToken()
                {
                    var token = (ProcessTurn) A.Token().WithPlayers(emptyList);
                }

                Assert.Throws<ArgumentException>(CreateBrokenToken);
            }

            [Test]
            public void CreateTokenWith2Players_RegularInitialState()
            {
                var player = (Player) A.Player().WithSeat(PlayerSeat.Left);
                var player1 = (Player) A.Player().WithSeat(PlayerSeat.Right);
                var players = new List<IPlayer> {player, player1};
                var token = (ProcessTurn) A.Token().WithPlayers(players);

                //initial state has turn count equals to zero
                Assert.AreEqual(token.TurnCount, 0);
                //on initial state starter and current are the same
                Assert.AreEqual(token.StarterPlayer, token.CurrentPlayer);
            }

            [Test]
            public void UpdatePlayerIndex10TimesFrom0()
            {
                var player = (Player) A.Player().WithSeat(PlayerSeat.Left);
                var player1 = (Player) A.Player().WithSeat(PlayerSeat.Right);
                var players = new List<IPlayer> {player, player1};
                var token = (ProcessTurn) A.Token().WithPlayers(players);
                var quantPlayers = players.Count;

                const PlayerSeat firstSeat = PlayerSeat.Left;
                token.SetCurrentSeat(firstSeat);
                token.SetStarterSeat(firstSeat);

                const int n = 10;
                //Update the index n times
                for (var i = 0; i < n; i++) token.UpdateCurrentPlayer();

                //turn count has to be the same as n
                Assert.AreEqual(token.TurnCount, n);
                //+1 because we don't update the index on the first attempt
                var turnMod = n + 1 % quantPlayers;
                Assert.AreEqual(PlayerSeat.Right, token.CurrentPlayerSeat);
            }

            [Test]
            public void UpdateTokenFrom0_IndexRemainsTheSame()
            {
                const PlayerSeat firstPlayerSeat = PlayerSeat.Left;
                var token = (ProcessTurn) A.Token()
                    .WithCurrentSeat(firstPlayerSeat)
                    .WithStartSeat(firstPlayerSeat);


                token.UpdateCurrentPlayer();

                //set indexes to zero
                const PlayerSeat expectedIndex = PlayerSeat.Right;
                //current remains zero
                Assert.AreEqual(firstPlayerSeat, token.CurrentPlayerSeat);
                //next remains zero + 1
                Assert.AreEqual(expectedIndex, token.NextPlayerSeat);
            }

            [Test]
            public void GetNextIndexFromZero_IndexIsOne()
            {
                const PlayerSeat firstPlayerSeat = PlayerSeat.Left;
                var player = (Player) A.Player().WithSeat(PlayerSeat.Left);
                var player1 = (Player) A.Player().WithSeat(PlayerSeat.Right);
                var players = new List<IPlayer> {player, player1};
                var token = (ProcessTurn) A.Token()
                    .WithPlayers(players)
                    .WithCurrentSeat(firstPlayerSeat)
                    .WithStartSeat(firstPlayerSeat);

                //set indexes to zero
                const PlayerSeat expectedIndex = PlayerSeat.Right;
                Assert.AreEqual(token.NextPlayerSeat, expectedIndex);
            }
        }
    }
}