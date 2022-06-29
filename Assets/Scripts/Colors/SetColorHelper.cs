using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Singleton;

public class SetColorHelper : Singleton<SetColorHelper>
{
    public List<Color> colors;
    private Color color;
    //private Image image;

    public GameObject Player01;
    public GameObject Player02;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);

        colors.Add(color);
        colors.Add(color);
    }
}
