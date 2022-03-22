using UnityEngine;
using System.Collections;

public class bookScript : MonoBehaviour {

    public GameObject theCanvasBook = null;
    // Lista de canvas books
    public GameObject CanvasBook1 = null;
    public GameObject CanvasBook2 = null;
    public GameObject CanvasBook3 = null;
    public GameObject CanvasBook4 = null;
    public GameObject CanvasBook5 = null;

    private bool isShowing;
	private void OnMouseDown ()
    {
        // Desativa todos os canvas de livros para então ativar o atual
        CanvasBook1.SetActive(false);
        CanvasBook2.SetActive(false);
        CanvasBook3.SetActive(false);
        CanvasBook4.SetActive(false);
        CanvasBook5.SetActive(false);

        isShowing = !isShowing;
        theCanvasBook.SetActive(isShowing);
    }
}
