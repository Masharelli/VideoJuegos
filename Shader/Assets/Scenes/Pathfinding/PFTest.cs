using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFTest : MonoBehaviour
{

    public Nodo inicio, fin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // breadthwise
        if (Input.GetKeyUp(KeyCode.B)) {

            List<Nodo> ruta = Pathfinding.Ancho(inicio, fin);

            foreach (Nodo actual in ruta) {
                print(actual.transform.name);
            }

            // cambiar ruta de objeto
            Personaje.Instancia.ResetRuta(ruta.ToArray());
        }

        // depthwise
        if (Input.GetKeyUp(KeyCode.D)) {

            List<Nodo> ruta = Pathfinding.Profundo(inicio, fin);

            foreach (Nodo actual in ruta) {
                print(actual.transform.name);
            }

            Personaje.Instancia.ResetRuta(ruta.ToArray());
        }

        // A star
        if (Input.GetKeyUp(KeyCode.A))
        {

            List<Nodo> ruta = Pathfinding.AEstrella(inicio, fin);

            foreach (Nodo actual in ruta) {
                print(actual.transform.name);
            }

            Personaje.Instancia.ResetRuta(ruta.ToArray());
        }

    }
}
