using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PunishmentsBase : MonoBehaviour
{
    private readonly string[] punishments = new string[10];

    public TextMeshProUGUI uiTextPunishment;

    private void Awake()
    {
        punishments[0] = "Colocar dois dedos dentro de uma narina";
        punishments[1] = "Girar 10x e no fim por o indicador na ponta do nariz";
        punishments[2] = "Realizar 20 polichinelos";
        punishments[3] = "Fazer a careta mais feia, tirar foto e publicar na rede social favorita";
        punishments[4] = "Ajoelhar e pedir perd�o ao vencedor por ter tentado desafi�-lo";
        punishments[5] = "Dar 3 voltas completas no vencedor pulando em um p� s�";
        punishments[6] = "Lamber o pr�prio cotovelo";
        punishments[7] = "Por a ponta da lingua no nariz";
        punishments[8] = "Deixar o vencedor chutar sua canela e n�o pode chorar";
        punishments[9] = "Sem castigo, deu sorte";
    }

    // Start is called before the first frame update
    void Start()
    {
        GetPunishment();
    }

    public void GetPunishment()
    {
        uiTextPunishment.text = punishments[Random.Range(0, punishments.Length)];
    }
}
