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
        punishments[2] = "Realizar 20 polichinelos";
        punishments[3] = "Fazer a careta mais feia, tirar foto e publicar na rede social favorita";
        punishments[4] = "Ajoelhar e pedir perdão ao vencedor por ter tentado desafiá-lo";
        punishments[5] = "Dar 3 voltas completas no vencedor pulando em um pé só";
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

    public void GetPunishment()
    {
        uiTextPunishment.text = punishments[Random.Range(0, 9)];
    }
}
