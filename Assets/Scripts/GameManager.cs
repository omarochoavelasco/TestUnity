using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool cuboPlaced = false, cilindroPlaced = false, conoPlaced = false;

    public static GameManager instance;
    public int placed = 0;
    public TextMeshProUGUI feedbackText;

    void Awake()
    {
        // Verificamos si ya existe una instancia.
        if (instance == null)
        {
            // Si no existe, asignamos la instancia.
            instance = this;
            // Aseguramos que no se destruya al cargar nuevas escenas.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruimos el nuevo GameManager (porque solo debe haber uno).
            Destroy(gameObject);
        }
    }

    // Modificado para aceptar el nombre del objeto
    public void ObjectPlaced(string objectType)
    {
        if (objectType == "Cubo" && !cuboPlaced)
        {
            cuboPlaced = true;
            placed++;
        }
        else if (objectType == "Cilindro" && !cilindroPlaced)
        {
            cilindroPlaced = true;
            placed++;
        }
        else if (objectType == "Cono" && !conoPlaced)
        {
            conoPlaced = true;
            placed++;
        }

        if (placed >= 3)
        {
            feedbackText.text = "¡LOGRADO!";
            Debug.Log("LOGRADO");
        }
    }
}
