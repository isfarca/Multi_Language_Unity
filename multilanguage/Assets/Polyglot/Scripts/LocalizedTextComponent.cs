using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

    public abstract class LocalizedTextComponent<T> : MonoBehaviour, ILocalize where T : Component
    {
        [Tooltip("The text component to localize")]
        [SerializeField]
        private T text;
        
        [Tooltip("Maintain original text alignment. If set to false, localization will determine whether text is left or right aligned")]
        [SerializeField]
        private bool maintainTextAlignment;
        public bool MaintainTextAlignment
        {
            get
            {
                return maintainTextAlignment;
            }
            set
            {
                maintainTextAlignment = value;
            }
        }

        [Tooltip("The key to localize with")]
        [SerializeField]
        private string key;

        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                OnLocalize();
            }
        }

        public List<object> Parameters { get { return parameters; } }

        private readonly List<object> parameters = new List<object>();

#if UNITY_5 || UNITY_2017_1_OR_NEWER
        [UsedImplicitly]
#endif
        public void Reset()
        {
            text = GetComponent<T>();
        }

#if UNITY_5 || UNITY_2017_1_OR_NEWER
        [UsedImplicitly]
#endif
        public void OnEnable()
        {
            MultiLanguage.Instance.AddOnLocalizeEvent(this);
        }

        protected abstract void SetText(T component, string value);

        protected abstract void UpdateAlignment(T component, LanguageDirection direction);

        public void OnLocalize()
        {
#if UNITY_EDITOR
            var flags = text != null ? text.hideFlags : HideFlags.None;
            if(text != null) text.hideFlags = HideFlags.DontSave;
#endif
            if (parameters != null && parameters.Count > 0)
            {
                SetText(text, MultiLanguage.GetFormat(key, parameters.ToArray()));
            }
            else
            {
                SetText(text, MultiLanguage.Get(key));
            }

            var direction = MultiLanguage.Instance.SelectedLanguageDirection;

            if (text != null && !maintainTextAlignment) UpdateAlignment(text, direction);

#if UNITY_EDITOR
            if (text != null) text.hideFlags = flags;
#endif
        }

        public void ClearParameters()
        {
            parameters.Clear();
        }

        public void AddParameter(object parameter)
        {
            parameters.Add(parameter);
            OnLocalize();
        }
        public void AddParameter(int parameter)
        {
            AddParameter((object)parameter);
        }
        public void AddParameter(float parameter)
        {
            AddParameter((object)parameter);
        }
        public void AddParameter(string parameter)
        {
            AddParameter((object)parameter);
        }
    }