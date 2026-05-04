using UnityEngine;

public class PointArea : MonoBehaviour
{
    [Header("Configuración de Puntaje")]
    public Transform scorerTransform;
    public string teamName;
    public int playerID;
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ScoreManager sm = FindObjectOfType<ScoreManager>();
            if (sm != null) sm.AddPoint(playerID);
        }
    }
}