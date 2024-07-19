using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagment : Singelton<SceneManagment> 
{
  public string SceneTransitionName { get; private set; }

    public void SetTransitionName(string sceneTransitionName)
    {
        SceneTransitionName = sceneTransitionName;
    }
}
