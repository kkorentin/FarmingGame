using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedDisplay : MonoBehaviour
{
    public CropController.CropType crop;

    public Image seedImage;
    public TMP_Text seedAmount;

    public void UpdateDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        seedImage.sprite = info.seedType;
        seedAmount.text = info.seedAmount.ToString();
    }

    public void SelectedSeed()
    {

    }
}
