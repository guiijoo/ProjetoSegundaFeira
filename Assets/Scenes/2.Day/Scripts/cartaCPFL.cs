using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaCPFL : MonoBehaviour
{
    public GameObject cartaAberta;
    public GameObject interactSys;

    public void CartaAberta()
    {
        Debug.Log("cartaaberta()");
        cartaAberta.SetActive(true);
    }

    public void FechaCarta()
    {
        cartaAberta.SetActive(false);
    }
}
