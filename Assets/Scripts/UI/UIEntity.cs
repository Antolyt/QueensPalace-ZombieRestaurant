using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIEntity : MonoBehaviour
{
    Entity _entity;

    GameObject _player;

    public Texture RedBar;
    public Texture GreenBar;
    public float MaxLength;

    private float healthBarLength;

    // Use this for initialization
    void Start()
    {
        healthBarLength = MaxLength;
        _entity = GetComponent<Entity>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentHealth(0);
    }

    void OnGUI()
    {
        Vector2 targetPos;
        targetPos = Camera.main.WorldToScreenPoint(transform.position);
        targetPos.y += 2 * ( Screen.height / 2 - targetPos.y);
        GUI.DrawTexture(new Rect(targetPos.x - MaxLength / 2, targetPos.y - MaxLength - 10, MaxLength, 20), RedBar);
        GUI.DrawTexture(new Rect(targetPos.x - MaxLength / 2, targetPos.y - MaxLength - 10, healthBarLength, 20), GreenBar);
    }

    public void AddjustCurrentHealth(int adj)
    {
        healthBarLength = (MaxLength) * (_entity.Attr.Health / (float)_entity.Attr.MaxHealth);
    }
}
