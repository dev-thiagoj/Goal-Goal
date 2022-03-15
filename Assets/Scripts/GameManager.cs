using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;
    private Player player;
    public StateMachine stateMachine;
    public Button buttonStart;
    public Button buttonRestart;
    public Button buttonOk;
    public GameObject initialBackground;
    public GameObject endgameBackground;
    public GameObject rulesBackground;

    public int endPoint = 5;
    public static GameManager Instance;

    public float timeToSetBallFree = 4f;

    private void Awake()
    {
        Instance = this;
        rulesBackground.gameObject.SetActive(false);
        initialBackground.gameObject.SetActive(true);
        endgameBackground.gameObject.SetActive(false);
    }

    private void Update()
    {
        
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
        rulesBackground.gameObject.SetActive(false);
        initialBackground.gameObject.SetActive(true);
    }

    public void StartGame()
    {        
        initialBackground.gameObject.SetActive(false);
        endgameBackground.gameObject.SetActive(false);
        
        ballBase.ball.SetActive(true);
        //ballBase.CanMove(true);
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void EndGame()
    {
        ballBase.ball.SetActive(false);
        ballBase.CanMove(false);
        endgameBackground.gameObject.SetActive(true);
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
