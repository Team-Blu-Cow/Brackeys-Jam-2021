using UnityEngine;

namespace blu
{
    public class InputModule : Module
    {
        public override void Initialize()
        {
            // If functions run twice after scene switch take a look at this: https://answers.unity.com/questions/1767382/removing-event-from-new-input-system-not-working.html
            Debug.Log("[App]: Initializing input module");
            Debug.Log("[App/InputModule]: All inputs are enabled by default");
            Debug.Log("[App/InputModule]: Remember to remove input functions on destuction!");
            SetUpControllers();
        }

        private void SetUpControllers()
        {
        }
    }
}