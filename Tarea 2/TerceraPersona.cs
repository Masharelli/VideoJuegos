using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerceraPersona : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;

    private float distance = 0.0f;
    private float currentX = -12.1f;
    private float currentY = 0.66f;

    private float currentZ = 5.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private  void LateUpdate()
    {
        Vector3 dir = new Vector3(0,0,0);
        Quaternion rotation = Quaternion.Euler(currentY,currentX,0);
        camTransform.position = lookAt.position + rotation * dir;
    }
}
