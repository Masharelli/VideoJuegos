using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chismoso : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //voltear a ver algo
        transform.LookAt(target);

        //mover direccion
            transform.Translate(transform.forward * 1 * Time.deltaTime,
            Space.World
        );
    }
}
