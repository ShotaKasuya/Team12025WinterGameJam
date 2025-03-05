using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.InGame.Schema;
using Gambit.Unity.Adapter.IView.OutGame.Schema;
using Gambit.Unity.Structure.Utility.HttpClient;
using Gambit.Unity.Structure.Utility.HttpClient.Shared;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame
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