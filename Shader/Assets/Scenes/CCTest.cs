using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class CCTest : MonoBehaviour
{

    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        cc.SimpleMove(new Vector3(h, 0, v) * 5);

        //cc.Move()
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {

        print(hit.transform.name);
    }
}
