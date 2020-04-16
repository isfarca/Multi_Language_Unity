#if UNITY_5
using JetBrains.Annotations;
#endif
using UnityEngine;

namespace Polyglot
{
    public class SaveLanguagePreference : MonoBehaviour, ILocalize
    {
        [SerializeField]
        private string preferenceKey = "Polyglot.SelectedLanguage";

#if UNITY_5
        [UsedImplicitly]
#endif
        public void Start()
        {
            MultiLanguage.Instance.SelectedLanguage = (Language) PlayerPrefs.GetInt(preferenceKey);
            MultiLanguage.Instance.AddOnLocalizeEvent(this);
        }

        public void OnLocalize()
        {
            PlayerPrefs.SetInt(preferenceKey, (int) MultiLanguage.Instance.SelectedLanguage);
        }
    }
}