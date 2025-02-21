using UnityEngine;
using Utility.Module.Installer;

namespace Installer
{
    public class GlobalLocator : InstallerBase
    {
        public static GlobalLocator Instance
        {
            get
            {
                if (_instance is null)
                {
                    var instance = FindFirstObjectByType<GlobalLocator>();
                    if (instance is null)
                    {
                        Debug.LogError($"find object failed! : {nameof(GlobalLocator)}");
                    }

                    _instance = instance;
                }

                return _instance;
            }
        }

        private static GlobalLocator _instance;

        protected override void CustomConfigure()
        {
            if (_instance is null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            _instance.Dispose();
            _instance = null;
        }
    }

}