using System;
using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.OutGame.Schema;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.IView.InGame.Schema
{
    /// <summary>
    /// カード選択を同期するためのスキーマ
    /// </summary>
    public interface ISyncSelectionSchema
    {
        /// <summary>
        /// サーバーに選択したカードを送信する
        /// </summary>
        /// <param name="playerCard">選択したカード</param>
        /// <returns></returns>
        UniTask PushSelection(PlayerCard playerCard);

        /// <summary>
        /// サーバーから他プレイヤーの選択したカードをポーリングする
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        UniTask<PlayerSelection> PollSelection(Room room);
    }

    [Serializable]
    public struct PlayerSelection
    {
        [SerializeField] private PlayerCard[] selections;

        public PlayerCard[] Selections => selections;
    }
}