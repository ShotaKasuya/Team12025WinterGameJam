using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Utility.Structure.HttpClient.Client
{
    /**
     * Useful utility to use REST access to server
     */
    public class RestClient
    {
        /**
         * Host name of server
         * This must be endpoint URI of the server
         */
        private string HostName { get; }

        protected RestClient(string hostName)
        {
            HostName = hostName;
        }

        /**
         * Perform GET request to the path
         */
        protected UniTask<T> Get<T>(string path)
        {
            var req = UnityWebRequest.Get(GetURL(path));
            return ProcessRequest<T>(req);
        }

        /**
        * Perform PUT request to the path
        * You can specify content also
        */
        protected UniTask<T> Put<T>(string path, string content = "")
        {
            var req = UnityWebRequest.Put(this.GetURL(path), content);
            return ProcessRequest<T>(req);
        }

        /**
        * Perform DELETE request to the path
        */
        protected UniTask<T> Delete<T>(string path)
        {
            var req = UnityWebRequest.Delete(this.GetURL(path));
            return ProcessRequest<T>(req);
        }

        /**
        * Perform HEAD request to the path
        */
        protected UniTask<T> Head<T>(string path)
        {
            var req = UnityWebRequest.Head(this.GetURL(path));
            return ProcessRequest<T>(req);
        }

        /**
        * Perform POST request to the path
        * You can specify parameter as dictioanry
        */
        protected UniTask<T> Post<T>(string path, Dictionary<string, string> param = null)
        {
            if (param == null)
            {
                param = new Dictionary<string, string>();
            }

            var req = UnityWebRequest.Post(this.GetURL(path), param);
            return ProcessRequest<T>(req);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static async UniTask<T> ProcessRequest<T>(UnityWebRequest req)
        {
            await req.SendWebRequest();
            AssertRequestErrors(req);
            return JsonUtility.FromJson<T>(req.downloadHandler.text);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void AssertRequestErrors(UnityWebRequest req)
        {
            if (req.result == UnityWebRequest.Result.ProtocolError |
                req.result == UnityWebRequest.Result.ConnectionError)
            {
                throw new Exception(req.error);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string GetURL(string path)
        {
            return $"{HostName}{path}";
        }
    }
}