using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Singleton;

public class SetColorHelper : Singleton<SetColorHelper>
{
    public List<Color> colors;
    private Color color = Color.white;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);

        colors.Add(color);
        colors.Add(color);
    }
}
