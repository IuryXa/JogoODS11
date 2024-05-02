using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Missoes : MonoBehaviour
{
    public GameObject[] missaoLayout;//Layout para fazer call out
    public GameObject missaoConcluida;
    public TMP_Text[] tituloMissao;//Titulo da Missão
    public string[] textoTituloMissao;//Texto do titulo da missão
    public TMP_Text[] textoMissao;//TMP_Text da Missão
    public string[] textoObjetivoMissao = {"",""};//Inserir objetivo da missão
    public float[] dinheiro = {0,0};
    public int[] progressoMissao = {0,0};//Inserir o progresso do jogador na missão
    public int[] objetivoFinalMissao = {0,0};//Objetivo que o jogador tem que alcançar na missão
    public bool[] progrediuObjetivo = {false, false};//Pergunta se o jogador avamçou no objetivo
    private float delayInSeconds = 2f;
    public PROPRIEDADES_JOGADOR money;
    public int[] idMissaoAtual;
    public int tipoMissaoAtual; //(0) é para missões principais e (1) é para missões secundarias
    public bool[] acabouAMissao = {false, false};

    public void Missao()
    {
        missaoLayout[tipoMissaoAtual].SetActive(true);
        textoMissao[tipoMissaoAtual].SetText(textoObjetivoMissao[tipoMissaoAtual] + $"({progressoMissao[tipoMissaoAtual]}/{objetivoFinalMissao[tipoMissaoAtual]})");
        tituloMissao[tipoMissaoAtual].SetText(textoTituloMissao[tipoMissaoAtual]);
    }
    void Start()
    {
        missaoLayout[0].SetActive(false);
        missaoLayout[1].SetActive(false);
        missaoConcluida.SetActive(false);
    }

    void Update()
    {

    }

    public void CheckDaMissao()
    {
        if (progrediuObjetivo[tipoMissaoAtual] && progressoMissao[tipoMissaoAtual] <= objetivoFinalMissao[tipoMissaoAtual])
        {
            progressoMissao[tipoMissaoAtual]++;
            progrediuObjetivo[tipoMissaoAtual] = false;
            textoMissao[tipoMissaoAtual].SetText(textoObjetivoMissao[tipoMissaoAtual] + $"({progressoMissao[tipoMissaoAtual]}/{objetivoFinalMissao[tipoMissaoAtual]})");
        }
        if (progressoMissao[tipoMissaoAtual] == objetivoFinalMissao[tipoMissaoAtual])
        {
            Invoke("EsconderConclusao", delayInSeconds);
            missaoLayout[tipoMissaoAtual].SetActive(false);
            missaoConcluida.SetActive(true);
            money.dinheiro += dinheiro[tipoMissaoAtual];
            Debug.Log(money.dinheiro);//
            idMissaoAtual[tipoMissaoAtual] = 0;
        }
    }
    private void EsconderConclusao()
    {
        missaoConcluida.SetActive(false);
        acabouAMissao[tipoMissaoAtual] = true;
        idMissaoAtual[tipoMissaoAtual] = 0;
    }
}
