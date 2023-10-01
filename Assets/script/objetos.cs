using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    

    public enum ObjetosEquipo 
    {
        potionpeque�a,
        potiongrande
    };

    [SerializeField] ObjetosEquipo objetosEquipo;


    public void usarobjeto()
    {
        Player player = GameObject.FindAnyObjectByType<Player>();

        switch (objetosEquipo)
        {
            case ObjetosEquipo.potionpeque�a:
                player.sumavida();
                Debug.Log("cura un punto de salud");
                break;

;
        }
        Destroy(this.gameObject);
    }

}
