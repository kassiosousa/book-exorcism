using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class learnScript : MonoBehaviour
{
    // Sons to padre
    public AudioClip SomFala1 = null;
    public AudioClip SomFala2 = null;
    public AudioClip SomFala3 = null;

    // Carrega a caixa de diálogo referente ao Learn
    public GameObject CaixaDialogoLearn = null;
    public GameObject TextoDialogoLearn = null;
    public GameObject Pentagrama = null;
    public static bool leuIntroducao = false;
    public static int PadreFinalGame = 0;

    private int nrLivro = 0;
    void Start()
    {
        // Adiciona componente de som que não tem
        this.gameObject.AddComponent<AudioSource>();
        StartCoroutine(MostraFalasIniciais());
    }
    void Update()
    {
        // Fica verificando se o learn leu o livro de introdução || Seta falso para não ficar toda hora verificando
        if (leuIntroducao) { leuIntroducao = false; StartCoroutine(MostraFalasPrePossessao()); }
        if (PadreFinalGame == 1) { StartCoroutine(MostraFalasWin()); }
        if (PadreFinalGame == 2) { StartCoroutine(MostraFalasLose()); }
    }

    IEnumerator MostraFalasIniciais()
    {

        // Aguarda 3seg primeira fala do padre e então fala a primeira
        // Ativa caixa, aguarda tempo para leitura e desativa
        yield return new WaitForSeconds(4);

        // Começa o som de fala
        this.GetComponent<AudioSource>().clip = SomFala2;
        this.GetComponent<AudioSource>().Play();

        string falaLearn1 = "Certo, conseguiremos descobrir tudo sobre exorcismo para ajudar nossos casos.";
        CaixaDialogoLearn.SetActive(true);// ATIVA - a caixa de dialogo
        Text textoDialogo = TextoDialogoLearn.GetComponent<Text>();
        textoDialogo.text = falaLearn1;
        yield return new WaitForSeconds(3);
        CaixaDialogoLearn.SetActive(false);// DESATIVA - a caixa de dialogo

        this.GetComponent<AudioSource>().Pause(); // Termina o som de fala
        
    }

    IEnumerator MostraFalasPrePossessao()
    {
        // Começa o som de fala
        this.GetComponent<AudioSource>().clip = SomFala1;
        this.GetComponent<AudioSource>().Play();

         // Bota false para parar de ficar acessando no update
        // Começa a possessão do padre, mostra as falas iniciais do learn e ativa a possessão
        string falaLearn1 = "O livro está rasurado...Não! Acho que cometi um erro, não era exorcisar e sim 'invocar', não deveria ter pronunciado essas palavras";
        Text textoDialogo = TextoDialogoLearn.GetComponent<Text>();
        textoDialogo.text = falaLearn1;
        CaixaDialogoLearn.SetActive(true);// ATIVA - a caixa de dialogo
        yield return new WaitForSeconds(6);
        CaixaDialogoLearn.SetActive(false);// DESATIVA - a caixa de dialogo

        this.GetComponent<AudioSource>().Pause(); // Encerra o som

        // Avisa ao padre que ele está sendo possuído
        padreScript.estaPossuido = true;

        // Assusta o learn || Muda a animação
        Animator animacaoLearn = this.gameObject.GetComponent<Animator>();
        animacaoLearn.SetBool("estaAssustado", true);
        yield return new WaitForSeconds(1);
        // Volta o learn para assustado iddle|| Muda a animação
        animacaoLearn.SetBool("estaAssustadoIddle", true);
        animacaoLearn.SetBool("estaAssustado", false);

        // Chama as falas pós possessão para tomar ações
        StartCoroutine(MostraFalasPosPossessao());
    }

    IEnumerator MostraFalasPosPossessao()
    {
        // Após a possessão do padre, mostra falas
        yield return new WaitForSeconds(2);
        // Começa o som de fala
        this.GetComponent<AudioSource>().clip = SomFala3;
        this.GetComponent<AudioSource>().Play();

        string falaLearn1 = "Essa não, meu mestre está sendo possuído, preciso fazer algo rápido! Já sei, a chave de salomão";
        Text textoDialogo = TextoDialogoLearn.GetComponent<Text>();
        textoDialogo.text = falaLearn1;
        CaixaDialogoLearn.SetActive(true);// ATIVA - a caixa de dialogo
        yield return new WaitForSeconds(4);
        CaixaDialogoLearn.SetActive(false);// DESATIVA - a caixa de dialogo

        this.GetComponent<AudioSource>().Pause(); // Pausa o som

        // Desenha o pentagrama no chão e fala sobre ele
        Pentagrama.SetActive(true);
        //==================================================
        Text textoDialogoPenta = TextoDialogoLearn.GetComponent<Text>();
        string falaLearn2 = "Pronto, agora ele está controlado, mas não por muito tempo, preciso seguir os passos do livro de introdução";
        string falaLearn3 = "Preciso encontrar aqui nos livros a resposta!";
        textoDialogoPenta.text = falaLearn2;
        CaixaDialogoLearn.SetActive(true);// ATIVA - a caixa de dialogo

        // Começa o som de fala
        this.GetComponent<AudioSource>().clip = SomFala2;
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(5);
        textoDialogoPenta.text = falaLearn3;
        yield return new WaitForSeconds(5);
        CaixaDialogoLearn.SetActive(false);// DESATIVA - a caixa de dialogo

        this.GetComponent<AudioSource>().Pause(); // Para o som

    }

    IEnumerator MostraFalasWin()
    {
        // Desativa pra não ficar toda hora entrando no update
        PadreFinalGame = 0;
        // Aguarda 3seg primeira fala do padre e então fala a primeira
        // Ativa caixa, aguarda tempo para leitura e desativa
        yield return new WaitForSeconds(6);
        // Muda a musica do enredo || Começa o som de fala
        gameScript.padrePossuido = 2;
        this.GetComponent<AudioSource>().clip = SomFala1;
        this.GetComponent<AudioSource>().Play();

        string falaLearn = "Graças a Deus! Tudo deu certo, graças aos conhecimentos que obtive consegui realizar o exorcismo com perfeição";
        Text textoDialogoLearn = TextoDialogoLearn.GetComponent<Text>();
        textoDialogoLearn.text = falaLearn;
        CaixaDialogoLearn.SetActive(true);// ATIVA - a caixa de dialogo
        yield return new WaitForSeconds(4);
        CaixaDialogoLearn.SetActive(false);// DESATIVA - a caixa de dialogo

        this.GetComponent<AudioSource>().Pause(); // Para o som
    }

    IEnumerator MostraFalasLose()
    {
        // Desativa pra não ficar toda hora entrando no update
        PadreFinalGame = 0;
        // Aguarda 3seg primeira fala do padre e então fala a primeira
        // Ativa caixa, aguarda tempo para leitura e desativa
        yield return new WaitForSeconds(3);
        // Começa o som de fala
        this.GetComponent<AudioSource>().clip = SomFala3;
        this.GetComponent<AudioSource>().Play();

        string falaLearn1 = "Essa não, sou um péssimo discipulo, não consegui salvar meu mestre e agora irei viver com a dor da perda";
        Text textoDialogo = TextoDialogoLearn.GetComponent<Text>();
        CaixaDialogoLearn.SetActive(true);// ATIVA - a caixa de dialogo
        textoDialogo.text = falaLearn1;
        yield return new WaitForSeconds(6);
        CaixaDialogoLearn.SetActive(false);// DESATIVA - a caixa de dialogo

        this.GetComponent<AudioSource>().Pause(); // Pausa o som
    }

}



