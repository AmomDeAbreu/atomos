using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Se durante o jogo a tecla "Esc" for apertada...
        {
            QuitGame(); //... A fun��o QuitGame � chamada;
        }
    }

    void QuitGame()
    {
        Application.Quit(); //M�todo Quit executado na aplica��o ir� interromper os processor e encerrar o aplicativo;
    }
}