using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI textP1, textP2;
    public Transform player1, player2, ball;
    private int scoreP1 = 0, scoreP2 = 0;

    void Start() => UpdateUI();

    public void AddPoint(int playerID)
    {
        if (playerID == 1) scoreP1++;
        else if (playerID == 2) scoreP2++;
        
        UpdateUI();
        ResetPositions(playerID);
    }

    void UpdateUI()
    {
        textP1.text = $"Jugador 1: {scoreP1}";
        textP2.text = $"Jugador 2: {scoreP2}";
    }

    void ResetPositions(int winnerID)
    {
        player1.position = new Vector3(-7, -3.5f, 0);
        player2.position = new Vector3(7, -3.5f, 0);

        float direction = (winnerID == 1) ? 1f : -1f;
        float serveOffset = 1.0f * direction;

        Transform winner = (winnerID == 1) ? player1 : player2;
        ball.position = winner.position + new Vector3(serveOffset, 5f, 0); 

        Rigidbody2D rbBall = ball.GetComponent<Rigidbody2D>();
        rbBall.linearVelocity = Vector2.zero;
        rbBall.angularVelocity = 0f;

        Vector2 serveForce = new Vector2(direction * 2f, -1f); 
        rbBall.AddForce(serveForce, ForceMode2D.Impulse);

        player1.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        player2.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}