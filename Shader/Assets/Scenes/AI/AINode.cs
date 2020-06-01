using System;
using System.Collections.Generic;
public class AINode 
{

    public string Nombre {
        get;
        private set;
    }

    public Type Comportamiento {
        get;
        private set;
    }

    private Dictionary<AISymbol, AINode> transicion;

    public AINode(string nombre, Type comportamiento) {

        Nombre = nombre;
        Comportamiento = comportamiento;
        transicion = new Dictionary<AISymbol, AINode>();
    }

    public void AgregarTransicion(AISymbol simbolo, AINode nodo) {

        transicion.Add(simbolo, nodo);
    }

    public AINode AplicarTransicion(AISymbol simbolo) {

        if (!transicion.ContainsKey(simbolo))
            return this;

        return transicion[simbolo];
    }

}
