using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaNPCPrincipal : MonoBehaviour, IInteractable
{

    private Missoes quest; //Pega o gameobject que cont�m o script das miss�es
    public string tituloMissao;
    public string textoObjetivoMissao = ""; //String para inserir o texto do objetivo da miss�o
    public int objetivoFinalMissaoInte = 0;//Inserir a quantidade de tarefas que o jogador tem que alcan�ar para concluir a miss�o
    public float dinheiroMissao;
    public int idMissao; //Usado para identificar e diferenciar miss�es 
    public int tipoMissao = 0; //(0) � para miss�es principais e (1) � para miss�es secundarias
    public int selecionarOqueFazer;
    //"Coleta de Lixo", "Arboriza��o", "Varrer as ruas", "Desentupir boeiros"
    public bool comecouPrincipal = false;

    void Start()
    {
        quest = GameObject.Find("MissaoGameObject").GetComponent<Missoes>();
    }

    void Update()
    {
        if (idMissao == quest.idMissaoAtual[tipoMissao] && quest.acabouAMissao[tipoMissao])//Verifica se o ID da miss�o desse script � igual ao ID da miss�o no script "Missoes", tamb�m verifica se a bool miss�o acabou � verdadeira
        {
            this.gameObject.GetComponent<SistemaNPCPrincipal>().enabled = false;//Desativa o Script no gameobject em que ele est� inserido
        }
    }

    public void Interact()
    {
        Interagiu();
        this.gameObject.GetComponent<SistemaNPCSecundario>().InteragiuSecundario();

    }
    
    public void Coletou()
    {
        quest.progrediuObjetivo[tipoMissao] = true;
        quest.CheckDaMissao();
    }

    private void Interagiu()
    {
        quest.dinheiro[tipoMissao] = dinheiroMissao;
        quest.textoTituloMissao[tipoMissao] = tituloMissao;
        quest.tipoMissaoAtual = tipoMissao;
        quest.acabouAMissao[quest.tipoMissaoAtual] = false;
        quest.textoObjetivoMissao[tipoMissao] = textoObjetivoMissao;
        quest.progressoMissao[tipoMissao] = 0;
        quest.objetivoFinalMissao[tipoMissao] = objetivoFinalMissaoInte;
        quest.idMissaoAtual[tipoMissao] = idMissao;
        comecouPrincipal = true;
        quest.Missao();
    }
}
