namespace ChatApp.Core.Models;

/// <summary>
/// Sunucu tarafında bağlı bulunan her bir istemcinin temel bağlantı bilgilerini tutar.
/// </summary>
public class ConnectedClientInfo
{
    public string ClientId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public int Port { get; set; }
    public DateTime ConnectedAt { get; set; } = DateTime.Now;

    public string EndPoint => $"{IpAddress}:{Port}";
}
