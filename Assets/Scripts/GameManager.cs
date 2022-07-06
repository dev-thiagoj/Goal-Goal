using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Singleton;

public class GameManager : Singleton<GameManager>
{
    public int endPoint = 5;

    public float timeToSetBallFree = 6f;


    protected override void Awake()
    {
        base.Awake();
        
        DontDestroyOnLoad(gameObject);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
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

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(2);
        ChangeStateToPlay();
    }

    public void StartGame()
    {
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }
    

    public void EndGame()
    {
        AudioHelper.Instance.PitchAccelerator(1f);
        BallBase.Instance.ball.SetActive(false);
        BallBase.Instance.CanMove(false);
        Invoke(nameof(LoadEndScene), 5);
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene(3);
    }

    public void RestartGame()
    {
        //ChangeStateToPlay();
        SceneManager.LoadScene(1);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void TurnSoundOff()
    {
        AudioHelper.Instance.TurnSoundOff();
    }

    public void TurnSoundOn()
    {
        AudioHelper.Instance.TurnSoundOn();
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
