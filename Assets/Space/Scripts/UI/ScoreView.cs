using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    private void OnEnable()
    {
        ScoreCounter.ScoreChange += TotalScore;
    }

    private void OnDisable()
    {
        ScoreCounter.ScoreChange -= TotalScore;
    }

    private void Start()
    {
        TotalScore();
    }

    public void TotalScore()
    {
        _score.text = $"{ScoreCounter.Counter}";
    }
}
