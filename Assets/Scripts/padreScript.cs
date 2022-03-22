using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class padreScript : MonoBehaviour
{   
    // Carrega a caixa de diálogo referente ao padre
    public GameObject CaixaDialogoPadre = null;
    public GameObject TextoDialogoPadre = null;
    public GameObject LivroIntroducao = null;
    public GameObject CanvasCodeRitual = null;
    public InputField InputCodeRitual = null;

    // Sons to padre
    public AudioClip SomFala1 = null;
    public AudioClip SomFala2 = null;
    public AudioClip SomFala3 = null;

    // Livros a serem desbloqueados quando começa a possessão
    public GameObject Livro1 = null;
    public GameObject Livro2 = null;
    public GameObject Livro3 = null;
    public GameObject Livro4 = null;
    public GameObject Livro5 = null;

    // Conjunto de falas de acordo com o exorcismo a ser feito
    private int nrLivro = 0;
    private bool estaPossuidoFlag = true;
    public static bool estaPossuido = false;

    string[] livro_1 = new string[] { "Agares", "Eu sou homem!", "Eu paraliso qualquer um, me solte.", "Eu posso fazer terremotos", "Eu governo a zona oriental do inferno", "Comando 31 legiões de demonios", "facit" };
    string[] livro_2 = new string[] { "Aka Manah", "Faço mal para sua mente!", "Me chamo Akoman", "Tenho péssimas intenções com todos", "Irei impedir que você cumpra sua obrigação moral", "Você não vai conseguir salvar seu mestre", "philos" };
    string[] livro_3 = new string[] { "Ale", "Posso ser muito mal, mas posso te ajudar", "Eu posso fazer chover", "Gosto de me alimentar de crianças", "Posso criar eclipses comendo a luz do sol", "Não deixa aves perto de mim" , "brutum"};
    string[] livro_4 = new string[] { "Asag", "Causo doenças incríveis", "Eu amo montanhas como voce ama uma mulher", "Meus filhos são rochas", "Sou de 20.000 A.C.", "Dizem que sou feio demais", "fulmen"};
    string[] livro_5 = new string[] { "Belphegor", "Os israelitas me adoram", "Torno as pessoas paranóicas", "Odeio casamentos, não traz felicidade para vocês", "Sou embaixador do inferno na França", "supra" };

    void Start()
    {
        // Gera o número do livro escolhido aleatoriamente
        nrLivro = Random.Range(1, 5);
        // Adiciona componente de som que não tem
        this.gameObject.AddComponent<AudioSource>();

        StartCoroutine(MostraFalasIniciais(nrLivro));
    }
    void Update()
    {
        // Fica verificando se o padre entra em estado de possessao || Seta falso para não ficar toda hora verificando || muda a musica
        if (estaPossuido) { estaPossuido = false; gameScript.padrePossuido = 1; StartCoroutine(EstadoDePossessao(nrLivro)); }

        // Fica pegando o que for digitado no inputcode
        // Verifica se o jogador digitou o código de algum livro, só assim ativa
        if (InputCodeRitual.text == "facit") { AnalisaRespostaJogador("facit"); }
        if (InputCodeRitual.text == "philos") { AnalisaRespostaJogador("philos"); }
        if (InputCodeRitual.text == "brutum") { AnalisaRespostaJogador("brutum"); }
        if (InputCodeRitual.text == "fulmen") { AnalisaRespostaJogador("fulmen"); }
        if (InputCodeRitual.text == "supra") { AnalisaRespostaJogador("supra"); }
    }

    IEnumerator MostraFalasIniciais(int nrLivro)
    {
        // Começa o som de fala
        this.GetComponent<AudioSource>().clip = SomFala1;
        this.GetComponent<AudioSource>().Play();
        // Frase inicial do padre, 3 segundos para leitura
        string falaPadre1 = "Chegamos, aqui podemos aprender tudo que precisamos";
        CaixaDialogoPadre.SetActive(true);// ATIVA - a caixa de dialogo
        Text textoDialogo1 = TextoDialogoPadre.GetComponent<Text>();
        textoDialogo1.text = falaPadre1;
        yield return new WaitForSeconds(3);
        CaixaDialogoPadre.SetActive(false);// DESATIVA - a caixa de dialogo

        this.GetComponent<AudioSource>().Pause(); // Termina o som de fala
        

        // Aguarda 3 seg da fala inicial do aprendiz
        yield return new WaitForSeconds(4);
        // Começa o som de fala
        this.GetComponent<AudioSource>().clip = SomFala3;
        this.GetComponent<AudioSource>().Play();

        // Fala a segunda frase, 3 seg para leitura
        string falaPadre2 = "Leia os livros e estude exorcismos, voce deve aprender o que precisa no livro vermelho na prateleira esquerda.";
        CaixaDialogoPadre.SetActive(true);// ATIVA - a caixa de dialogo
        Text textoDialogo2 = TextoDialogoPadre.GetComponent<Text>();
        textoDialogo2.text = falaPadre2;
        yield return new WaitForSeconds(5);
        CaixaDialogoPadre.SetActive(false);// DESATIVA - a caixa de dialogo
        this.GetComponent<AudioSource>().Pause(); // Termina o som de fala

        // Encerrado o ciclo de falas iniciais

        // Ativa o livro de intro para poder ser clicado
        LivroIntroducao.SetActive(true);
    }

    IEnumerator EstadoDePossessao(int nrLivro)
    {
        string[] conjuntoFalasPossuidas = new string[] {};
        // Descobre qual array de strings é a que deve ser usada
        if (nrLivro == 1) { conjuntoFalasPossuidas = livro_1; }
        if (nrLivro == 2) { conjuntoFalasPossuidas = livro_2; }
        if (nrLivro == 3) { conjuntoFalasPossuidas = livro_3; }
        if (nrLivro == 4) { conjuntoFalasPossuidas = livro_4; }
        if (nrLivro == 5) { conjuntoFalasPossuidas = livro_5; }
        // Ativa os livros
        Livro1.SetActive(true);
        Livro2.SetActive(true);
        Livro3.SetActive(true);
        Livro4.SetActive(true);
        Livro5.SetActive(true);
        LivroIntroducao.SetActive(false);
        // Muda a animação do padre para possessão
        Animator animacaoPadrePosse = this.gameObject.GetComponent<Animator>();
        animacaoPadrePosse.SetBool("estaPossuido", true);
        // Ativa o input para que o jogador coloque o código
        CanvasCodeRitual.SetActive(true);
        // ========================
        int i = 1;
        // tempo para as falas do learn
        yield return new WaitForSeconds(3);

        while (estaPossuidoFlag)
        {
            // Fala uma frase a cada 5seg de acordo com o livro sorteado
            // Fala a segunda frase, 3 seg para leitura
            yield return new WaitForSeconds(3);
            string falaPadrePossuido = conjuntoFalasPossuidas[i];

            Text textoDialogo = TextoDialogoPadre.GetComponent<Text>();
            textoDialogo.text = falaPadrePossuido;
            CaixaDialogoPadre.SetActive(true);// ATIVA - a caixa de dialogo
            yield return new WaitForSeconds(3);
            CaixaDialogoPadre.SetActive(false);// DESATIVA - a caixa de dialogo

            if (i == 5) { i = 1;  } else { i++; }
        }


    }

    IEnumerator EstadoPosPossessao()
    {
        // Pra evitar ficar entrando toda hora no update
        InputCodeRitual.text = "";

        // Volta a animação original do padre || Indica ao learn que o padre está bem para que ele identifique a rotina de conversas || Mostra falas de agradecimento
        Animator animacaoPadreSobreviveu = this.gameObject.GetComponent<Animator>();
        animacaoPadreSobreviveu.SetBool("estaPossuido", false);

        learnScript.PadreFinalGame = 1; // Sucesso, padre a salvo começa rotina de conversas
        estaPossuidoFlag = false;

        //  3 segundos para leitura
        yield return new WaitForSeconds(2);
        // Começa o som de fala
        this.GetComponent<AudioSource>().clip = SomFala1;
        this.GetComponent<AudioSource>().Play();

        string falaPadreWin = "Você conseguiu, meu discipulo! Me salvou de um fim terrível! Aprendeu bem meus ensinamentos";
        Text textoDialogo1 = TextoDialogoPadre.GetComponent<Text>();
        textoDialogo1.text = falaPadreWin;
        CaixaDialogoPadre.SetActive(true);// ATIVA - a caixa de dialogo
        yield return new WaitForSeconds(3);

        this.GetComponent<AudioSource>().Pause(); // Pausa o som
        //CaixaDialogoPadre.SetActive(false);// DESATIVA - a caixa de dialogo

        //  3seg de texto do learn depois
        yield return new WaitForSeconds(3);
        // Começa o som de fala
        this.GetComponent<AudioSource>().clip = SomFala3;
        this.GetComponent<AudioSource>().Play();

        string falaPadreWin2 = "Sim, agora vamos utilizar nosso conhecimento para ajudar as pessoas ao redor do mundo";
        Text textoDialogo2 = TextoDialogoPadre.GetComponent<Text>();
        textoDialogo2.text = falaPadreWin2;
        //CaixaDialogoPadre.SetActive(true);// ATIVA - a caixa de dialogo
        yield return new WaitForSeconds(3);
        CaixaDialogoPadre.SetActive(false);// DESATIVA - a caixa de dialogo

        this.GetComponent<AudioSource>().Pause(); // Pausa o som

        // Direciona o jogo para tela de game over
        yield return new WaitForSeconds(5);
        Application.LoadLevel("_gameOver");

    }

    IEnumerator EstadoMortePossessao()
    {
        // Já mostrou animação de morte do padre || Indicar para o learn que o padre morreu

        learnScript.PadreFinalGame = 2; // Derrota, padre morreu começa rotina de conversas

        // Direciona o jogo para tela de game over
        yield return new WaitForSeconds(6);
        Application.LoadLevel("_gameOver");
    }

    void AnalisaRespostaJogador(string respostaJogador)
    {
        
        if (respostaJogador == "facit" && nrLivro == 1)
        {
            // Cancela o loop de possuído || Chama função de pós possessao
            estaPossuidoFlag = false;
            StartCoroutine(EstadoPosPossessao());
        } else if (respostaJogador == "philos" && nrLivro == 2) {
            // Cancela o loop de possuído || Chama função de pós possessao
            estaPossuidoFlag = false;
            StartCoroutine(EstadoPosPossessao());
        } else if (respostaJogador == "brutum" && nrLivro == 3) {
            // Cancela o loop de possuído || Chama função de pós possessao
            estaPossuidoFlag = false;
            StartCoroutine(EstadoPosPossessao());
        } else if (respostaJogador == "fulmen" && nrLivro == 4) {
            // Cancela o loop de possuído || Chama função de pós possessao
            estaPossuidoFlag = false;
            StartCoroutine(EstadoPosPossessao());
        } else if (respostaJogador == "supra" && nrLivro == 5) {
            // Cancela o loop de possuído || Chama função de pós possessao
            estaPossuidoFlag = false;
            StartCoroutine(EstadoPosPossessao());
        }
        else
        { // Tudo errado, ele digitou o código do livro errado
            // Se tá errado o código, mata o padre e mostra a animação de morte
            estaPossuidoFlag = false;
            Animator animacaoPadrePosse = this.gameObject.GetComponent<Animator>();
            animacaoPadrePosse.SetBool("estaMorto", true);
            StartCoroutine(EstadoMortePossessao());  // Chama função de morte
        }
    }
}
