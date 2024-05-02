using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaNPCPrincipal : MonoBehaviour, IInteractable
{

    private Missoes quest; //Pega o gameobject que contém o script das missões
    public string tituloMissao;
    public string textoObjetivoMissao = ""; //String para inserir o texto do objetivo da missão
    public int objetivoFinalMissaoInte = 0;//Inserir a quantidade de tarefas que o jogador tem que alcançar para concluir a missão
    public float dinheiroMissao;
    public int idMissao; //Usado para identificar e diferenciar missões 
    public int tipoMissao = 0; //(0) é para missões principais e (1) é para missões secundarias
    public int selecionarOqueFazer;
    //"Coleta de Lixo", "Arborização", "Varrer as ruas", "Desentupir boeiros"
    public bool comecouPrincipal = false;

    void Start()
    {
        quest = GameObject.Find("MissaoGameObject").GetComponent<Missoes>();
    }

    void Update()
    {
        if (idMissao == quest.idMissaoAtual[tipoMissao] && quest.acabouAMissao[tipoMissao])//Verifica se o ID da missão desse script é igual ao ID da missão no script "Missoes", também verifica se a bool missão acabou é verdadeira
        {
            this.gameObject.GetComponent<SistemaNPCPrincipal>().enabled = false;//Desativa o Script no gameobject em que ele está inserido
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
