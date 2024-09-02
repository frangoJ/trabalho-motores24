using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class player : MonoBehaviour
{
    public int velocidade = 5;
    public int forcapulo = 7;
    public bool Nochao;
    
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!Nochao && collision.gameObject.tag == "chão")
        {
            Nochao = true;
        }
    }

    void Update()
    {
         Debug.Log("update");
         float x = Input.GetAxis("Horizontal");
         float y = Input.GetAxis("Vertical");

         Vector3 direcao = new Vector3(x, 0, y );
         rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);

         if (Input.GetKeyDown(KeyCode.Space) && Nochao)
         {
             rb.AddForce(Vector3.up * forcapulo, ForceMode.Impulse);
             Nochao = false;
         }
         
         
         
         if (transform.position.y < -5)
         {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }
    }
}
