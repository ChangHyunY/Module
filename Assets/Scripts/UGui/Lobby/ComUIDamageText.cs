using System.Collections;
using System.Collections.Generic;
using Witch.UGui;
using UnityEngine;

namespace Witch
{
    public class ComUIDamageText : MonoBehaviour
    {
        private TMPro.TextMeshProUGUI m_UGui;

        [SerializeField] float m_Speed;
        [SerializeField] SODamageData m_SODamageData;

        private void Awake()
        {
            m_UGui = GetComponent<TMPro.TextMeshProUGUI>();
        }

        private void Update()
        {
            transform.position += Vector3.up * m_Speed;
        }

        public void OnOpen(string text, int id, Vector3 pivot)
        {
            m_UGui.text = text;
            m_UGui.fontStyle = m_SODamageData.DamageDatas[id].FontStyle;
            m_UGui.fontSize = m_SODamageData.DamageDatas[id].FontSize;
            m_UGui.color = m_SODamageData.DamageDatas[id].Color;

            transform.position = Camera.main.WorldToScreenPoint(pivot);
        }

        // Animation Evenet;
        public void OnClose()
        {
            ComUILobby.Root.Return(this);
        }
    }
}