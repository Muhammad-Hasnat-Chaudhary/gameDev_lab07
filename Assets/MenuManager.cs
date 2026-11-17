
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("All 10 Screens")]
    public GameObject titleScreen;
    public GameObject mainMenuScreen;
    public GameObject modeSelectScreen;
    public GameObject levelSelectScreen;
    public GameObject loadoutScreen;
    public GameObject shopScreen;
    public GameObject settingsScreen;
    public GameObject pauseScreen;
    public GameObject resultsScreen;
    public GameObject creditsScreen;

    [Header("Loadout UI")]
    public TMP_Text primaryButtonText;
    public TMP_Text secondaryButtonText;
    public TMP_Text gadgetButtonText;

    [Header("Shop System")]
    public int credits = 500;
    public TMP_Text creditsText;

    private GameObject[] screens;

    private bool loadoutEquipped = false;
    private bool primaryChanged = false;
    private bool secondaryChanged = false;
    private bool gadgetChanged = false;

    private bool armorPurchased = false;
    private bool stealthPurchased = false;
    private bool speedPurchased = false;

    void Awake()
    {
        screens = new GameObject[]
        {
            titleScreen,
            mainMenuScreen,
            modeSelectScreen,
            levelSelectScreen,
            loadoutScreen,
            shopScreen,
            settingsScreen,
            pauseScreen,
            resultsScreen,
            creditsScreen
        };

        ShowScreen(titleScreen);
        UpdateLoadoutText();
        UpdateCreditsText();
    }

    // SCREEN MANAGEMENT

    public void ShowScreen(GameObject target)
    {
        if (target == null)
        {
            Debug.LogWarning("Target screen is not assigned!");
            return;
        }

        foreach (GameObject screen in screens)
        {
            if (screen != null)
                screen.SetActive(screen == target);
        }

        if (target == shopScreen)
            UpdateCreditsText();
    }

    // NAVIGATION

    public void StartGame() => ShowScreen(mainMenuScreen);

    public void OpenMainMenu() => ShowScreen(mainMenuScreen);

    public void OpenModeSelect() => ShowScreen(modeSelectScreen);

    public void OpenLevelSelect() => ShowScreen(levelSelectScreen);

    public void OpenLoadout() => ShowScreen(loadoutScreen);

    public void OpenShop() => ShowScreen(shopScreen);

    public void OpenSettings() => ShowScreen(settingsScreen);

    public void OpenPause() => ShowScreen(pauseScreen);

    public void OpenResults() => ShowScreen(resultsScreen);

    public void OpenCredits() => ShowScreen(creditsScreen);

    public void BackToTitle() => ShowScreen(titleScreen);

    // LOADOUT SYSTEM

    private void UpdateLoadoutText()
    {
        if (primaryButtonText != null)
        {
            primaryButtonText.text = primaryChanged
                ? "PRIMARY: TRANQUILIZER"
                : "PRIMARY: SILENCED PISTOL";
        }

        if (secondaryButtonText != null)
        {
            secondaryButtonText.text = secondaryChanged
                ? "SECONDARY: FLASHBANG"
                : "SECONDARY: SMOKE GRENADE";
        }

        if (gadgetButtonText != null)
        {
            gadgetButtonText.text = gadgetChanged
                ? "GADGET: MOTION SENSOR"
                : "GADGET: NIGHT VISION";
        }
    }

    public void ChangePrimary()
    {
        primaryChanged = !primaryChanged;
        loadoutEquipped = false;

        UpdateLoadoutText();

        Debug.Log("PRIMARY SELECTED: " +
            (primaryChanged ? "TRANQUILIZER" : "SILENCED PISTOL"));
    }

    public void ChangeSecondary()
    {
        secondaryChanged = !secondaryChanged;
        loadoutEquipped = false;

        UpdateLoadoutText();

        Debug.Log("SECONDARY SELECTED: " +
            (secondaryChanged ? "FLASHBANG" : "SMOKE GRENADE"));
    }

    public void ChangeGadget()
    {
        gadgetChanged = !gadgetChanged;
        loadoutEquipped = false;

        UpdateLoadoutText();

        Debug.Log("GADGET SELECTED: " +
            (gadgetChanged ? "MOTION SENSOR" : "NIGHT VISION"));
    }

    public void EquipLoadout()
    {
        loadoutEquipped = true;

        Debug.Log("LOADOUT EQUIPPED SUCCESSFULLY!");

        Debug.Log("PRIMARY: " +
            (primaryChanged ? "TRANQUILIZER" : "SILENCED PISTOL"));

        Debug.Log("SECONDARY: " +
            (secondaryChanged ? "FLASHBANG" : "SMOKE GRENADE"));

        Debug.Log("GADGET: " +
            (gadgetChanged ? "MOTION SENSOR" : "NIGHT VISION"));

        Debug.Log("LOADOUT READY: " + loadoutEquipped);
    }

    // SHOP SYSTEM

    private void UpdateCreditsText()
    {
        if (creditsText != null)
        {
            creditsText.text = "CREDITS: " + credits;
        }
    }

    public void BuyArmor()
    {
        if (armorPurchased)
        {
            Debug.Log("ARMOR ALREADY PURCHASED!");
            return;
        }

        if (credits < 200)
        {
            Debug.Log("NOT ENOUGH CREDITS!");
            return;
        }

        credits -= 200;
        armorPurchased = true;

        UpdateCreditsText();

        Debug.Log("ARMOR PURCHASED! BALANCE: " + credits);
    }

    public void BuyStealth()
    {
        if (stealthPurchased)
        {
            Debug.Log("STEALTH BOOST ALREADY PURCHASED!");
            return;
        }

        if (credits < 150)
        {
            Debug.Log("NOT ENOUGH CREDITS!");
            return;
        }

        credits -= 150;
        stealthPurchased = true;

        UpdateCreditsText();

        Debug.Log("STEALTH BOOST PURCHASED! BALANCE: " + credits);
    }

    public void BuySpeed()
    {
        if (speedPurchased)
        {
            Debug.Log("SPEED BOOST ALREADY PURCHASED!");
            return;
        }

        if (credits < 100)
        {
            Debug.Log("NOT ENOUGH CREDITS!");
            return;
        }

        credits -= 100;
        speedPurchased = true;

        UpdateCreditsText();

        Debug.Log("SPEED BOOST PURCHASED! BALANCE: " + credits);
    }

    public void ViewPurchases()
    {
        UpdateCreditsText();

        Debug.Log("CREDITS REMAINING: " + credits);

        Debug.Log("ARMOR: " +
            (armorPurchased ? "OWNED" : "NOT OWNED"));

        Debug.Log("STEALTH: " +
            (stealthPurchased ? "OWNED" : "NOT OWNED"));

        Debug.Log("SPEED: " +
            (speedPurchased ? "OWNED" : "NOT OWNED"));
    }

    [Header("Settings UI")]
    public TMP_Text musicButtonText;
    public TMP_Text soundButtonText;
    public TMP_Text qualityButtonText;

    private bool musicEnabled = true;
    private bool soundEnabled = true;
    private int qualityLevel = 1;

    public void ToggleMusic()
    {
        musicEnabled = !musicEnabled;

        if (musicButtonText != null)
            musicButtonText.text =
                musicEnabled ? "MUSIC: ON" : "MUSIC: OFF";

        Debug.Log("MUSIC: " + (musicEnabled ? "ON" : "OFF"));
    }

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;

        if (soundButtonText != null)
            soundButtonText.text =
                soundEnabled ? "SOUND: ON" : "SOUND: OFF";

        AudioListener.volume = soundEnabled ? 1f : 0f;

        Debug.Log("SOUND: " + (soundEnabled ? "ON" : "OFF"));
    }

    public void ChangeQuality()
    {
        qualityLevel = (qualityLevel + 1) % 3;

        string[] levels = { "LOW", "MEDIUM", "HIGH" };

        if (qualityButtonText != null)
            qualityButtonText.text =
                "QUALITY: " + levels[qualityLevel];

        QualitySettings.SetQualityLevel(
            Mathf.Min(qualityLevel,
                QualitySettings.names.Length - 1),
            true
        );

        Debug.Log("QUALITY: " + levels[qualityLevel]);
    }

    public void ResetSettings()
    {
        musicEnabled = true;
        soundEnabled = true;
        qualityLevel = 1;

        AudioListener.volume = 1f;

        if (musicButtonText != null)
            musicButtonText.text = "MUSIC: ON";

        if (soundButtonText != null)
            soundButtonText.text = "SOUND: ON";

        if (qualityButtonText != null)
            qualityButtonText.text = "QUALITY: MEDIUM";

        Debug.Log("SETTINGS RESET!");
    }

}
