using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Singleton;

public class PunishmentsBase : Singleton<PunishmentsBase>
{
    private readonly string[] punishments = new string[9];

    public TextMeshProUGUI uiTextPunishment;

    protected override void Awake()
    {
        base.Awake();

        punishments[0] = "Colocar dois dedos dentro de uma narina";
        punishments[1] = "Girar 10x e no fim por o indicador na ponta do nariz";
        punishments[2] = "Realizar 20 polichinelos";
        punishments[3] = "Fazer a careta mais feia, tirar foto e publicar na rede social favorita";
        punishments[4] = "Ajoelhar e pedir perdão ao vencedor por ter tentado desafiá-lo";
        punishments[5] = "Dar 3 voltas completas no vencedor pulando em um pé só";
        punishments[6] = "Lamber o próprio cotovelo";
        punishments[7] = "Por a ponta da lingua no nariz";
        punishments[8] = "Sem castigo, deu sorte";
    }

    private void Start()
    {
        GetPunishment();
    }

    public void GetPunishment()
    {
        uiTextPunishment.text = punishments[Random.Range(0, punishments.Length)];
    }
}
