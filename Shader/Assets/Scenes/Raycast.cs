using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Raycast : MonoBehaviour
{

    public Camera camara;
    public NavMeshAgent agente;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 

            Ray rayito = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit datos;

            if (Physics.Raycast(rayito, out datos)) {
                print("PEGO EN: " + datos.point);
                print("PEGO CON: " + datos.transform.name);
                agente.destination = datos.point;

            } else {
                print("NO PEGO");
            }
        }
    }
}
