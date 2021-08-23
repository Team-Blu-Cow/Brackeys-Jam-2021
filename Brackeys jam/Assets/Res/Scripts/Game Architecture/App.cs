using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using System;

namespace blu
{
    public class App : MonoBehaviour
    {
        // Singleton instance
        [HideInInspector] private static App instance = null;

        private List<blu.Module> _modules = new List<blu.Module>();
        private blu.ModuleManager _moduleManager = new blu.ModuleManager();

        [HideInInspector] public static List<blu.Module> LoadedModules { get => instance._modules; }
        [HideInInspector] public static Transform Transform { get => instance.transform; }

        // set to true if different load orders are required due to
        // start up scenes.
        //private const bool _SceneDependantLoadOrder = false;

        private void Awake()
        {
            #region Singleton Code

            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            #endregion Singleton Code

            #region Per-Scene Switch Block

            switch (SceneManager.GetActiveScene().name)
            {
                case "SplashScreen":

                    AddBaselineModules();
                    break;

                case "MainMenu":

                    AddBaselineModules();
                    break;

                default: // default load order

                    AddBaselineModules();
                    break;
            }

            #endregion Per-Scene Switch Block
        }

        private void AddBaselineModules()
        {
            _moduleManager.AddModule<blu.SettingsModule>();
            _moduleManager.AddModule<blu.SceneModule>();
            _moduleManager.AddModule<blu.InputModule>();
            //_moduleManager.AddModule<blu.AudioModule>(); // not nessessary, included for readablility
        }

        public static T GetModule<T>() where T : blu.Module
        {
            return instance._moduleManager.GetModule<T>();
        }

        public static void AddModule<T>() where T : blu.Module
        {
            instance._moduleManager.AddModule<T>();
        }

        public static void RemoveModule<T>() where T : blu.Module
        {
            instance._moduleManager.RemoveModule<T>();
        }
    }
}