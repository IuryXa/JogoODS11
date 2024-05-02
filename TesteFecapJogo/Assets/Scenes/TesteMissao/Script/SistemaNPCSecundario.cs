using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaNPCSecundario : MonoBehaviour
{

    private Missoes quest; //Pega o gameobject que cont�m o script das miss�es
    public string tituloMissao;
    public string textoObjetivoMissao = ""; //String para inserir o texto do objetivo da miss�o
    public int objetivoFinalMissaoInte = 0;//Inserir a quantidade de tarefas que o jogador tem que alcan�ar para concluir a miss�o
    public float dinheiroMissao;
    public int idMissao; //Usado para identificar a miss�o 
    public int tipoMissao = 1; //(0) � para miss�es principais e (1) � para miss�es secundarias
    public int selecionarOqueFazer;
    //"Coleta de Lixo", "Arboriza��o", "Varrer as ruas", "Desentupir boeiros"
    private SistemaNPCPrincipal sistemaNPCPrincipal;

    void Start()
    {
        quest = GameObject.Find("MissaoGameObject").GetComponent<Missoes>();
        sistemaNPCPrincipal = this.gameObject.GetComponent<SistemaNPCPrincipal>();
    }

    void Update()
    {
        if (idMissao == quest.idMissaoAtual[quest.tipoMissaoAtual] && quest.acabouAMissao[quest.tipoMissaoAtual])//Verifica se o ID da miss�o desse script � igual ao ID da miss�o no script "Missoes", tamb�m verifica se a bool miss�o acabou � verdadeira
        {
            this.gameObject.GetComponent<SistemaNPCSecundario>().enabled = false;//Desativa o Script no gameobject em que ele est� inserido
        }
    }

    public void InteragiuSecundario()
    {
        if (sistemaNPCPrincipal.comecouPrincipal)
        {
            quest.dinheiro[tipoMissao] = dinheiroMissao;
            quest.textoTituloMissao[tipoMissao] = tituloMissao;
            quest.tipoMissaoAtual = tipoMissao;
            quest.acabouAMissao[quest.tipoMissaoAtual] = false;
            quest.textoObjetivoMissao[tipoMissao] = textoObjetivoMissao;
            quest.progressoMissao[tipoMissao] = 0;
            quest.objetivoFinalMissao[tipoMissao] = objetivoFinalMissaoInte;
            quest.idMissaoAtual[tipoMissao] = idMissao;
            quest.Missao();
        }
    }

    public void Coletou()
    {
        quest.progrediuObjetivo[tipoMissao] = true;
        quest.CheckDaMissao();
    }
}
