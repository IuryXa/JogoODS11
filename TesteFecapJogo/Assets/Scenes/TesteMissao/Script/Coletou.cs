using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletou : MonoBehaviour, IInteractable
{
    private Missoes missao;
    public SistemaNPCPrincipal SistemaNPC;
    public SistemaNPCSecundario SistemaNPCSecundario;
    public int idMissao; //Usado para que o ID desse script seja igual ao ID do script "SistemaNPC", isso impede de que, ao realizar essas ações, o jogador não irá concluir objetivos de outras missões
    public GameObject Arvore;
    
    void Start()
    {
        missao = GameObject.Find("MissaoGameObject").GetComponent<Missoes>();
        Arvore.SetActive(false);
    }
    public void Interact()
    {
        //Coleta de Lixo e Limpeza das Ruas
        if (missao.objetivoFinalMissao[0] > 0 && idMissao == SistemaNPC.idMissao && SistemaNPC.selecionarOqueFazer == 0)
        {
            missao.tipoMissaoAtual = SistemaNPC.tipoMissao;
            this.gameObject.SetActive(false);
            SistemaNPC.Coletou();
        }
        else
        if (missao.objetivoFinalMissao[1] > 0 && idMissao == SistemaNPCSecundario.idMissao && SistemaNPCSecundario.selecionarOqueFazer == 0)
        {
            missao.tipoMissaoAtual = SistemaNPCSecundario.tipoMissao;
            this.gameObject.SetActive(false);
            SistemaNPCSecundario.Coletou();
        }
        else
        //Arborização
        if (missao.objetivoFinalMissao[0] > 0 && idMissao == SistemaNPC.idMissao && SistemaNPC.selecionarOqueFazer == 1)
        {
            missao.tipoMissaoAtual = SistemaNPC.tipoMissao;
            Arvore.SetActive(true);
            SistemaNPC.Coletou();
        }
        else
        if (missao.objetivoFinalMissao[1] > 0 && idMissao == SistemaNPCSecundario.idMissao && SistemaNPCSecundario.selecionarOqueFazer == 1)
        {
            missao.tipoMissaoAtual = SistemaNPCSecundario.tipoMissao;
            Arvore.SetActive(true);
            SistemaNPCSecundario.Coletou();
        }
        else
        //Conversar com NPCS
        if (missao.objetivoFinalMissao[0] > 0 && idMissao == SistemaNPC.idMissao && SistemaNPC.selecionarOqueFazer == 2)
        {
            missao.tipoMissaoAtual = SistemaNPC.tipoMissao;
            SistemaNPC.Coletou();
        }

    }
}
