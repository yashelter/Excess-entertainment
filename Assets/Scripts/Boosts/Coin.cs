using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollectableItem
{
    public int value;
    public override void IsCollected(Player player)
    {
        // тута добавляем валюту игроку
    }
}
