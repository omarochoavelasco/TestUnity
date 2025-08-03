using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerTrivia : MonoBehaviour {

    public bool cuboPlaced = false;

    public static GameManagerTrivia instance;
    public int placed = 0;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI questionText; // Texto de la pregunta
    public Button[] answerButtons; // Botones para las respuestas

    void Awake()
    {
        // Verificamos si ya existe una instancia.s
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameManagerTrivia.instance.StartTrivia(
    "¿En qué año comenzó la Segunda Guerra Mundial?", 
    new string[] { "1939", "1914", "1941", "1918" }, 
    2 // La respuesta correcta está en la opción 3 (índice 2)
);
   
    }

    public void ObjectPlaced(string objectType, string option)
    {
        if (objectType == "Cubo" && !cuboPlaced)
        {
            cuboPlaced = true;
            placed++;

            if (option == "Opcion1")
            {
                feedbackText.text = "¡Respuesta Correcta!";
            }
            else
            {
                feedbackText.text = "¡Respuesta Incorrecta!";
            }
        }

        
    }

    public void StartTrivia(string question, string[] options, int correctAnswerIndex)
    {
        questionText.text = question;
        for (int i = 0; i < options.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[i];
        }
    }
}
