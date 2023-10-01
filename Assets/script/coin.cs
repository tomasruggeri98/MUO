using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public delegate void SumaMoneda(int moneda);
    public static event SumaMoneda sumamoneda;
    [SerializeField] private int cantidadMonedas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if (sumamoneda != null) 
            {
                sumarmoneda();
                Destroy(this.gameObject);
            }
        }
    }


    private void sumarmoneda()
    {
        sumamoneda(cantidadMonedas);
    }
}
