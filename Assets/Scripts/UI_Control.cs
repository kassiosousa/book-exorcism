using UnityEngine;
using System.Collections;

public class UI_Control : MonoBehaviour {

    public GameObject optionMenu, creditsCanvas, closeCanvas;
    private bool isShowingCredits;
    public string nameScene = "";

    private void OnMouseDown ()
    {
        if (this.gameObject.name == "novo_jogo")
        {
            // Carrega a cena desejada
            LoadGame(nameScene);
        }
        if (this.gameObject.name == "sair")
        {
            QuitGame();
        }
        if (this.gameObject.name == "sobre")
        {
            CreditsCanvas();
        }
        if (this.gameObject.name == "close_canvas")
        {
            CloseCanvas();
        }
    }

    public void LoadGame(string nameScene)
    {
        Application.LoadLevel(nameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CreditsCanvas()
    {
        isShowingCredits = !isShowingCredits;
        creditsCanvas.SetActive(isShowingCredits);
    }
    public void CloseCanvas()
    {
        // Se o aprendiz leu o livro de introdução, começam as falas dele e o padre entra em estado de possessão
        if (closeCanvas.name == "Canvas_Livro_intro")
        {
            learnScript.leuIntroducao = true;
        }
        closeCanvas.SetActive(false);
    }
    public void OptionMenu()
    {

    }
}

