using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DevUtills.Core.Singleton;

public class GameManager : Singleton<GameManager>
{   
    //public Button buttonStart;
    //public Button buttonRestart;
    //public Button buttonOk;
    //public GameObject initialBackground;
    //public GameObject endgameBackground;
    //public GameObject rulesBackground;

    public TextMeshProUGUI winnerAnnouncer;

    public int endPoint = 5;

    public float timeToSetBallFree = 4f;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
        //rulesBackground.SetActive(false);
        //initialBackground.SetActive(true);
        //endgameBackground.SetActive(false);
    }

    public void SwithStateReset()
    {
        StateMachine.Instance.ResetPosition();
    }

    public void ResetBall()
    {
        BallBase.Instance.CanMove(false);
        BallBase.Instance.ResetBall();
        Invoke(nameof(SetBallFree), Random.Range(2, timeToSetBallFree));
    }

    private void SetBallFree()
    {
        BallBase.Instance.CanMove(true);
    }

    public void ExitRulesBackground()
    {
        //rulesBackground.SetActive(false);
        //initialBackground.SetActive(true);
    }

    public void StartGame()
    {
        //initialBackground.SetActive(false);
        //endgameBackground.SetActive(false);

        //BallBase.Instance.InstantiateBall();
        //BallBase.Instance.CanMove(true);
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void EndGame()
    {
        BallBase.Instance.ball.SetActive(false);
        BallBase.Instance.CanMove(false);
        //endgameBackground.SetActive(true);

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
        StateMachine.Instance.SwitchState(StateMachine.States.PLAYING);
    }

    public void ChangeStateToEnd()
    {
        StateMachine.Instance.SwitchState(StateMachine.States.END_GAME);
    }
}
