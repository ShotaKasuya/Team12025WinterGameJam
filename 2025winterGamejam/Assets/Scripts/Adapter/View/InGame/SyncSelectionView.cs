using Adapter.IView.InGame.Schema;
using Adapter.IView.OutGame.Schema;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility.Structure.HttpClient;
using Utility.Structure.HttpClient.Shared;
using Utility.Structure.InGame;

namespace Adapter.View.InGame
{
    public class SyncSelectionView : RestClient, ISyncSelectionSchema
    {
        private const string Path = "todo!";

        protected SyncSelectionView(string hostName) : base(hostName)
        {
        }

        public async UniTask PushSelection(PlayerCard playerCard)
        {
            var resp = await PostJson<PlayerCard, ResponseOk>(Path, playerCard);
            if (resp.IsError(out var error))
            {
                Debug.LogError(error);
            }
        }

        public async UniTask<PlayerSelection> PollSelection(Room room)
        {
            return await Get<PlayerSelection>(Path);
        }
    }
}