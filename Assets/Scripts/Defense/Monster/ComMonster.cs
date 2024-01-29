using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterId
{
    Hedgehog,
    Slime,
    Basilisk,
    MiniSlime,
}

public class ComMonster : MonoBehaviour, IAttackable
{
    public int m_Index;
    public MonsterId m_MonsterId;
    public float m_LimitDistanceToTarget = 0.5f;
    public Vector3 m_MoveDirection = Vector3.down;
    public Transform m_Target = null;

    private SpriteRenderer m_SpriteRenderer;
    private MonsterData m_MonsterData;

    private float m_CurrentHp;
    private float m_MoveSpeed;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetUp(int index, Transform target, MonsterData monsterData)
    {
        m_Index = index;
        m_Target = target;
        m_MonsterData = monsterData;
        m_SpriteRenderer.color = Color.white;
        m_CurrentHp = monsterData.hp;

        CalculateSpeed();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void CalculateSpeed()
    {
        float distance = m_Target.position.y - transform.position.y;
        m_MoveSpeed = Mathf.Abs(distance) / m_MonsterData.timeToArrive;
    }

    private void Move()
    {
        if(m_Target == null)
        {
            return;
        }

        float distance = transform.position.y - m_Target.transform.position.y;

        if (distance > m_LimitDistanceToTarget)
        {
            transform.position += m_MoveDirection * m_MoveSpeed * Time.fixedDeltaTime;
        }
    }

    public void Hit(float damage)
    {
        // Dodgy
        if(m_MonsterData.luk > Random.Range(0, 100))
        {
            return;
        }

        Witch.DialogCaller.OnDamageText(DialogId.DamageText, $"{damage}", (int)DamageId.Default, transform.position);

        m_CurrentHp -= damage - m_MonsterData.def;
        if(m_CurrentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ComDefenseSpawner.Root.Return(this);
        ComDefensePlayer.Root.StateAgent.AddExp(1);
    }

    public void Hit<T>(OffenseParameter<T> offenseParameter, float damage)
    {
        if(offenseParameter.offenseType == OffenseType.Skill)
        {
            if(m_MonsterData.luk > Random.Range(0, 100))
            {
                return;
            }

            Witch.DialogCaller.OnDamageText(DialogId.DamageText, $"{damage}", (int)DamageId.Default, transform.position);

            m_CurrentHp -= damage - m_MonsterData.def;
            if(m_CurrentHp <= 0)
            {
                Die();
            }

            offenseParameter.hitCallback?.Invoke();
        }
    }
}
