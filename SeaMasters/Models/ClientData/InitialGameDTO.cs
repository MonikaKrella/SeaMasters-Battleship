namespace SeaMasters.Models.ClientData;

public class InitialGameDTO
{
    public string Id { get; }
    public Player[] Players { get; }

    public InitialGameDTO(string argId, Player[] argPlayers)
    {
        Id = argId;
        Players = argPlayers;
    }
}