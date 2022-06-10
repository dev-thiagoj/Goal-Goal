using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public Player player;
    public ParticleSystem particleSystem;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {            
            Countpoint();
        }
    }

    void Countpoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
        particleSystem.Play();
    }

    
}
