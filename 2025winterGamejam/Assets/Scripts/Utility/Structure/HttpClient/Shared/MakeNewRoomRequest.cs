using System;
using UnityEngine;

namespace Utility.Structure.HttpClient.Shared
{
    [Serializable]
    public struct MakeNewRoomRequest
    {
        [SerializeField] private string roomName;

        public string RoomName => roomName;
    }
}