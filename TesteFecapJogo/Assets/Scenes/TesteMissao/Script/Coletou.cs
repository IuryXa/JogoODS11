using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletou : MonoBehaviour, IInteractable
{
    public Missoes missao;
    public SistemaNPC coleta;
    public GameObject coletavel;
    public void Interact()
    {
        if (missao.objetivoFinalMissao > 0)
        {
            coleta.Coletou();
            coletavel.SetActive(false);
        }
    }
    void Start()
    {
        
    }
}
