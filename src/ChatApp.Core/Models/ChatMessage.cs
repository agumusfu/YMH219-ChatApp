using System.Text.Json;

namespace ChatApp.Core.Models;

/// <summary>
/// Ağ üzerinden iletilen mesajın türünü belirler.
/// </summary>
public enum MessageType
{
    Chat,       // Herkese açık genel sohbet mesajı
    Private,    // İki kullanıcı arasında özel mesaj (DM)
    System,     // Sunucu bilgilendirme veya hata mesajı
    Join,       // İstemcinin odaya katılma bildirimi
    Leave,      // İstemcinin ayrılma bildirimi
    UserList    // Çevrimiçi kullanıcı listesi senkronizasyonu
}

/// <summary>
/// İstemci ve sunucu arasında TCP/IP üzerinden JSON formatında taşınan ortak mesaj modeli.
/// </summary>
public class ChatMessage
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N")[..8];
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public MessageType Type { get; set; } = MessageType.Chat;
    public string Sender { get; set; } = string.Empty;
    public string Recipient { get; set; } = "ALL";
    public string Content { get; set; } = string.Empty;
    public List<string>? OnlineUsers { get; set; }

    public string ToJson() => JsonSerializer.Serialize(this);

    public static ChatMessage? FromJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json)) return null;
        try
        {
            return JsonSerializer.Deserialize<ChatMessage>(json);
        }
        catch
        {
            return null;
        }
    }

    public string ToDisplayString()
    {
        return Type switch
        {
            MessageType.Private => $"[{Timestamp:HH:mm:ss}] [ÖZEL: {Sender} -> {Recipient}] {Content}",
            MessageType.System => $"[{Timestamp:HH:mm:ss}] [SİSTEM] {Content}",
            MessageType.Join => $"[{Timestamp:HH:mm:ss}] [+] {Sender} sohbete katıldı.",
            MessageType.Leave => $"[{Timestamp:HH:mm:ss}] [-] {Sender} sohbetten ayrıldı.",
            _ => $"[{Timestamp:HH:mm:ss}] {Sender}: {Content}"
        };
    }
}
