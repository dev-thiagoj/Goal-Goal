using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadSceneHelper : MonoBehaviour
{
    public bool isLogoScene = true;

    // Start is called before the first frame update
    void Start()
    {
        if(isLogoScene) Invoke(nameof(LoadSceneFromGameManager), 5);
    }

    public void LoadSceneFromGameManager()
    {
        GameManager.Instance.LoadMenuScene();
    }
}
