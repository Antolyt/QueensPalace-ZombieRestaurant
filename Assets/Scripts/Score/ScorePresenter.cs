using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScorePresenter : MonoBehaviour {

    public Text scoreText;
    public Text gameplayScoreText;

    public int waitTime;
    private float timeStemp;
    public UnityEvent action;

    void Start () {
        scoreText.text = gameplayScoreText.text;
        timeStemp = Time.time;
	}
	
    /// <summary>
    /// Go to next UI after input and time offset
    /// </summary>
	void Update () {
        if((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Submit")) && Time.time > timeStemp + waitTime)
        {
            if (action != null) action.Invoke();
            return;
        }
	}
}
