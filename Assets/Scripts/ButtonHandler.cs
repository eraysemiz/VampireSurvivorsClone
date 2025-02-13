using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    MeleeWeaponBehaviour weaponB;
    UpgradeManager upgradeData;
    DatabaseManager db;
    PauseMenu pauseMenu;
    StartMenu startMenu;
    EndMenu endMenu;


    private void Start()
    {
        upgradeData = Object.FindAnyObjectByType<UpgradeManager>();
        pauseMenu = Object.FindAnyObjectByType<PauseMenu>();
        endMenu = Object.FindAnyObjectByType<EndMenu>();
        weaponB = Object.FindAnyObjectByType<MeleeWeaponBehaviour>();
        db = Object.FindAnyObjectByType<DatabaseManager>();
        
    }
    public void OnKnifeUpgradeButtonClick()
    {
        upgradeData.UpgradeKnifeWeapon();
    }

    public void OnGarlicUpgradeButtonClick()
    {
        upgradeData.UpgradeGarlicWeapon();
    }

    public void OnPhysicalStatsUpgradeButtonClick()
    {
        upgradeData.UpgradePhysicalStats();
    }

    public void OnContinueGameButtonClick()
    {
        pauseMenu.Continue();
    }

    public void OnEndGameButtonClick()
    {
        pauseMenu.EndGame();
    }

    public void OnNewGameButtonClick()
    {
        endMenu.NewGame();
    }
    public void OnStartGameButtonClick()
    {
        SceneManager.LoadScene("Game");
     
    }
    public void OnScoreboardButtonClick()
    {
       db.LoadScoreBoard();
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

}
