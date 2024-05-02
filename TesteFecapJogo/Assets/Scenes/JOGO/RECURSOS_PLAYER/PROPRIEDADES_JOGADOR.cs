using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PROPRIEDADES_JOGADOR : MonoBehaviour
{
    public static float fome = 100f;
    public static float sede = 100f;
    public static float energia = 100f;
    public static float respeito = 0f;

    public float dinheiro = 120;

    public static GameObject TELA;
    public static GameObject TELA_CONVERSA;

    // Update is called once per frame
    void Start()
    {
        TELA = GameObject.Find("ATRIBUTOS");
        TELA_CONVERSA = GameObject.Find("DIALOGO");
        TELA_CONVERSA.SetActive(false);
    }

    void Update()
    {
        ATRIBUTOS_TEMPO();

        if (Input.GetKeyDown(KeyCode.Q))
        {
      
            if (TELA.activeSelf)
            {
                TELA.SetActive(false);
            }
            else
            {
                TELA.SetActive(true);
            }
           
        }
        if(TELA.activeSelf)
        {
            ATRIBUTOSNATELA();
        }
       

    }
    public void ATRIBUTOS_TEMPO()
    {
        fome -= Time.deltaTime * (50f / 300f);
        sede -= Time.deltaTime * (50f / 300f);
        energia -= Time.deltaTime * (50f / 300f);
    }
    public void ATRIBUTOSNATELA()
    {
       
        GameObject.Find("PREENCHIMENTO_FOME").GetComponent<RectTransform>().localPosition = new Vector3(0f, (fome / 100.0f) * 100 - 100, 0f);
        GameObject.Find("PREENCHIMENTO_SEDE").GetComponent<RectTransform>().localPosition = new Vector3(0f, (sede / 100.0f) * 100 - 100, 0f);
        GameObject.Find("PREENCHIMENTO_ENERGIA").GetComponent<RectTransform>().localPosition = new Vector3(0f, (energia / 100.0f) * 100 - 100, 0f);

    }


}
