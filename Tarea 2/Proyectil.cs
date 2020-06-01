using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    // recuperar una referencia al componente rigidbody
    // de este gameobject
    Rigidbody rb;

	// Use this for initialization
	void Start () {

        // puede ser null
        rb = GetComponent<Rigidbody>();

        // podemos obtener varios si hay
        Rigidbody[] rbs = GetComponents<Rigidbody>();
        // 3 vectores de referencia
        // transform.up
        // transform.right
        // transform.forward
        rb.AddForce(transform.up * 11, ForceMode.Impulse);
        Destroy(gameObject, 3);
    }
	
	// Update is called once per frame
	void Update () {

        
	}
}
