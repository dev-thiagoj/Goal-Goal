using UnityEngine;

public class StateBase
{
    public virtual void OnStateEnter(object o = null)
    {
        Debug.Log("On " + this + " Enter");
    }

    public virtual void OnStateStay()
    {
        Debug.Log("On " + this + " Enter");
    }

    public virtual void OnStateExit()
    {
        Debug.Log("On " + this + " Enter");
    }
}

public class StatePlaying : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        BallBase b = (BallBase)o;

        GameManager.Instance.StartGame();
    }
}

public class StateResetPosition : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);

        GameManager.Instance.ResetBall();
    }
}

public class StateEndGame : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);

        GameManager.Instance.EndGame();
    }
}