using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mone : MonoBehaviour, IInteractable
{
    public int din = 0;
    public void Interact()
    {
        din = GameObject.Find("Seller").GetComponent<Compra>().dindin;
        Debug.Log($"Você tem:{din}");
    }
}
