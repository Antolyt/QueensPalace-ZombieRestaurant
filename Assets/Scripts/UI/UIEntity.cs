using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIEntity : MonoBehaviour
{
    Entity _entity;

    public Texture RedBar;
    public Texture GreenBar;
    public float MaxLength;

    private WeaponHandler _weapon;
    private float healthBarLength;

    // Use this for initialization
    void Start()
    {
        healthBarLength = MaxLength;
        _entity = GetComponent<Entity>();
        _weapon = GetComponent<WeaponHandler>();
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
        targetPos.y += 2 * (Screen.height / 2 - targetPos.y);
        GUI.DrawTexture(new Rect(targetPos.x - MaxLength / 2, targetPos.y - MaxLength - 10, MaxLength, 10), RedBar);
        GUI.DrawTexture(new Rect(targetPos.x - MaxLength / 2, targetPos.y - MaxLength - 10, healthBarLength, 10), GreenBar);

        if (_weapon != null)
        {
            // int ammo = _weapon.Weapon.Attr.Ammo;
            // int maxAmmo = _weapon.Weapon.Attr.Ammo;

            GUI.Box(new Rect(targetPos.x, targetPos.y - MaxLength / 2, MaxLength, 20), _weapon.Weapon.Attr.Ammo + "/" + _weapon.Weapon.Attr.MaxAmmo);
        }
    }

    public void AddjustCurrentHealth(int adj)
    {
        healthBarLength = (MaxLength) * (_entity.Attr.Health / (float)_entity.Attr.MaxHealth);
    }
}
