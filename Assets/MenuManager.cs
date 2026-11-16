
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
}
