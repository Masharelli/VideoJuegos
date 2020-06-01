using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomataTest : MonoBehaviour
{

    // para nuestro ejemplo en específico
    public Transform jugador;

    // armando el esqueleto del automata
    private AISymbol premio, castigo, acariciar;
    private AINode dormido, jugando, muerto, caminando;
    
    // representación del nodo donde esptamos parados
    private AINode actual;

    // referencia a comportamiento actual
    private MonoBehaviour comportamiento;


    // Start is called before the first frame update
    void Start()
    {
        // lenguaje
        premio = new AISymbol("premio");
        castigo = new AISymbol("castigo");
        acariciar = new AISymbol("acariciar");

        // estados
        dormido = new AINode("dormido", typeof(DormidoBehaviour));
        jugando = new AINode("jugando", typeof(JugandoBehaviour));
        muerto = new AINode("muerto", typeof(MuertoBehaviour));
        caminando = new AINode("caminando", typeof(CaminandoBehaviour));

        // función de transición
        dormido.AgregarTransicion(premio, jugando);
        dormido.AgregarTransicion(castigo, muerto);

        jugando.AgregarTransicion(acariciar, caminando);
        jugando.AgregarTransicion(castigo, dormido);

        muerto.AgregarTransicion(acariciar, caminando);
        muerto.AgregarTransicion(premio, jugando);

        caminando.AgregarTransicion(premio, dormido);
        caminando.AgregarTransicion(acariciar, muerto);

        // estado inicial 
        actual = dormido;

        // referencia a comportamiento actual
        comportamiento = gameObject.AddComponent(actual.Comportamiento) as MonoBehaviour;

        // para uso en nuestro caso específico
        StartCoroutine(ComprobarCercania());
    }

    // Update is called once per frame
    void Update()
    {
        //print(actual.Nombre);

        /*
        if (Input.GetKeyUp(KeyCode.P)) {

            CambiarEstado(premio);
        }

    */
        if (Input.GetKeyUp(KeyCode.C))
        {

            CambiarEstado(castigo);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {

            CambiarEstado(acariciar);
        }
    }

    private void CambiarEstado(AISymbol simbolo) {

        AINode nuevo = actual.AplicarTransicion(simbolo);
        if (nuevo != actual) {
            actual = nuevo;

            // remover comportamiento viejo
            Destroy(comportamiento);

            // agregar nuevo
            comportamiento = gameObject.AddComponent(actual.Comportamiento) as MonoBehaviour;
        }
    }

    private IEnumerator ComprobarCercania() {

        while (true) {

            // revisar distancia de personaje con jugador 
            float distance = Vector3.Distance(transform.position, jugador.transform.position);
            //print(distance);

            if(distance < 1)
                CambiarEstado(premio);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
