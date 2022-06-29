using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorBase : MonoBehaviour
{
    public Color color;

    [Header("References")]
    public Image uiImage;
    //public SpriteRenderer spriteRenderer;

    //public Player myPlayer;

    //public List<Image> images;

    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        uiImage.color = color;
        
        //GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick(int i)
    {
        //myPlayer.ChangeColor(color);

        SetColorHelper.Instance.colors[i] = color;
    }
}
