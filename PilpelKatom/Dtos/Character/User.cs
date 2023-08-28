namespace PilpelKatom.Dtos.Character;

public class User
{
    public int Id { get; set; }
    public string Username{ get; set; } = String.Empty;
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
}