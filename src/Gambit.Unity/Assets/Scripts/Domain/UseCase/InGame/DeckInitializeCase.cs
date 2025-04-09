using System;
using System.Collections.Generic;
using System.Linq;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gambit.Unity.Domain.UseCase.InGame
{
    public class DeckHandCardInitializeCase : IDeckInitCase
    {
        public DeckHandCardInitializeCase
        (
            IPlayerDictionaryModel playerDictionaryModel,
            IRoomInfoModel roomInfoModel,
            IMutDeckModel deckModel
        )
        {
            PlayerDictionaryModel = playerDictionaryModel;
            RoomInfoModel = roomInfoModel;
            DeckModel = deckModel;
        }

        public void DeckInitialize()
        {
            var len = DeckModel.Decks.Length;
            var decks = RandomDecks(len);

            foreach (var deck in decks)
            {
                Debug.Log(deck);
            }

            for (var i = 0; i < len; i++)
            {
                DeckModel.Decks[i] = decks[i];
            }
        }
        
        private Deck[] RandomDecks(int deckNum)
        {
            var suitNum = Enum.GetValues(typeof(Suit)).Length;
            var rankNum = Enum.GetValues(typeof(Rank)).Length;

            var decks = new Card[deckNum, suitNum * rankNum / deckNum];
            var cards = Card.AllCards().ToList();
            Random.InitState(RoomInfoModel.RoomSeed);
            for (int i = 0; i < deckNum; i++)
            {
                for (int j = 0; j < suitNum * rankNum / deckNum; j++)
                {
                    var index = Random.Range(0, cards.Count);
                    decks[i, j] = cards[index];
                    cards.RemoveAt(index);
                }
            }

            var result = new Deck[deckNum];
            for (var i = 0; i < deckNum; i++)
            {
                var deck = GetRow(i);
                result[i] = new Deck(deck, PlayerDictionaryModel.PlayerIds[i], i);
            }

            return result;

            List<Card> GetRow(int rowIndex)
            {
                var cols = decks.GetLength(1);
                var row = new List<Card>(cols);
                for (var i = 0; i < cols; i++)
                {
                    var card = decks[rowIndex, i];
                    row.Add(card);
                }

                return row;
            }
        }

        private IPlayerDictionaryModel PlayerDictionaryModel { get; }
        private IRoomInfoModel RoomInfoModel { get; }
        private IMutDeckModel DeckModel { get; }
    }
}