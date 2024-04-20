using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCubo : MonoBehaviour
{
     public float speed = 0.5f; // Velocidad de movimiento

    private Rigidbody rb;
    
    private GameManager cubeScript;

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
        GameObject cubeObject = GameObject.Find("Partida"); 
        cubeScript = cubeObject.GetComponent<GameManager>();

        if (cubeScript == null)
        {
            Debug.LogError("El objeto no tiene el script OtherScript adjunto.");
        }
        RestaurarPosocion();
    }

    void Update()
    {
        // Movimiento del cubo
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            RestaurarPosocion();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardaPosicion();
        }
    }

    private void GuardaPosicion()
    {
        GameData datosAGuardar=new GameData();
        datosAGuardar.x = rb.position.x;
        datosAGuardar.y = rb.position.y;
        datosAGuardar.z = rb.position.z;
        cubeScript.GuardarDatos(datosAGuardar);
        
    }

    private void RestaurarPosocion()
    {
        GameData datosLeidos=cubeScript.CargarDatos();
        rb.MovePosition(new Vector3(datosLeidos.x,datosLeidos.y,datosLeidos.z));
    }
}
