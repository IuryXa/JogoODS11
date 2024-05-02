using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPC_IA : MonoBehaviour, IInteractable
{

    private GameObject NPC;
    //------------------VARIÁVEIS PARA O DIÁLOGO---------------------

    public string Nome_NPC;

    public string[] dialogo = new string[3];
    public string[] falante = new string[3];

    private TMP_Text Falante;
    private TMP_Text Conversa;

    int andamentoDaConversa = 0; //POSIÇÃO DO DIÁLOGO ATUAL
    int pausaRegistroDialogo = -10; //SERVE PARA INTERROMPER AS REPETIDAS EXECUÇÕES DE ATUALIZAÇÃO DOS TEXTOS DO | OBS.: -10 É UM VALOR QUALQUER E DIFERENTE DE 0

    private GameObject JOGADOR;
    //-------------VARIÁVEIS PARA O MOVIMENTO DA IA---------------------------
    private int velocidade = 1;
    private int direction = 0;
    private float cansaco = 0f; //DEFINE O TEMPO DE CAMINHADA DO NPC
    private float recuperacao = 0f; //TEMPO DE RECUPERAÇÃO PÓS-CAMINHADA
    private bool cicloAndar = false; //Auxilia na execução do ciclo de caminhada do objeto em função do tempo
    private bool andando = true; //Define se o objeto pode andar

    public void Interact()
    {
        if(PROPRIEDADES_JOGADOR.TELA_CONVERSA.activeSelf == false && andamentoDaConversa != -10)
        {
            PROPRIEDADES_JOGADOR.TELA_CONVERSA.SetActive(true);
            PROPRIEDADES_JOGADOR.TELA.SetActive(false);
            Interactor.LEGENDA.SetActive(false);
            andando = false;

            NPC.transform.forward = JOGADOR.transform.forward * (-1); //VIRA O NPC EM DIREÇÃO AO JOGADOR

        }
        else if(andamentoDaConversa == -10)
        {
            andando = true;
            andamentoDaConversa = 0;
            
        }
        
    }

    void Start()
    {
        Nome_NPC = this.gameObject.name;
        NPC = this.gameObject;

        JOGADOR = GameObject.Find("Scavenger Variant");

        Falante = GameObject.Find("FALANTE").GetComponent<TMP_Text>();
        Conversa = GameObject.Find("CONVERSA").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

        CONSTR_DIAL();

        if (andando)
        {
            ANDAR();
        }
        if (PROPRIEDADES_JOGADOR.TELA_CONVERSA.activeSelf)
        {
            CONVERSANDO();
        }

    }

    //----------------CONSTRUTOR DE DIÁLOGOS--------------------
    //#Atualmente só preenche os campos de falante com o nome do NPC
    void CONSTR_DIAL()
    {
        for (int u = 0; u < falante.Length; u++)
        {
            if (falante[u] == "")
            {
                falante[u] = Nome_NPC;
            }
        }
    }
    //-----------------------------------------------------------
    //-----------------------------------------------------------
    void ANDAR()
    {
        if(cicloAndar == false)
        {
            cansaco = UnityEngine.Random.Range(1, 11);
            recuperacao = UnityEngine.Random.Range(1, 11);
            direction = UnityEngine.Random.Range(0, 361);
            cicloAndar = true;
        }

        cansaco -= Time.deltaTime;

        if(cansaco < 0)
        { 
            recuperacao -= Time.deltaTime;
            if(recuperacao < 0)
            {
                cicloAndar = false;
            }
        }
        else
        {
            NPC.transform.rotation = Quaternion.Euler(0f, direction, 0f);

            NPC.transform.Translate(transform.TransformDirection(Vector3.forward) * velocidade * Time.deltaTime);
        }
       
    }

    void CONVERSANDO()
    {
        if (andamentoDaConversa != pausaRegistroDialogo)
        {
            Falante.text = falante[andamentoDaConversa];
            Conversa.text = dialogo[andamentoDaConversa];
            pausaRegistroDialogo = andamentoDaConversa;
        }
        else
        {
            if (andamentoDaConversa > 0 && Input.GetKeyDown(KeyCode.Q))
            {
                andamentoDaConversa--;
            }
            else if (andamentoDaConversa < (dialogo.Length - 1) && Input.GetKeyDown(KeyCode.E))
            {
                andamentoDaConversa++;
            }
            else if (andamentoDaConversa == (dialogo.Length - 1) && Input.GetKeyDown(KeyCode.E))
            {
                andamentoDaConversa = -10;
                pausaRegistroDialogo = -10; //UM VALOR QUALQUER
                PROPRIEDADES_JOGADOR.TELA_CONVERSA.SetActive(false);
            }
        }
    }

}
