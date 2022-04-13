using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Resetar posição dos players a cada ponto
    //melhorar speed randomico da bola (as vezes fica mto lento e com angulo y mto acentuado
    //melhorar a colisão com as linhas para que estas nao alterem a direção da bola
    //fazer mais cena (scn_menu, scn_play, scn_endgame)...verificar se nao da conflito com a state machine
    
    
    public BallBase ballBase;
    private Player player;
    public StateMachine stateMachine;
    public Button buttonStart;
    public Button buttonRestart;
    public Button buttonOk;
    public GameObject initialBackground;
    public GameObject endgameBackground;
    public GameObject rulesBackground;

    public TextMeshProUGUI winnerAnnouncer;

    public int endPoint = 5;
    public static GameManager Instance;

    public float timeToSetBallFree = 4f;

    private void Awake()
    {
        Instance = this;

        player = GetComponent<Player>();

        rulesBackground.SetActive(false);
        initialBackground.SetActive(true);
        endgameBackground.SetActive(false);
    }

    public void SwithStateReset()
    {
        stateMachine.ResetPosition();
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), Random.Range(2, timeToSetBallFree));
    }

    private void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void ExitRulesBackground()
    {
        rulesBackground.SetActive(false);
        initialBackground.SetActive(true);
    }

    public void StartGame()
    {        
        initialBackground.SetActive(false);
        endgameBackground.SetActive(false);
        
        ballBase.ball.SetActive(true);
        //ballBase.CanMove(true);
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void EndGame()
    {
        ballBase.ball.SetActive(false);
        ballBase.CanMove(false);
        endgameBackground.SetActive(true);

        UpdateWinnerText();
    }

    public void UpdateWinnerText()
    {
        //winnerAnnouncer.text = (string) player.playerName + " é o vencedor!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeStateToPlay()
    {
        stateMachine.SwitchState(StateMachine.States.PLAYING);
    }

    public void ChangeStateToEnd()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
    }
}
