using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canion : MonoBehaviour {

    public GameObject original;
    public Transform referencia;

    private Coroutine corutinita;


    private IEnumerator disparar;
    private IEnumerator enumeradorcito;

	// Use this for initialization
	void Start () {

        //original = GameObject.Find("Bala");
        disparar = Disparar();

        corutinita = StartCoroutine(pseudoHilo());

        enumeradorcito = corutina2();
        
        StartCoroutine(enumeradorcito);

	}

    // Update is called once per frame
    void Update() {
        // crear un nuevo gameobject 
        // clonarlo - instantiate
        // para instanciar necesitamos un objeto base que copiar
        if (Input.GetKeyDown(KeyCode.Space)) {
           StartCoroutine(disparar);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
           StopCoroutine(disparar);
        }
         
        if (Input.GetKeyUp(KeyCode.C)) {
            StopAllCoroutines();
        }

        if (Input.GetKeyUp(KeyCode.Z)) {
            StopCoroutine(corutinita);
        }
        if (Input.GetKeyUp(KeyCode.X)) {
            StopCoroutine(enumeradorcito);
        }


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(h * 5 * Time.deltaTime, 0, 0);
        transform.Rotate(10 * v * Time.deltaTime, 0, 0);
	}

   
    // corutinas
    // pseudo concurrencia
    //Regla general en las repeticiones
    // hacer las menos posibles por segundo mientras se sienta
    // bien
    IEnumerator pseudoHilo() {
        while(true){
        yield return new WaitForSeconds(0.5f);
        print("HOLA!");
        }
    }

    // Segunda corutina para probar control
    IEnumerator corutina2(){
        while (true){
            yield return new WaitForSeconds(0.3f);
            print("Adios");
        }
    }
    IEnumerator Disparar(){
        while(true){
            //instanciar la bala
            Instantiate(
                original,
                referencia.position,
                referencia.rotation
            );
            yield return new WaitForSeconds(0.2f);
        }
    }
}
