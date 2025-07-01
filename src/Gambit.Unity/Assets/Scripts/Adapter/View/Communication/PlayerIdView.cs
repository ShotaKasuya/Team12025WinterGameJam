using Gambit.Shared.DataTransferObject;
using Gambit.Unity.Adapter.IView.UseCommunication;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.Communication
{
    public class PlayerIdView: IPlayerIdView, IPlayerIdInitializeView
    {
        private PlayerIdTransferObject[] _playerIdTransferObjects;
        public PlayerId GetPlayerId(PlayerIdTransferObject playerIdTransferObject)
        {
            var index = 0;
            foreach (var idTransferObject in _playerIdTransferObjects)
            {
                if (idTransferObject == playerIdTransferObject)
                {
                    break;
                }

                index++;
            }
            return new PlayerId(index);
        }

        public PlayerIdTransferObject GetPlayerId(PlayerId playerId)
        {
            return _playerIdTransferObjects[playerId.Id];
        }

        public void Init(PlayerIdTransferObject[] playerIdTransferObjects)
        {
            _playerIdTransferObjects = playerIdTransferObjects;
            var str = "";
            foreach (var idTransferObject in playerIdTransferObjects)
            {
                str += idTransferObject.ToString();
            }

            Debug.Log(str);
        }
    }
}