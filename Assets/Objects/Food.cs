using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food {
    public enum BodyPart { HEAD, BODY, LEG };
    public enum FoodState { FRIED, RAW, BLACK };
    public enum WorkStaitionType { NIX, OFEN, PFANNE, FRITTE };
    public BodyPart part;
    public FoodState state;
    private WorkStaitionType _currStaton = WorkStaitionType.NIX;
    private WorkStaitionType _firstStation = WorkStaitionType.NIX;
    private FoodState _targetState;
    private float _progress;
    public float GetProgress() { return _progress; }
    public Food(BodyPart part)
    {
        this.part = part;
        state = FoodState.RAW;
        _targetState = FoodState.RAW;
        _progress = 1F;
    }
	void Start () {}
	void Update () {}
}
