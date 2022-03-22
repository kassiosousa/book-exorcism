using UnityEngine;
using System.Collections;

public class gameScript : MonoBehaviour {
    public AudioClip SomPadreNormal = null;
    public AudioClip SomPadrePossuido = null;
    public static int padrePossuido = 0; // 0 - neutro | 1 - possuido | 2 - despossuido
	// Use this for initialization
	
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (padrePossuido == 1)
        {
            padrePossuido = 0;
            this.GetComponent<AudioSource>().clip = SomPadrePossuido;
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<AudioSource>().loop = true;
        }
        if (padrePossuido == 2)
        {
            padrePossuido = 0;
            this.GetComponent<AudioSource>().clip = SomPadreNormal;
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<AudioSource>().loop = true;
        }
	}
}
