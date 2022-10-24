using TMPro;

using UnityEngine;

namespace UI
{
    public class BaseTextMesh<T> : MonoBehaviour where T : TMP_Text
    {
        [SerializeField, HideInInspector]
        private T m_value;

#if DEBUG

        private void OnValidate()
        {
            m_value ??= GetComponent<T>();
        }

        private void Reset()
        {
            m_value = GetComponent<T>();
        }

#endif

        private void Awake()
        {
            m_value ??= GetComponent<T>();
        }

        protected void Init(T value)
        {
            m_value = value;
        }

        protected void SetText(string text)
        {
            m_value?.SetText(text);
        }
    }
}