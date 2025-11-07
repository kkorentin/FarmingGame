using UnityEngine;

public class ShopController : MonoBehaviour
{
    public ShopSeedDisplay[] seeds;
    public void OpenClose()
    {
        if(UIController.instance.inventoryController.gameObject.activeSelf == false)
        {
            gameObject.SetActive(!gameObject.activeSelf);

            if(gameObject.activeSelf == true)
            {
                foreach(ShopSeedDisplay seed in seeds)
                {                     
                    seed.UpdateDisplay();
                }
            }
        }
        
    }

    public void UpdateDisplay()
    {
      
    }
}
