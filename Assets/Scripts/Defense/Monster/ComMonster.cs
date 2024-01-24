using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anchor.Unity;

public enum MonsterId
{
    Hedgehog,
    Slime,
    Basilisk,
    MiniSlime,
}

public abstract class ComMonster : MonoBehaviour
{
    public int m_Index;
    public MonsterId m_MonsterId;
    public float m_LimitDistanceToTarget = 0.5f;
    public Vector3 m_MoveDirection = Vector3.down;
    public Transform m_Target = null;

    private SpriteRenderer m_SpriteRenderer;
    private MonsterData m_MonsterData;

    private float m_CurrentHp;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void SetUp(int index, Transform target, MonsterData monsterData)
    {
        m_Index = index;
        m_Target = target;
        m_MonsterData = monsterData;
        m_SpriteRenderer.color = Color.white;

        m_CurrentHp = monsterData.hp;
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        if(m_Target == null)
        {
            return;
        }

        float distance = transform.position.y - m_Target.transform.position.y;

        if (distance > m_LimitDistanceToTarget)
        {
            transform.position += m_MoveDirection * m_MonsterData.speed * Time.fixedDeltaTime;
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

        StartCoroutine(SRColorChange());

        m_CurrentHp -= damage - m_MonsterData.def;
        if(m_CurrentHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        ComDefensePlayer.Root.StateAgent.AddExp(1);
        ComDefenseSpawner.Root.Return(this);
    }

    private IEnumerator SRColorChange()
    {
        while(true)
        {
            m_SpriteRenderer.color = Color.red;

            yield return new WaitForSeconds(0.2f);

            m_SpriteRenderer.color = Color.white;

            break;
        }
    }
}
