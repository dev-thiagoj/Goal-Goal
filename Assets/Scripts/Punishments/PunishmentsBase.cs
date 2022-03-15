using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunishmentsBase : MonoBehaviour
{
    public string[] punishments;
    
    // Start is called before the first frame update
    void Start()
    {
        punishments[0] = "Colocar dois dedos dentro de uma narina";
        punishments[1] = "Girar 10x e no fim por o indicador na ponta do nariz";
        punishments[2] = "Fazer 10 polichinelos";
    }

    // Update is called once per frame
    void Update()
    {
        foreach(string punishment in punishments){

            Debug.Log(punishment);
        }
    }
}
