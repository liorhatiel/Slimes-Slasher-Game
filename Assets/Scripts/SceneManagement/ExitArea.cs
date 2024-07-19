using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{

    [SerializeField] string sceneToLoad;                              // To which SCENE we want to go.
    [SerializeField] string sceneTransitionName;                      // WHERE ON THE SCENE we want to go.
                                                                      // This string sould be the same like the one on "EntranceArea" script.

    [SerializeField] Animator transition;                             // Refrence to the fase Screen animator. 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(EndLevelFadeAnimationRoutine());
            //SceneManager.LoadScene(sceneToLoad);
            //SceneManagment.Instance.SetTransitionName(sceneTransitionName);
        }
    }


    IEnumerator EndLevelFadeAnimationRoutine()
    {
        // Trigger the "End" animation
        transition.SetTrigger("End");

        // Wait for the animation to complete (1 second)
        yield return new WaitForSeconds(1f);

        // Load the next scene
        SceneManager.LoadScene(sceneToLoad);
        SceneManagment.Instance.SetTransitionName(sceneTransitionName);
    }

}
