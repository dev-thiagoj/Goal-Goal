using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Player player; 
    //public CharacterController characterController;
    public Rigidbody2D rigidbody2D;
   
    public Image uiPlayer;
    public string playerName;

    [Header("Limits")]
    public Vector2 limitsX = new Vector2(-4f, 4f);
    public Vector2 limitsY = new Vector2(-4f, 4f);

    [Header("Texts")]
    public TextMeshProUGUI uiTextPoints;
    //public TextMeshProUGUI uiTextEndGame;

    
    public int currentPoints;

    private Vector3 _pos;

    private void OnValidate()
    {
        //if (characterController == null) characterController = GetComponent<CharacterController>();
        if (rigidbody2D == null) rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        
        ResetPlayer();
        //initialPosition = transform.position;
    }

    void Update()
    {
        Bounds();
        FinalPoint();
        
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    public void Bounds()
    {
        _pos.y = rigidbody2D.transform.position.y;
        _pos.x = rigidbody2D.transform.position.x;

        if (_pos.x < limitsX.x) _pos.x = limitsX.x;
        else if (_pos.x > limitsX.y) _pos.x = limitsX.y;

        if (_pos.y < limitsY.x) _pos.y = limitsY.x;
        else if (_pos.y > limitsY.y) _pos.y = limitsY.y;

        rigidbody2D.transform.position = _pos;
    }
    
    /*public void SetName(string s)
    {
        player.name = s;
    }*/

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();        
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    public void FinalPoint()
    {
        if (currentPoints == GameManager.Instance.endPoint)
        {
            //player.name = (string) playerName;
            GameManager.Instance.ChangeStateToEnd();
        }
    }
}
