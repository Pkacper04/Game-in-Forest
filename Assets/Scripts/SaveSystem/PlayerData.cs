using Game.PlayerInfo;


[System.Serializable]
public class PlayerData
{
    public float hungerTime;
    public float positionX;
    public float positionY;

        
    public PlayerData(PlayerHunger player)
    {
        hungerTime = player.time;
        positionX = player.transform.position.x;
        positionY = player.transform.position.y;
    }
}

