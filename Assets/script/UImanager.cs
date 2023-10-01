using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{
    private int totalMonedas;
    [SerializeField] private TMP_Text textMonedas;

    [SerializeField] private List<GameObject> listacorazones;

    [SerializeField] private Sprite corazondesactivado;

    [SerializeField] private Sprite corazonactivado;

    [SerializeField] private GameObject panelEquipo;

    private int totalobjetos;
    private int precioobjeto;


    void Start()
    {
        coin.sumamoneda += sumarmonedas;
    }

    private void sumarmonedas(int moneda)
    {
        totalMonedas += moneda;
        textMonedas.text = totalMonedas.ToString();
    }

    public void restarcorazones(int indice)
    {
        Image Imagencorazon = listacorazones[indice].GetComponent<Image>();
        Imagencorazon.sprite = corazondesactivado;
    }

    public void sumarcorazones(int indice)
    {
        Image Imagencorazon = listacorazones[indice].GetComponent<Image>();
        Imagencorazon.sprite = corazonactivado;
    }





    //TIENDA 
    public void valorobjeto(string objeto)
    {
        switch (objeto)
        {
            case "botonpota1":
                precioobjeto = 3; break;
        }

    }

    public void adquirirobjeto(string objeto)
    {

        valorobjeto(objeto);
        if(precioobjeto <= totalMonedas && totalobjetos < 6) 
        {
            totalobjetos++;
            totalMonedas -= precioobjeto;
            textMonedas.text = totalMonedas.ToString();
            GameObject equipo = (GameObject)Resources.Load(objeto);
            Instantiate(equipo, Vector3.zero, Quaternion.identity, panelEquipo.transform);
        }



    }

}
