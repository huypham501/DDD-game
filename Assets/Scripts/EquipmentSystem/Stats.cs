using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item/Stats")]
public class Stats : ScriptableObject
{
    public float strength;
    public float healthPoint;
    public float defense;
    public float speed;
    public Stats(float _strength, float _healthPoint, float _defense, float _speed)
    {
        strength = _strength;
        healthPoint = _healthPoint;
        defense = _defense;
        speed = _speed;
    }
    public static Stats operator +(Stats stats_a, Stats stats_b)
    {
        return new Stats(stats_a.strength + stats_b.strength, stats_a.healthPoint + stats_b.healthPoint, stats_a.defense + stats_b.defense, stats_a.speed + stats_b.speed);
    }
    public static Stats operator -(Stats stats_a, Stats stats_b)
    {
        return new Stats(stats_a.strength - stats_b.strength, stats_a.healthPoint - stats_b.healthPoint, stats_a.defense - stats_b.defense, stats_a.speed - stats_b.speed);
    }
}
