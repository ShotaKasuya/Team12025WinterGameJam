using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility.Structure.HttpClient.Shared;
using Utility.Structure.InGame;

namespace Adapter.IView.OutGame.Schema
{
    /// <summary>
    /// 入室処理に必要な通信スキーマ
    /// </summary>
    public interface IJoinRoom
    {
        /// <summary>
        /// 部屋リストの取得
        /// </summary>
        /// <returns>部屋リスト</returns>
        UniTask<RoomList> GetRoomList();

        /// <summary>
        /// 新しい部屋を作成する
        /// </summary>
        /// <param name="roomName">部屋名</param>
        /// <returns></returns>
        UniTask<PlayerId> MakeNewRoom(MakeNewRoomRequest roomName);
    }

    [Serializable]
    public struct RoomList
    {
        [SerializeField] private Room[] rooms;

        public IReadOnlyList<Room> Rooms => rooms;
    }
    
    [Serializable]
    public struct Room
    {
        [SerializeField] private int id;
        [SerializeField] private PlayerId ownerId;
        [SerializeField] private string name;

        public int Id => id;
        public PlayerId OwnerId => ownerId;
        public string Name => name;
    }
}