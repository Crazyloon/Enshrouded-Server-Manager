namespace Enshrouded_Server_Manager.Helpers;
public static class GenerateText
{
    public static string RandomServerName(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return "Server" + new string(Enumerable.Repeat(chars, length)
                     .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
