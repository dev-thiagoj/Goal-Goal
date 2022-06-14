using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenuScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(LoadSceneFromGameManager), 5);
    }

    void LoadSceneFromGameManager()
    {
        GameManager.Instance.LoadMenuScene();
    }
}
