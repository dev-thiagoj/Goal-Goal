using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PunishmentsBase : MonoBehaviour
{
    private string[] punishments = new string[10];

    public TextMeshProUGUI uiTextPunishment;

    private void Awake()
    {
        punishments[0] = "Colocar dois dedos dentro de uma narina";
        punishments[1] = "Girar 10x e no fim por o indicador na ponta do nariz";
        punishments[2] = "teste 01";
        punishments[3] = "teste 02";
        punishments[4] = "teste 03";
        punishments[5] = "teste 04";
        punishments[6] = "teste 05";
        punishments[7] = "teste 06";
        punishments[8] = "teste 07";
        punishments[9] = "teste 08";
    }

    // Start is called before the first frame update
    void Start()
    {
        GetPunishment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPunishment()
    {
        uiTextPunishment.text = punishments[Random.Range(0, 9)];
    }
}
