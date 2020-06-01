using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    // propiedades
    // una manera mas elegante de lidiar con los getters y setters
    public int NodoActual {
        protected set {
            nodoActual = value;
        }
        get {
            return nodoActual;
        }
    }

    public static Personaje Instancia {
        private set;
        get;
    }

    public Nodo[] vecinos;
    public float velocidad = 2;
    public float rangoValido = 0.01f;
    
    private int nodoActual;


    // Start is called before the first frame update
    void Start()
    {
        Instancia = this;
        NodoActual = 0;
        StartCoroutine(VerificarObjetivo());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(vecinos[nodoActual].transform);
        transform.Translate(transform.forward * velocidad * Time.deltaTime, Space.World);
    }

    // verificar que ya llego al nodo actual
    IEnumerator VerificarObjetivo(){

        while(true){

            // si la distancia entre mi personaje y su objetivo es menor que el rango permitido
            float distancia = Vector3.Distance(transform.position, vecinos[nodoActual].transform.position);

            // si la distancia entre el jugador y el objetivo es menor que el rango valido llegamos
            if(distancia < rangoValido){
                nodoActual++;
                nodoActual %= vecinos.Length;
            }

            yield return new WaitForSeconds(0.3f);
        }

        
    }

    public void ResetRuta(Nodo[] nuevaRuta) {
        vecinos = nuevaRuta;
        nodoActual = 0;
    }
}
