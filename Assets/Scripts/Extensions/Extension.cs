using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension {

    public static Dictionary<Type, WeaponAttribute> Set(this Dictionary<Type, WeaponAttribute> dict, Type key, WeaponAttribute attr)
    {
        dict.Add(key, attr);
        return dict;
    }

    public static Dictionary<Type, BulletAttribute> Set(this Dictionary<Type, BulletAttribute> dict, Type key, BulletAttribute attr)
    {
        dict.Add(key, attr);
        return dict;
    }
}
