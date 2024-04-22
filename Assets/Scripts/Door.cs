using System;
using UnityEngine;

public class OteviraniDveri : MonoBehaviour
{
    // Public variables
    public GameObject[] dvereSpriteZavrene; // Pole se spritey zavřených dveří
    public GameObject[] dvereSpriteOtevrene; // Pole se spritey otevřených dveří
    public string jmenoNestvury; // Jméno nestvůry, která musí být zabita

    // Private variables
    private bool dvereOtevreny = false;

    void Start()
    {
        // Zkontrolujte, zda existují všechny potřebné objekty
        if (dvereSpriteZavrene.Length == 0 || dvereSpriteOtevrene.Length == 0)
        {
            Debug.LogError("Chyba: Nebyly zadány všechny potřebné objekty!");
            return;
        }

        // Deaktivujte spritey otevřených dveří
        foreach (GameObject sprite in dvereSpriteOtevrene)
        {
            sprite.SetActive(false);
        }
    }

    public event Action OnEnemyDeath;

    public void OtevriDvere()
    {
        foreach (GameObject sprite in dvereSpriteOtevrene)
        {
            sprite.SetActive(true);
        }

        
        foreach (GameObject sprite in dvereSpriteZavrene)
        {
            sprite.SetActive(false);
        }
    }
}

