using UnityEngine;

    public class Singleton<TManager> : MonoBehaviour where TManager : MonoBehaviour
    {
        private static TManager _instance;

        public static TManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TManager>();

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<TManager>();
                        singleton.name = typeof(TManager).ToString() + " (Singleton)";
                    }
                }
                return _instance;
            }
        }
    }