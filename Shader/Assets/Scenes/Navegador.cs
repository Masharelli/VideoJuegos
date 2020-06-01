using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navegador : MonoBehaviour
{

    private NavMeshAgent agente;
    
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.destination = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // posible blasfemia
        // evaluar seriamente utilizar una corrutina
        // verificar si el objeto ve algo
        RaycastHit data;
        if(Physics.Raycast(transform.position, transform.forward, out data)){
            print("VEO ALGO: " + data.transform.name);
        }
    }

    private void OnDrawGizmos() {

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 100);
    }

    // onmouse - métodos que, ayudados del raycast, detectan interacción con el mouse
    // onmousedown - diste click en objeto
    // onmousedrag - ya habia click en objeto y moviste el mouse
    // onmouseenter - cuando el puntero apunta al objeto (sólo 1 frame)
    // onmouseexit - cuando el punto deja de apuntar al objeto (sólo 1 frame)
    // onmouseover - mientras el puntero siga apuntando al objeto
    // onmouseup - soltamos click en objeto
    // onmouseupasbutton - dimos click y soltamos sobre objeto 
    // TODOS usan raycast. 
    // condiciones - hay collider, objeto no esta en capa de ignorar raycast
    private void OnMouseEnter() {
        print("EL MOUSE ME APUNTA");
    }

    private void OnMouseExit() {
        print("EL MOUSE NO ME APUNTA");
    }
}
