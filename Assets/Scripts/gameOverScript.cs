using UnityEngine;
using System.Collections;

public class gameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(CarregaMenu());
	}
    IEnumerator CarregaMenu()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("_menu");
    }
}
