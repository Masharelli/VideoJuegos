using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour {

    public float velocidad = 3;
    public Text textito;

	// Use this for initialization
	void Start () {
        textito.text = "HOLA MUNDO!";
	}
	
	// Update is called once per frame
	void Update () {
        
        // captura de entrada por ejes
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(
            velocidad * h * Time.deltaTime,
            velocidad * v * Time.deltaTime,
            0,
            Space.World);
	}

    // detección de colisiones
    // - los involucrados todos tienen collider
    // - uno (el que se mueve) tiene rigidbody

    // si no congelamos hay una retroalimentación física
    void OnCollisionEnter(Collision c) {
        print("ENTER: " + c.transform.name);
        print("MAS INFO: " + c.contacts[0].point);
    }

    void OnCollisionStay(Collision c) {
       // print("STAY");
    }

    void OnCollisionExit(Collision c)
    {
        print("EXIT");
    }

    void OnTriggerEnter(Collider c) {
        print("TRIGGER ENTER: " + c.transform.name);
    }
    void OnTriggerStay(Collider c) {
        //print("TRIGGER STAY");
    }
    void OnTriggerExit(Collider c) {
        print("TRIGGER EXIT");
    }
}
