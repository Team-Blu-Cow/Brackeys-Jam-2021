using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        blu.App.GetModule<blu.SceneModule>().SwitchScene("SampleScene", blu.TransitionType.Fade, blu.LoadingBarType.BottomRightRadial);
    }
}