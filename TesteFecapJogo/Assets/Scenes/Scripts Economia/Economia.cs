using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Economia : MonoBehaviour, IInteractable
{
    public string nomeProduto; //Insere o nome do produto no texto
    public string descricaoProduto; //Insere a descrição do produto no texto
    public float preco; //Quanto o produto vai custar
    public float fomeRestaura; //Quanto da barra de fome o produto vai encher
    public float sedeRestaura; //Quanto da barra de sede o produto vai encher
    public TMP_Text titulo;
    public TMP_Text Descricao;
    public GameObject Compra;
    public PROPRIEDADES_JOGADOR PROPRIEDADES_JOGADOR;


    private bool estaNoMenu = false;

    void Start()
    {
        Compra.SetActive(false);

    }

    void Update()
    {
        if (estaNoMenu == true && Input.GetKey(KeyCode.F) && PROPRIEDADES_JOGADOR.dinheiro > preco)
        {
            PROPRIEDADES_JOGADOR.fome += fomeRestaura;
            PROPRIEDADES_JOGADOR.sede += sedeRestaura;
            PROPRIEDADES_JOGADOR.dinheiro -= preco;
            Compra.SetActive(false);
            estaNoMenu = false;
        }
        else if (estaNoMenu == true && Input.GetKey(KeyCode.R) || PROPRIEDADES_JOGADOR.dinheiro < preco)
        {
            Compra.SetActive(false);
            estaNoMenu = false;
        }
    }


    public void Interact()
    {
        Compra.SetActive(true);
        titulo.SetText(nomeProduto);
        Descricao.SetText(descricaoProduto);
        estaNoMenu = true;
    }
}
