
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

    private GameObject[] screens;

    private bool loadoutEquipped = false;
    private bool primaryChanged = false;

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
    }

    // SCREEN MANAGEMENT
    public void ShowScreen(GameObject target)
    {
        foreach (GameObject screen in screens)
        {
            if (screen != null)
            {
                screen.SetActive(screen == target);
            }
        }
    }

    // NAVIGATION
    public void StartGame()
    {
        ShowScreen(mainMenuScreen);
    }

    public void OpenMainMenu()
    {
        ShowScreen(mainMenuScreen);
    }

    public void OpenModeSelect()
    {
        ShowScreen(modeSelectScreen);
    }

    public void OpenLevelSelect()
    {
        ShowScreen(levelSelectScreen);
    }

    public void OpenLoadout()
    {
        ShowScreen(loadoutScreen);
    }

    public void OpenShop()
    {
        ShowScreen(shopScreen);
    }

    public void OpenSettings()
    {
        ShowScreen(settingsScreen);
    }

    public void OpenPause()
    {
        ShowScreen(pauseScreen);
    }

    public void OpenResults()
    {
        ShowScreen(resultsScreen);
    }

    public void OpenCredits()
    {
        ShowScreen(creditsScreen);
    }

    public void BackToTitle()
    {
        ShowScreen(titleScreen);
    }

    // LOADOUT FUNCTIONALITY

    public void EquipLoadout()
    {
        loadoutEquipped = true;

        string primary = primaryChanged
            ? "TRANQUILIZER" : "SILENCED PISTOL";

        string secondary = secondaryChanged
            ? "FLASHBANG" : "SMOKE GRENADE";

        string gadget = gadgetChanged
            ? "MOTION SENSOR" : "NIGHT VISION";

        Debug.Log("LOADOUT EQUIPPED SUCCESSFULLY!");
        Debug.Log("PRIMARY: " + primary);
        Debug.Log("SECONDARY: " + secondary);
        Debug.Log("GADGET: " + gadget);
        Debug.Log("LOADOUT READY: " + loadoutEquipped);
    }


    // PRIMARY WEAPON SELECTION
    public void ChangePrimary()
    {
        primaryChanged = !primaryChanged;
        loadoutEquipped = false;

        if (primaryChanged)
        {
            if (primaryButtonText != null)
            {
                primaryButtonText.text =
                    "PRIMARY: TRANQUILIZER";
            }

            Debug.Log("PRIMARY SELECTED: TRANQUILIZER");
        }
        else
        {
            if (primaryButtonText != null)
            {
                primaryButtonText.text =
                    "PRIMARY: SILENCED PISTOL";
            }

            Debug.Log("PRIMARY SELECTED: SILENCED PISTOL");
        }
    }

    private bool secondaryChanged = false;

    public void ChangeSecondary()
    {
        secondaryChanged = !secondaryChanged;
        loadoutEquipped = false;

        if (secondaryButtonText != null)
        {
            secondaryButtonText.text = secondaryChanged
                ? "SECONDARY: FLASHBANG"
                : "SECONDARY: SMOKE GRENADE";
        }

        Debug.Log("SECONDARY SELECTED: " +
            (secondaryChanged ? "FLASHBANG" : "SMOKE GRENADE"));
    }

    private bool gadgetChanged = false;

    public void ChangeGadget()
    {
        gadgetChanged = !gadgetChanged;
        loadoutEquipped = false;

        if (gadgetButtonText != null)
        {
            gadgetButtonText.text = gadgetChanged
                ? "GADGET: MOTION SENSOR"
                : "GADGET: NIGHT VISION";
        }

        Debug.Log("GADGET SELECTED: " +
            (gadgetChanged ? "MOTION SENSOR" : "NIGHT VISION"));
    }


}
