using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageScript : MonoBehaviour
{

    private int language;


    private void Start()
    {
        LoadData();
        Invoke("LoadLocal", 0.1f);
    }

    private void LoadLocal()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[language];
    }

    public void ChangeLanguage(int indexLang)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[indexLang];
        language = indexLang;
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("language", language);
    }

    private void LoadData()
    {
        language = PlayerPrefs.GetInt("language");
    }
}
