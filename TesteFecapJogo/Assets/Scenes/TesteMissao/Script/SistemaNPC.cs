using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaNPC : MonoBehaviour, IInteractable
{
    public Missoes quest;
    public int trackProgresso;
    public string textoObjetivoMissao = "";
    public int objetivoFinalMissaoInte = 0;
    public void Interact()
    {
        quest.textoObjetivoMissao = textoObjetivoMissao;
        quest.progressoMissao = 0;
        quest.objetivoFinalMissao = objetivoFinalMissaoInte;
        quest.Missao();
    }
    
    public void Coletou()
    {
        quest.progrediuObjetivo = true;
        quest.CheckDaMissao();
    }
}
