using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceArea : MonoBehaviour
{

    // We have an animation of fade in every time we start a new Scene.

    [SerializeField] string transitionName;


    private void Start()
    {
        if (transitionName == SceneManagment.Instance.SceneTransitionName)
        {
            PlayerController.Instance.transform.position = this.transform.position;
            CameraController.Instance.SetPlayerCameraFollow();
        }
    }

}
