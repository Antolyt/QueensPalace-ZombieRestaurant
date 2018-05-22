using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour {
    // Settings
    public int numFoots;
    public int idF = 40;
    public Color full = Color.green;
    public Color halv = Color.yellow;
    public Color empty = Color.red;
    public Slider slider;
    public Image sliderImage;

    public Food.FoodState[] states;
    public Food.BodyPart[] parts;

    public float _liveTime = 4F;
    private float _maxTime = 4F;
    private Ordermanager _om;

    public Order()
    {
    }

    private int Doublicats(int i)
    {
        switch (i)
        {
            case 0: return 0;
            case 1: if( states[0] == states[1] && parts[0] == parts[1]) return 1;
                break;
            case 2:
                if(states[0] == states[1] && parts[0] == parts[1])
                    return 1;
                if (states[1] == states[2] && parts[1] == parts[2])
                    return 2;
                if (states[0] == states[2] && parts[2] == parts[0])
                    return 3;
                break;
            default: Debug.LogError("To Many Patrts");
                break;
        }
        return 0;
    }
    public bool IsState(int k)
    {
        switch (k)
        {
            case 1: return states[0] == states[1];
            case 2: return states[1] == states[2];
            case 3: return states[2] == states[0]; 
        }
        return false;
    }
    public void Init(int id, float liveTime, Ordermanager om)
    {
        _om = om;
        _liveTime = liveTime;
        _maxTime = _liveTime;
        numFoots = 1;
        if (Random.value * idF > 10)
            numFoots++;
        /*if (Random.value * idF > 10)
            numFoots++;*/
        int bodyParts = Food.BodyPart.GetNames(typeof(Food.BodyPart)).Length - 1;
        int zuA = Food.FoodState.GetNames(typeof(Food.FoodState)).Length - 3; // Vorsichtig
        Debug.Log("asas: "+zuA.ToString());
        parts = new Food.BodyPart[numFoots];
        states = new Food.FoodState[numFoots];
        for (int i = 0; i < numFoots; ++i)
        {
            
            parts[i] = (Food.BodyPart)(int)System.Math.Truncate(Random.value * (bodyParts+1));
            states[i] = (Food.FoodState)(int)System.Math.Truncate(Random.value * (zuA+1));
            int k;
            while ((k = Doublicats(i)) != 0)
            {
                if(IsState(k))
                {
                    if(k == 1 || k == 3)
                    {
                        states[0]++;
                        if ((int)states[0] > zuA)
                            states[0] = (Food.FoodState)0;
                    }
                    else
                    {
                        states[1]++;
                        if ((int)states[1] > zuA)
                            states[1] = (Food.FoodState)0;
                    }
                }
                else
                {
                    if (k == 1 || k == 2)
                    {
                        parts[0]++;
                        if ((int)parts[0] > bodyParts)
                            parts[0] = (Food.BodyPart)0;
                    }
                    else
                    {
                        parts[1]++;
                        if ((int)parts[1] > bodyParts)
                            parts[1] = (Food.BodyPart)0;
                    }
                }
            }
        }
        string text = "";
        for (int i = 0; i<numFoots; ++i)
        {
            text += parts[i].ToString() + " " + states[i].ToString();
            text += "\n";
        }
        GetComponentInChildren<Text>().text = text;
    }
    private bool HaveFood(Food food)
    {
        if (food == null)
            return true;
        for (int i = 0; i < parts.Length; ++i)
        {
            Debug.Log(parts[i] + "----" + states[i]);
            if (food.part == parts[i] && food.state == states[i])
                return true;
        }
        return false;
    }
    public bool IsValid(Food[] foods)
    {
        int l = 0;
        foreach (Food f in foods)
            if (f != null)
                l++;

        if (!(l == numFoots))
        {
            // Debug.Log(numFoots.ToString()+ "<-mylength, searched " + l.ToString());
            return false;
        }

        int i = 0;
        foreach(Food f in foods)
        {
            if (!HaveFood(f))
                return false;
            ++i;
        }
        i = foods.Length;

        return true;
    }
    void Start()
    {
        // _liveTime = 4F;
        // _maxTime = _liveTime;
    }
    private bool _run = true;
    void Update()
    {
        _liveTime -= Time.deltaTime;
        if (_liveTime > 0)
        {
            float prog = _liveTime / _maxTime;
            // Debug.Log("Prog_ " + prog.ToString());
            slider.value = prog;
            if (prog < 0.5f)
                sliderImage.color = Color.Lerp(empty, halv, prog * 2F);
            else
                sliderImage.color = Color.Lerp(halv, full, (prog - 0.5f) * 2F);
        }
        else if(_run)
        {
            _om.kaputt(this);
            _run = false;
        }
    }
}
