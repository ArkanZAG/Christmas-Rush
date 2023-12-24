using UnityEngine;

namespace Collectible
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private int score;
        [SerializeField] private int maxScore = 6;
        [SerializeField] private VictoryScreen victoryScreen;
        [SerializeField] private InGameMenu inGameMenu;

        public void AddScore(int delta)
        {
            score += delta;
            if (score >= maxScore)
            {
                Debug.Log("TESTTTT");
                victoryScreen.ShowVictoryScreen();
            }
            inGameMenu.UpdateScoreText(score);
        }
    }
}