using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSeedDisplay : MonoBehaviour
{
    public CropController.CropType crop;
    public Image seedImage;
    public TMP_Text seedAmount, priceText;


    public void UpdateDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        seedImage.sprite = info.seedType;
        seedAmount.text = "x"+info.seedAmount.ToString();
        priceText.text = "$"+info.seedPrice.ToString()+" each";
    }

    public void BuySeed(int amount)
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        if(CurrencyController.instance.CheckMoney(info.seedPrice * amount))
        {
          CropController.instance.addSeed(crop,amount);

          CurrencyController.instance.SpendMoney(info.seedPrice * amount);

          UpdateDisplay();
            
          AudioManager.instance.PlaySFXPitchAdjusted(5);

        }
    }
}
