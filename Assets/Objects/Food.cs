using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food {
    public const float ofenTime = 7F;
    public const float pfanneTime = 7F;
    public const float fritteTime = 7F;
    public enum BodyPart { LIVER, SPARRIPS };
    public enum FoodState { BACKED, BRATEN, RAW, BLACK };
    public enum WorkStaitionType { NIX, OFEN, PFANNE };
    public BodyPart part;
    public FoodState state;
    private WorkStaitionType _currStaton = WorkStaitionType.NIX;
    private WorkStaitionType _firstStation = WorkStaitionType.NIX;
    private FoodState _targetState;
    private float _progress;
    private float _time;
    private FootTransformer _footTran = null;

    public float GetProgress() { return _progress; }
    public bool HasReachedTargetState() { return state != FoodState.BLACK && state == _targetState; }

    private float GetTime(WorkStaitionType type) {
        switch (type) {
            case WorkStaitionType.OFEN: return ofenTime;
            case WorkStaitionType.PFANNE: return pfanneTime;
            // case WorkStaitionType.FRITTE: return fritteTime;
            default: return 0F;
        }
    }
    private FoodState GetFinishedStatet(WorkStaitionType type) {
        switch(type) {
            case WorkStaitionType.OFEN: return FoodState.BACKED;
            case WorkStaitionType.PFANNE: return FoodState.BRATEN;
            // case WorkStaitionType.FRITTE: return FoodState.FRIED;
            default: return FoodState.BLACK;
        }
    }
    public bool Eatebal() {
        return state != FoodState.RAW && state != FoodState.BLACK;
    }
    public WorkStaitionType GetFirstStation() { return _firstStation; }
    public bool PlaceOnWorkstation(WorkStaitionType type, FootTransformer footTran) {
        if (_firstStation == WorkStaitionType.NIX)
        {
            _firstStation = type;
            _time = GetTime(type);
            _targetState = GetFinishedStatet(type);
            _progress = 0F;
        }
        if (_firstStation != type)
            return false;
        _footTran = footTran;
        _currStaton = type;
        Debug.Log("currSTat: " + _currStaton.ToString());
        return true;
    }
    public void TakeFromWorkstation() {
        Debug.Log("take Food");
        _footTran = null;
        _currStaton = WorkStaitionType.NIX;
    }
    public Food(BodyPart part)
    {
        this.part = part;
        state = FoodState.RAW;
        _targetState = FoodState.RAW;
        _progress = 1F;
    }
	public void Update () {
        if (_currStaton != WorkStaitionType.NIX) {
            _progress += Time.deltaTime / _time;
            if (_progress > 1F && state != _targetState)
            {
                state = _targetState;
                _footTran.UpdteFood();
            }
            if (_progress > 2F && state != FoodState.BLACK) {
                state = FoodState.BLACK;
                _targetState = FoodState.BLACK;
                _footTran.UpdteFood();
            }
        }
    }
}
