using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food {
    public enum BodyPart { HEAD, BODY, LEG };
    public enum FoodState { FRIED, RAW };
    public BodyPart part;
    public FoodState state;
    public Food(BodyPart part)
    {
        this.part = part;
        state = FoodState.RAW;
    }
	void Start () {}
	void Update () {}
}
