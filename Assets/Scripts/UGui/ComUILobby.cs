using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Witch
{
    public class ComUILobby : MonoBehaviour
    {
        private static ComUILobby m_Root;
        public static ComUILobby Root => m_Root;


        public Transform m_DamageText;
        public Transform m_RootDamageText;

        Queue<ComUIDamageText> m_DamageTextPool;

        private void Awake()
        {
            m_Root = this;

            Initialize();
        }

        private void Initialize()
        {
            m_DamageTextPool = new Queue<ComUIDamageText>();

            for (int i = 0, loop = 10; i < loop; ++i)
            {
                Transform go = Instantiate(m_DamageText, m_RootDamageText);
                go.gameObject.SetActive(false);
                m_DamageTextPool.Enqueue(go.GetComponent<ComUIDamageText>());
            }
        }

        public void OnEventAttack()
        {
            if (m_DamageTextPool.Count != 0)
            {
                ComUIDamageText damageText = m_DamageTextPool.Dequeue();
                damageText.gameObject.SetActive(true);
                damageText.OnOpen(
                    $"{Random.Range(10, 500)}",
                    Random.Range(0, System.Enum.GetValues(typeof(DamageId)).Length),
                    ComSpawner.Root.GetRandomObjectPosition
                    );
            }
            else
            {
                ComUIDamageText go = Instantiate(m_DamageText, m_RootDamageText).GetComponent<ComUIDamageText>();
                go.OnOpen(
                    $"{Random.Range(10, 500)}",
                    Random.Range(0, System.Enum.GetValues(typeof(DamageId)).Length),
                    ComSpawner.Root.GetRandomObjectPosition
                    );
            }
        }

        public void Return(ComUIDamageText obj)
        {
            obj.gameObject.SetActive(false);
            m_DamageTextPool.Enqueue(obj);
        }
    }
}