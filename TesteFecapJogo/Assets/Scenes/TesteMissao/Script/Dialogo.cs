using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogo : MonoBehaviour, IInteractable
{
    public GameObject dialogoBox;
    public TMP_Text dialogo;
    public TMP_Text nome;
    public string[] dialogoatual= {"Olá","Tudo bem?" };
    public int numeroDeDialogos=0;
    public bool dialogoFinal = false;
    void Start()
    {
        dialogoBox.SetActive(false);
    }

    public void Interact()
    {
        dialogoBox.SetActive(true);
        dialogo.SetText(dialogoatual[0]);
        DialogoComecou();
    }
    void DialogoComecou()
    {
        while (dialogoFinal)
        {
            if (Input.GetButton("Fire1"))
            {
                numeroDeDialogos++;
                dialogo.SetText(dialogoatual[numeroDeDialogos]);
            }
        }
    }
}
