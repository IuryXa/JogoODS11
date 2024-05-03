using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Missoes : MonoBehaviour
{
    public GameObject[] missaoLayout;//Layout para fazer call out
    public GameObject missaoConcluida;
    public GameObject missaoFalhou;
    public TMP_Text[] tituloMissao;//Titulo da Missão
    public string[] textoTituloMissao;//Texto do titulo da missão
    public TMP_Text[] textoMissao;//TMP_Text da Missão
    public string[] textoObjetivoMissao = {"",""};//Inserir objetivo da missão
    public float[] dinheiro = {0,0};
    public int[] progressoMissao = {0,0};//Inserir o progresso do jogador na missão
    public int[] objetivoFinalMissao = {0,0};//Objetivo que o jogador tem que alcançar na missão
    public bool[] progrediuObjetivo = {false, false};//Pergunta se o jogador avamçou no objetivo
    public PROPRIEDADES_JOGADOR money;
    public int[] idMissaoAtual;
    public int tipoMissaoAtual; //(0) é para missões principais e (1) é para missões secundarias
    public bool[] acabouAMissao = { false, false };
    public float tempoParaFinal;
    public TMP_Text tempoTexto;

    private GameObject Tempo;
    
    private bool temTempo = false;
    private float delayInSeconds = 2f;

    public void Missao()
    {
        missaoLayout[tipoMissaoAtual].SetActive(true);
        textoMissao[tipoMissaoAtual].SetText(textoObjetivoMissao[tipoMissaoAtual] + $"({progressoMissao[tipoMissaoAtual]}/{objetivoFinalMissao[tipoMissaoAtual]})");
        tituloMissao[tipoMissaoAtual].SetText(textoTituloMissao[tipoMissaoAtual]);
    }
    void Start()
    {
        Tempo = GameObject.Find("Tempo");
        Tempo.SetActive(false);
        missaoLayout[0].SetActive(false);
        missaoLayout[1].SetActive(false);
        missaoConcluida.SetActive(false);
        missaoFalhou.SetActive(false);
    }

    void Update()
    {
        if (acabouAMissao[tipoMissaoAtual] = false && tempoParaFinal > 0)
        {
            Tempo.SetActive (true);
            tempoParaFinal -= Time.deltaTime;
            tempoTexto.SetText($"Tempo restante {(int)tempoParaFinal}");
            temTempo = true;
        }else if (acabouAMissao[tipoMissaoAtual] = false &&tempoParaFinal <= 0 && temTempo)
        {
            Tempo.SetActive(false);
            missaoFalhou.SetActive(true);
            missaoLayout[tipoMissaoAtual].SetActive(false);
            Invoke("MissaoFalhou", delayInSeconds);
            temTempo=false;
        }
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
            acabouAMissao[tipoMissaoAtual] = true;
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

    private void MissaoFalhou()
    {
        missaoFalhou.SetActive(false);
        acabouAMissao[tipoMissaoAtual] = true;
        idMissaoAtual[tipoMissaoAtual] = 0;
    }
}
