using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class player : MonoBehaviour
{
    public int velocidade = 5;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
         Debug.Log("update");
         float x = Input.GetAxis("Horizontal");
         float y = Input.GetAxis("Vertical");

         Vector3 direcao = new Vector3(x, 0, y );
         rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);
    }
}
