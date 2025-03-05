using System;
using Gambit.Unity.Module.Utility.Module.Option;
using UnityEngine;

namespace Gambit.Unity.Structure.Utility.HttpClient.Shared
{
    [Serializable]
    public class ResponseOk
    {
        [SerializeField] private Option<string> errorMessage;

        public bool IsError(out string error)
        {
            var isError = errorMessage.TryGetValue(out var value);
            error = isError ? value : string.Empty;

            return isError;
        }
    }
}