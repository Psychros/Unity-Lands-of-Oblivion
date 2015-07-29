using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Localizer : MonoBehaviour
{
    #region Public inspector "properties" ;-)
    public string forceLanguage = "";
    public LanguageFile[] languageFiles = new LanguageFile[1];
    #endregion Public inspector "properties" ;-)

    private Dictionary<string, string> entries = new Dictionary<string, string>();

    #region Unity Singleton Pattern
    private static Localizer instance = null;
    /// <summary>
    ///     Gets the singleton instance of the Localizer.
    /// </summary>
    public static Localizer Instance
    {
        get { return instance; }
    }

    /// <summary>
    ///     Initializes the Localizer singleton instance or destroys obsolete instances.
    /// </summary>
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion Unity Singleton Pattern

    public string GetText(string key, params object[] args)
    {
        if (entries.Count == 0)
        {
            Initialize();
        }
        if (entries.ContainsKey(key))
        {
            return string.Format(entries[key], args);
        }
        else
        {
            return string.Format("Key: '{0}' not found!", key);
        }
    }

    public string UserLocaleName
    {
        get
        {
            string result;
            string userLocale = PlayerPrefs.GetString("UserLocale", "en");
            switch (userLocale)
            {
                case "de": result = "Deutsch"; break;
                default: result = "English"; break;
            }
            return result;
        }
    }

    public void LoadLocalizationFile(string userLocale)
    {
        TextAsset languageFile = null;
        foreach (LanguageFile file in languageFiles)
        {
            if (file.languageKey.Equals(userLocale))
            {
                languageFile = file.translationFile;
                break;
            }
        }
        if (languageFile == null)
        {
            languageFile = languageFiles[0].translationFile;
        }

        entries.Clear();

        string[] lines = languageFile.text.Split('\n');

        int lineCount = 0;

        foreach (string line in lines)
        {
            string[] keyValue = line.Split('=');
            if (keyValue.Length == 2)
            {
                entries[keyValue[0].Trim()] = keyValue[1].Trim();
            }
            lineCount++;
        }
    }

    #region Initialization

    private void Initialize()
    {
        // check if platform locale has changed - if so, reset UserLocale to platform locale
        string lastPlatformLocale = PlayerPrefs.GetString("LastPlatformLocale", null);
        string currentPlatformLocale = CurrentPlatformLocale;
        if (lastPlatformLocale != null)
        {
            if (!lastPlatformLocale.Equals(currentPlatformLocale))
            {
                PlayerPrefs.SetString("UserLocale", currentPlatformLocale);
            }
        }
        else
        { // no lastPlatformLocale => first time playing :-)
            PlayerPrefs.SetString("UserLocale", currentPlatformLocale);
        }

        // next time we know the LastPlatformLocale ;-)
        PlayerPrefs.SetString("LastPlatformLocale", currentPlatformLocale);

        if (forceLanguage != null && !forceLanguage.Trim().Equals(string.Empty))
        {
            PlayerPrefs.SetString("UserLocale", forceLanguage);
        }

        string userLocale = PlayerPrefs.GetString("UserLocale", currentPlatformLocale);

        LoadLocalizationFile(userLocale);
    }

    private string CurrentPlatformLocale
    {
        get
        {
            string result = null;
            if (Application.systemLanguage != SystemLanguage.Unknown)
            {
                switch (Application.systemLanguage)
                {
                    case SystemLanguage.German: result = "de"; break;
                    // support more languages as we get people translating ;-)
                    default: result = "en"; break;
                }
            }
            else
            {
                // hack for Apple iOS
                result = PlayerPrefs.GetString("language", null);

                if (result == null || (!result.Equals("en") && !result.Equals("de")))
                { // unsupported language?
                    result = "en";
                }

                // this only works, when the following code can be found in AppController.mm:

                /* 
                  - (void) applicationDidFinishLaunching:(UIApplication*)application
                  {
                  	// JC (2011-02-27): Added from http://forum.unity3d.com/threads/14370-Localization-within-an-iphone-app-made-in-unity/page2
                  	NSUserDefaults *defaults = [NSUserDefaults standardUserDefaults];
                  	NSArray *languages = [defaults objectForKey:@"AppleLanguages"];
                  	NSString *currentLanguage = [languages objectAtIndex:0];
                  	
                  	[[NSUserDefaults standardUserDefaults] setObject:currentLanguage forKey:@"language"];
                  	[[NSUserDefaults standardUserDefaults] synchronize];
                  	// END JC (2011-02-27)
                  	
                  	printf_console("-> applicationDidFinishLaunching()\n");
                  	[self startUnity:application];
                  }
                 */
            }
            return result;
        }
    }
    #endregion Initialization
}

[System.Serializable]
public class LanguageFile
{
    public string languageKey = "en";
    public TextAsset translationFile = null;
}