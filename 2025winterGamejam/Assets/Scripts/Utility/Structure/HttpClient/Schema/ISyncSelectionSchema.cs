using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility.Structure.InGame;

namespace Utility.Structure.HttpClient.Schema
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
        UniTask PushSelection(ref PlayerCard playerCard);

        /// <summary>
        /// サーバーから他プレイヤーの選択したカードをポーリングする
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        UniTask<PlayerSelection> PollSelection(ref Room room);
    }

    [Serializable]
    public struct PlayerSelection
    {
        [SerializeField] private PlayerCard[] selections;

        public PlayerCard[] Selections => selections;
    }
}