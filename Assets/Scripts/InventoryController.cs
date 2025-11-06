using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public SeedDisplay[] seeds;
    public void OpenClose()
    {
        if(gameObject.activeSelf==false)
        {
            gameObject.SetActive(true);

            UpdateDisplay();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateDisplay()
    {
        foreach(SeedDisplay display in seeds)
        {
            display.UpdateDisplay();
        }
    }

}
