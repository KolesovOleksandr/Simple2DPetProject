using UnityEngine;

[System.Serializable]
public class WeaponSlot
{
    public ProjectileBase projectile;

    [HideInInspector] public float nextFireTime;
}
