using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order {
    // Settings
    public int numFoots;
    public int idF = 40;

    public Food.FoodState[] states;
    public Food.BodyPart[] parts;

    public Order(int id)
    {
        numFoots = 1;
        if (Random.value * idF > 10)
            numFoots++;
        if (Random.value * idF > 10)
            numFoots++;
        int bodyParts = Food.BodyPart.GetNames(typeof(Food.BodyPart)).Length;
        int zuA = Food.FoodState.GetNames(typeof(Food.FoodState)).Length - 2; // Vorsichtig
        for(int i = 0; i < numFoots; ++i)
        {
            parts[i] = (Food.BodyPart)(int)System.Math.Truncate(Random.value * bodyParts);
            states[i] = (Food.FoodState)(int)System.Math.Truncate(Random.value * zuA);
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
