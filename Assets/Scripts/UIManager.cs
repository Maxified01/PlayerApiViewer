using System.Linq;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text positionText;

    public TMP_Text statusText;

    public Transform inventoryParent;

    public GameObject inventoryPrefab;

    public void DisplayPlayer(PlayerRecord player)
    {
        playerNameText.text = "Player: " + player.playerName;

        levelText.text = "Level: " + player.level;

        healthText.text = "Health: " + player.health;

        positionText.text =
            "Position: (" +
            player.position.x + ", " +
            player.position.y + ", " +
            player.position.z + ")";

        foreach (Transform child in inventoryParent)
            Destroy(child.gameObject);

        foreach (InventoryItem item in player.inventory.OrderBy(i => i.itemName))
        {
            GameObject obj = Instantiate(inventoryPrefab, inventoryParent);

            obj.GetComponent<TMP_Text>().text =
                item.itemName +
                " | Qty: " +
                item.quantity +
                " | Weight: " +
                item.weight;
        }

        statusText.text = "Loaded Successfully";
    }

    public void Error()
    {
        statusText.text = "Failed to Load Data";
    }
}