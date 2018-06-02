using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text singleScoreText;
    public static int score;

    public ScorePresenter scorePresenter;

    private void Start()
    {
        
    }

    /// <summary>
    /// Wait till 3 Couds are spawn and set random one as quest
    /// </summary>
    void Update()
    {

    }
}
