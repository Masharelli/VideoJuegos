using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour

{
    public GameObject explosion;
    AudioSource boom;
    // Start is called before the first frame update
    void Start()
    {
        boom = GetComponent<AudioSource>();
        boom.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -20){
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        print("Boom");
        Instantiate(explosion,other.contacts[0].point,transform.rotation);
        Destroy(other.gameObject);
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }
}
