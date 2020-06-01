using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoPrincipal : MonoBehaviour
{
    public float velocidad = 5;

    private float score = 0;
    public Rigidbody theRB;
    
    private Vector3 pos;

    public Text txt;

    
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        pos = transform.position;
        StartCoroutine(CheckDeath());
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector3(Input.GetAxis("Vertical") * velocidad, theRB.velocity.y, Input.GetAxis("Horizontal") * velocidad); 
    
    }
    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.tag == "enemigo"){
            this.transform.position = pos;
            if(score > 0){
                score = score-1;
            }
            txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Meta"){
            score = score+1;
            txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
            this.transform.position = pos;        
        }
    }
    IEnumerator CheckDeath(){
        while (true)
        {
        if(transform.position.y <= -1){
            this.transform.position = pos;
            if(score > 0){
                score = score-1;
            }
            txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        }
            yield return new WaitForSeconds(0.5f);
        }
    }
}