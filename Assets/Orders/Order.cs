using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour {
    // Settings
    public int numFoots;
    public int idF = 40;

    public Food.FoodState[] states;
    public Food.BodyPart[] parts;

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
    public void Init(int id)
    {
        numFoots = 1;
        if (Random.value * idF > 10)
            numFoots++;
        //if (Random.value * idF > 10)
        //    numFoots++;
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

    public bool IsValid(Food[] foods)
    {
        if (!(foods.Length == numFoots))
            return false;
        int i = 0;
        foreach(Food f in foods)
        {
            if (f.state != states[i] || f.part != parts[i])
                return false;
            ++i;
        }
        return true;
    }
}
