using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Singleton instance
    public static UIController instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {            
            Destroy(gameObject);
        }
    }


    public GameObject[] toolbarActivatorIcons;

    public TMP_Text timeText;

    public InventoryController inventoryController;
    public ShopController shopController;

    public Image seedImage;
    public TMP_Text moneyText;

    public GameObject pauseScreen;
    public string menuScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            inventoryController.OpenClose();
        }
#if UNITY_EDITOR
        if(Keyboard.current.bKey.wasPressedThisFrame)
        {
            shopController.OpenClose();
        }
#endif
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PauseUnpause();
        }
    }
        
    public void SwitchTool(int selected)
    {
       foreach(GameObject icon in toolbarActivatorIcons)
       {
            icon.SetActive(false);
       }

        toolbarActivatorIcons[selected].SetActive(true);
    }

    public void UpdateTimeText(float currentTime)
    {
        switch (currentTime)
        {
            case < 12:
                timeText.text = Mathf.FloorToInt(currentTime) + " AM";
            break;
            case < 13:
                timeText.text = "12 PM";
            break;
            case < 24:
                timeText.text = Mathf.FloorToInt(currentTime - 12) + " PM";
            break;
            case < 25:
                timeText.text = "12 AM";
            break;
            case > 25:
                timeText.text = Mathf.FloorToInt(currentTime - 24) + " AM";
            break;
        }  
    }

    public void SwitchSeed(CropController.CropType crop)
    {
        seedImage.sprite = CropController.instance.GetCropInfo(crop).seedType;
    }

    public void UpdateMoneyText(float currentMoney)
    {
        moneyText.text = "$" + currentMoney.ToString();
    }

    public void PauseUnpause()
    {
        if(pauseScreen.activeSelf == false)
        { 
            pauseScreen.SetActive(true);
            
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menuScene);
        Time.timeScale = 1f;

        Destroy(gameObject);
        Destroy(PlayerController.instance.gameObject);
        Destroy(GridInfo.instance.gameObject);
        Destroy(TimeController.instance.gameObject);
        Destroy(CropController.instance.gameObject);
        Destroy(CurrencyController.instance.gameObject);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
