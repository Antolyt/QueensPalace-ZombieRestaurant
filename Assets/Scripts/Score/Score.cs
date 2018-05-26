using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform spawnedClouds;
    string[] questElements;
    string questElement;
    public Text questText;

    public Text scoreText;
    public Text singleScoreText;
    public int basicScore;
    public static int score;
    public int chainMultiplier;
    int chain;
    public int maxChain = 50;

    public AudioSource correct;
    public AudioSource incorrect;

    public string[] sentenceBegin = { "Do you see this ", "Aww, this ", "This ", "I see a ", "When I go home maybe I buy this ", "Look at this " };
    public string[] sentenceEnd = { ".", " is beautiful.", " reminds me of somthing.", ", you too?", ".", "." };
    private Queue<string> lastQuests;
    private int maxLastQuestSize = 2;
    private int numberOfRetries = 5;

    public ScorePresenter scorePresenter;

    private bool updateAfterStart = true;

    private void Start()
    {
        lastQuests = new Queue<string>();
    }

    /// <summary>
    /// Wait till 3 Couds are spawn and set random one as quest
    /// </summary>
    void Update()
    {
        if(updateAfterStart && spawnedClouds.childCount >= 3)
        {
            updateAfterStart = false;
            questText.transform.parent.gameObject.SetActive(true);
            NewQuest();
        }
    }

    /// <summary>
    /// Checks if element(name) is the questItem, increase score if correct by basic score and chain, sets chain on 0 if incorrect
    /// </summary>
    /// <param name="name">name of element to check</param>
    /// <returns>chain</returns>
    public int RateElement(string name)
    {
        if(name == questElement)
        {
            score += basicScore + chain * chainMultiplier;
            scoreText.text = score.ToString();

            singleScoreText.rectTransform.position = Input.mousePosition;
            singleScoreText.text = "   " + basicScore + "+" + chain * chainMultiplier;
            singleScoreText.gameObject.SetActive(true);

            chain = chain < maxChain ? chain + 1 : maxChain;
            correct.Play();

            NewQuest();
        }
        else
        {
            chain = 0;
            incorrect.Play();
        }

        return chain;
    }

    /// <summary>
    /// Create new Quest(Text: Cloud to click)
    /// </summary>
    public void NewQuest()
    {
        questElement = spawnedClouds.GetChild(Random.Range(0, spawnedClouds.childCount)).name;

        int i = 0;
        while (lastQuests.Contains(questElement) && i++ < numberOfRetries)
        {
            questElement = spawnedClouds.GetChild(Random.Range(0, spawnedClouds.childCount)).name;
        }

        lastQuests.Enqueue(questElement);
        if (lastQuests.Count > maxLastQuestSize) lastQuests.Dequeue();

        int sentence = Random.Range(0, sentenceBegin.Length);
        string quest = sentenceBegin[sentence] + "<b>" + questElement + "</b>";
        if (sentence > sentenceEnd.Length)
            sentence = 0;
        questText.text = quest + sentenceEnd[sentence];
    }
}
