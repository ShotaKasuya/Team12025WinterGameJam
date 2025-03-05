using System;
using UnityEngine;

namespace Gambit.Unity.Structure.Utility.HttpClient.Shared
{
    [Serializable]
    public struct MakeNewRoomRequest
    {
        [SerializeField] private string roomName;

        public string RoomName => roomName;
    }
}