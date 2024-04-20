using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;


//https://www.youtube.com/watch?v=KqDRORNTCMg

public class GameManager : MonoBehaviour
{
    private string file;
    public GameData datosJuego = new GameData();

    private void Awake()
    {
         file = Application.persistentDataPath + "/gameData.json";
       // file = "/Users/luissancar/gameData2.json";
    }


    private void Update()
    {
    }

    public GameData CargarDatos()
    {
        if (File.Exists(file))
        {
            string contenido = File.ReadAllText(file);
            datosJuego = JsonUtility.FromJson<GameData>(contenido);
            Debug.Log("Cargado");
            return datosJuego;
        }
       
        Debug.Log("Archivo no existe");
        datosJuego.z = 0;
        datosJuego.y = 0;
        datosJuego.x = 0;
        return datosJuego;
    }

    public void GuardarDatos(GameData nuevosDatos)
    {
       
        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(file,cadenaJSON);
        
        Debug.Log("Guardado");
    }

    


}