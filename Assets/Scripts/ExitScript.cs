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
            QuitGame(); //... A função QuitGame é chamada;
        }
    }

    void QuitGame()
    {
        Application.Quit(); //Método Quit executado na aplicação irá interromper os processor e encerrar o aplicativo;
    }
}
