using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAgent
{
    public int maxHp;
    public int[] expPerRound;

    private int currentHp;
    private int currentExp;
    private int currentRound;

    private const int maxRound = 20;

    public int Round
    {
        get => currentRound;
        set => currentRound = value;
    }

    public StateAgent() { }

    public StateAgent(StageData data)
    {
        maxHp = 1000;
        currentHp = maxHp;
        currentExp = 0;
        currentRound = 0;
        expPerRound = new int[maxRound];
        for(int i = 0; i < maxRound; ++i)
        {
            expPerRound[i] = data.numberOfZeroMonster[i] + data.numberOfFirstMonster[i] + data.numberOfSecondMonster[i] + data.numberOfThirdMonster[i];
            Debug.Log($"{i} Round need exp : {expPerRound[i]}");
        }
        currentExp = 0;
    }

    public bool Hit(int damage)
    {
        currentHp -= damage;

        return currentHp <= 0;
    }

    public void Heal(int hp)
    {
        currentHp += hp;

        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
        ComUIDefenseInGame.Root.SetExp = (float)currentExp / expPerRound[currentRound];

        if(currentExp >= expPerRound[currentRound])
        {
            currentExp = 0;
            ++currentRound;
            ComUIDefenseSkillSelector.Root.Open();
        }
    }
}