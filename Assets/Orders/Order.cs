using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order {
    // Settings
    public int numFoots;
    public int idF = 40;

    public Food.FoodState[] states;
    public Food.BodyPart[] parts;
    private bool Doublicats(int i)
    {
        switch (i)
        {
            case 0: return false;
            case 1: return states[0] == states[1] && parts[0] == parts[1];
            case 2:
                if(states[0] == states[1] && parts[0] == parts[1])
                    return true;
                if (states[1] == states[2] && parts[1] == parts[2])
                    return true;
                if (states[0] == states[2] && parts[2] == parts[0])
                    return true;
                break;
        }
        Debug.LogError("To Many Patrts");
        return false;
    }
    public Order(int id)
    {
        numFoots = 1;
        if (Random.value * idF > 10)
            numFoots++;
        if (Random.value * idF > 10)
            numFoots++;
        int bodyParts = Food.BodyPart.GetNames(typeof(Food.BodyPart)).Length;
        int zuA = Food.FoodState.GetNames(typeof(Food.FoodState)).Length - 2; // Vorsichtig
        parts = new Food.BodyPart[numFoots];
        parts = new Food.BodyPart[numFoots];
        for (int i = 0; i < numFoots; ++i)
        {
            do
            {
                parts[i] = (Food.BodyPart)(int)System.Math.Truncate(Random.value * bodyParts);
                states[i] = (Food.FoodState)(int)System.Math.Truncate(Random.value * zuA);
            } while (Doublicats(i));
        }
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
