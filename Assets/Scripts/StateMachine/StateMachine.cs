using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> dictionaryState;

    public StateBase _currentState;
    public float timeToStartGame = 0f;
    public GameManager gameManager;
    public static StateMachine Instance;
    
    private BallBase ballBase;


    private void Awake()
    {
        Instance = this;
        
        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, new StateBase());
        dictionaryState.Add(States.PLAYING, new StatePlaying());
        dictionaryState.Add(States.RESET_POSITION, new StateResetPosition());
        dictionaryState.Add(States.END_GAME, new StateEndGame());

        SwitchState(States.MENU);

        ballBase = GameObject.Find("GameManager").GetComponent<BallBase>();

    }


    public void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();       

        if (_currentState == null) _currentState.OnStateExit();        
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
}
