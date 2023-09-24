using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Character Data")]
public class Attribute : ScriptableObject, IComparable<Attribute>, IComparer<Attribute>
{
    public string Name;
    public float maxHealth;
    public float currentHealth;
    public int baseDefence;
    public int currentDefence;
    public int baseSpeed;
    public int currentSpeed;
    public int baseATK;
    public int currentATK;
    public Attribute(string Name, int maxHealth, int currentHealth, int baseDefence, int currentDefence, int baseSpeed, int currentSpeed, int baseATK, int currentATK)
    {
        this.Name = Name;
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.baseDefence = baseDefence;
        this.currentDefence = currentDefence;
        this.baseSpeed = baseSpeed;
        this.currentSpeed = currentSpeed;
        this.baseATK = baseATK;
        this.currentATK = currentATK;
    }

    public int CompareTo(Attribute Player)
    {
        return currentSpeed.CompareTo(Player.currentSpeed);
    }
    public int Compare(Attribute Obj1, Attribute Obj2)
    {
        return Obj1.currentSpeed.CompareTo(Obj2.currentSpeed);
    }
}
