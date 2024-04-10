using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compra : MonoBehaviour, IInteractable
{
    public int dindin =0;
    public void Interact ()
    {
        dindin = GameObject.Find("Cedula").GetComponent<Mone>().din;
        if (dindin >= 1)
        {
            dindin--;
            Debug.Log(dindin);
        }
        else
            Debug.Log("You're Broke");
        
    }

}
