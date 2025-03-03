using System;
using UnityEngine;
using Utility.Module.Option;

namespace Utility.Structure.HttpClient.Shared
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