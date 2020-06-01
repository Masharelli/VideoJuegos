using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding 
{

    // busqueda a lo ancho
    // breadthwise
    public static List<Nodo> Ancho(Nodo inicio, Nodo fin){

        // 2 estructuras utilizadas por el algoritmo
        List<Nodo> visitados = new List<Nodo>();
        Queue<Nodo> trabajo = new Queue<Nodo>();

        // reiniciar historial de nodo raiz
        inicio.historial = new List<Nodo>();
        trabajo.Enqueue(inicio);
        visitados.Add(inicio);

        while(trabajo.Count > 0){

            Nodo actual = trabajo.Dequeue();

            if(actual == fin){

                // generar lista resultado y regresarla
                List<Nodo> resultado = new List<Nodo>(actual.historial);
                resultado.Add(actual);
                return resultado;
            } else {

                // si no es el objetivo - agregar vecinos
                for(int i = 0; i < actual.vecinos.Length; i++){

                    Nodo vecinoActual = actual.vecinos[i];

                    if(!visitados.Contains(vecinoActual)){

                        // reiniciar ruta
                        vecinoActual.historial = new List<Nodo>(actual.historial);
                        vecinoActual.historial.Add(actual);
                        
                        // agregar a estructuras
                        trabajo.Enqueue(vecinoActual);
                        visitados.Add(vecinoActual);
                    }
                }
            }
        }
        
        // no existe una ruta posible
        return null;
    }

    // busqueda a lo profundo
    // depthwise
    public static List<Nodo> Profundo(Nodo inicio, Nodo fin){

        // 2 estructuras utilizadas por el algoritmo
        List<Nodo> visitados = new List<Nodo>();
        Stack<Nodo> trabajo = new Stack<Nodo>();

        // reiniciar historial de nodo raiz
        inicio.historial = new List<Nodo>();
        trabajo.Push(inicio);
        visitados.Add(inicio);

        while (trabajo.Count > 0)
        {

            Nodo actual = trabajo.Pop();

            if (actual == fin)
            {

                // generar lista resultado y regresarla
                List<Nodo> resultado = new List<Nodo>(actual.historial);
                resultado.Add(actual);
                return resultado;
            }
            else
            {

                // si no es el objetivo - agregar vecinos
                for (int i = 0; i < actual.vecinos.Length; i++)
                {

                    Nodo vecinoActual = actual.vecinos[i];

                    if (!visitados.Contains(vecinoActual))
                    {

                        // reiniciar ruta
                        vecinoActual.historial = new List<Nodo>(actual.historial);
                        vecinoActual.historial.Add(actual);

                        // agregar a estructuras
                        trabajo.Push(vecinoActual);
                        visitados.Add(vecinoActual);
                    }
                }
            }
        }

        // no existe una ruta posible
        return null;
    }

    // a estrella, a asterisco
    // a star
    public static List<Nodo> AEstrella(Nodo inicio, Nodo fin){

        List<Nodo> trabajo = new List<Nodo>();
        List<Nodo> visitados = new List<Nodo>();

        inicio.historial = new List<Nodo>();
        inicio.g = 0;
        inicio.h = Vector3.Distance(inicio.transform.position, fin.transform.position);

        trabajo.Add(inicio);
        visitados.Add(inicio);

        // caso especial: inicio es el fin
        if (inicio == fin) {
            Debug.Log("FUE EL INICIO");
            List<Nodo> resultado = new List<Nodo>();
            resultado.Add(fin);
            return resultado;
        }

        // para todos los demás
        while (trabajo.Count > 0) {

            // ponemos un mas chico default para poder comparar
            Nodo menor = trabajo[0];

            // buscar al más chico
            for (int i = 1; i < trabajo.Count; i++) {

                if (trabajo[i].F < menor.F)
                    menor = trabajo[i];
            }

            // remover de la lista de trabajo
            trabajo.Remove(menor);

            // recorrer vecinos
            for (int i = 0; i < menor.vecinos.Length; i++) {

                Nodo vecinoActual = menor.vecinos[i];

                if (!visitados.Contains(vecinoActual)) {

                    // modificar historial
                    vecinoActual.historial = new List<Nodo>(menor.historial);
                    vecinoActual.historial.Add(menor);

                    // verificar si vecino es objetivo
                    if (vecinoActual == fin) {

                        Debug.Log("FUE UN VECINO");
                        List<Nodo> resultado = new List<Nodo>(vecinoActual.historial);
                        resultado.Add(vecinoActual);
                        return resultado;
                    } else {


                        // calcular g, h
                        vecinoActual.g = 
                            menor.g + 
                            Vector3.Distance(
                                menor.transform.position, 
                                vecinoActual.transform.position
                            );

                        vecinoActual.h = Vector3.Distance(
                                            vecinoActual.transform.position,
                                            fin.transform.position
                                         );

                        // agregar a estructuras
                        visitados.Add(vecinoActual);
                        trabajo.Add(vecinoActual);
                    }
                }
            }
        }

        return null;
    }
}
