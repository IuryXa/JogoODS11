using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Missoes : MonoBehaviour
{
    public GameObject missaoLayout;//Layout para fazer call out
    public GameObject missaoConcluida;
    public TMP_Text textoMissao;//TMP_Text da Missão
    public string textoObjetivoMissao;//Inserir objetivo da missão
    public int progressoMissao;//Inserir o progresso do jogador na missão
    public int objetivoFinalMissao;//Objetivo que o jogador tem que alcançar na missão
    public bool progrediuObjetivo = false;//Pergunta se o jogador avamçou no objetivo
    private float delayInSeconds = 2.0f;
    public PROPRIEDADES_JOGADOR money;

    public void Missao()
    {
            missaoLayout.SetActive(true);
            textoMissao.SetText(textoObjetivoMissao+$"({progressoMissao}/{objetivoFinalMissao})");
    }
    void Start()
    {
        missaoLayout.SetActive(false);
        missaoConcluida.SetActive(false);
    }

    public void CheckDaMissao()
    {
            if (progrediuObjetivo && progressoMissao<=objetivoFinalMissao)
            {
                progressoMissao++;
                progrediuObjetivo = false;
            textoMissao.SetText(textoObjetivoMissao + $"({progressoMissao}/{objetivoFinalMissao})");
        }
        if (progressoMissao == objetivoFinalMissao)
        {
            missaoLayout.SetActive(false);
            missaoConcluida.SetActive(true);
            money.dinheiro = 0;
            Invoke("EsconderConclusao", delayInSeconds);
        }
    }
    private void EsconderConclusao()
    {
        missaoConcluida.SetActive(false);
    }
}
