using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    public Weapon weapon;
    public FloatingTextManager _floatingTextManager;

    //Logic
    public int pesetas;
    public int experience;

    //Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        _floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Upgrade Weapon
    public bool TryUpgradeWeapon()
    {
        //is the weapon max level
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;
        if(pesetas>= weaponPrices[weapon.weaponLevel])
        {
            pesetas -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }
        return false;
    }

    //Save state
    /*
     * INT preferedSkin
     * INT pesetas
     * Int experience
     * int weaponLevel
     */
    public void SaveState()
    {
        string s = "";

        s += "0" + " |";
        s += pesetas.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weaponLevel.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin
        pesetas = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change the weapon level
        weapon.SetWeaponLevel(int.Parse(data[3]));


        Debug.Log("Load State");
    }
}
