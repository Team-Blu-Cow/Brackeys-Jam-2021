using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace blu
{
    public class SettingsModule : Module
    {
        protected override void SetDependancies()
        {
            _dependancies.Add(typeof(AudioModule));
        }

        public override void Initialize()
        {
            Debug.Log("[App]: Initializing settings module");
            return;
        }

        public static void Save() => PlayerPrefs.Save();
    }
}