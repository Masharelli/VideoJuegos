using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank2 : MonoBehaviour
{
    public GameObject bala, referencia, torreta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            GameObject balita = Instantiate(bala, referencia.transform.position,referencia.transform.rotation);
            balita.GetComponent<Rigidbody>().AddForce(balita.transform.forward*13,ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.L)){
            print(torreta.transform.rotation.x);
            if(torreta.transform.rotation.x > -0.3)
            torreta.transform.Rotate(-1*Time.deltaTime*10,0,0);
        }
        if(Input.GetKey(KeyCode.J)){
            print(torreta.transform.rotation.x);
            if(torreta.transform.rotation.x < 0.1)
            torreta.transform.Rotate(1*Time.deltaTime*10,0,0);
        }
        if(Input.GetKey(KeyCode.K)){
            print(torreta.transform.rotation.x);
            transform.Translate(-1*Time.deltaTime*2,0,0);
        }
        if(Input.GetKey(KeyCode.I)){
            print(torreta.transform.rotation.x);
            transform.Translate(1*Time.deltaTime*2,0,0);
        }
    }
}
