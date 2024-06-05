using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        private void Awake() {
            if (Instance == null) {
                Instance = FindObjectOfType<T>();
                Initialize();
                DontDestroyOnLoad(gameObject);
            }
            else {
                Destroy(this);
            }
        }

        protected abstract void Initialize();
    }
}
