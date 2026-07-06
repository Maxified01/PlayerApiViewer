using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player Text Fields")]
    public TMP_Text playerNameText;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text positionText;

    [Header("Status Fields")]
    public TMP_Text statusText;

    [Header("Inventory List Setup")]
    [Tooltip("Drag the 'Content' object from inside your Scroll View here!")]
    public Transform inventoryContentParent;
    public GameObject inventoryPrefab;

    public void DisplayPlayer(PlayerRecord player)
    {
        playerNameText.text = "Player: " + player.playerName;
        levelText.text = "Level: " + player.level;
        healthText.text = "Health: " + player.health;
        positionText.text = $"Position: ({player.position.x}, {player.position.y}, {player.position.z})";

        foreach (Transform child in inventoryContentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (InventoryItem item in player.inventory.OrderBy(i => i.itemName))
        {
            GameObject obj = Instantiate(inventoryPrefab, inventoryContentParent);

            obj.GetComponent<TMP_Text>().text =
                $"{item.itemName} | Qty: {item.quantity} | Weight: {item.weight}";
        }

        Canvas.ForceUpdateCanvases();
        if (inventoryContentParent.TryGetComponent<VerticalLayoutGroup>(out var layout))
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)inventoryContentParent);
        }

        statusText.text = "Loaded Successfully";
    }

    public void Error()
    {
        statusText.text = "THE REFRESH BUTTON WAS CLICKED!!!";
    }
}
