using System;
using System.Runtime.CompilerServices;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Utility.Structure.HttpClient
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
        protected async UniTask<TResponse> PostJson<TRequest, TResponse>(string path, TRequest data)
        {
            var json = ToJson(data);
            using var request = new UnityWebRequest(GetURL(path), "POST");
            request.SetRequestHeader("Content-Type", "application/json");

            var jsonBytes = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonBytes);
            request.downloadHandler = new DownloadHandlerBuffer();

            await ProcessRequest<TResponse>(request);

            var responseJson = request.downloadHandler.text;
            return JsonUtility.FromJson<TResponse>(responseJson);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string ToJson<T>(T value)
        {
            if (!typeof(T).IsDefined(typeof(SerializableAttribute), false))
            {
                Debug.LogError($"{typeof(T).Name} is not defined serializable");
            }

            return JsonUtility.ToJson(value);
        }
    }
}