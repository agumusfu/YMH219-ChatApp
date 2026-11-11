using System.Text;
using ChatApp.Core.Models;

namespace ChatApp.Core.Services;

/// <summary>
/// İsteğe bağlı geliştirme: Mesaj geçmişini StreamWriter ile .txt dosyasına kaydeden servis.
/// </summary>
public class ChatHistoryService
{
    public (bool Success, string Message) SaveHistoryToFile(string filePath, IEnumerable<string> lines, string title = "YMH219 - Sohbet Geçmişi")
    {
        try
        {
            var list = lines.ToList();
            if (list.Count == 0)
                return (false, "Kaydedilecek herhangi bir mesaj geçmişi bulunmuyor.");

            string? dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
            writer.WriteLine("=================================================================");
            writer.WriteLine($"  {title}");
            writer.WriteLine($"  Kaydedilme Tarihi: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine($"  Toplam Satır:      {list.Count}");
            writer.WriteLine("=================================================================");
            writer.WriteLine();

            foreach (var line in list)
            {
                writer.WriteLine(line);
            }

            return (true, $"Mesaj geçmişi başarıyla kaydedildi:\n{filePath}");
        }
        catch (Exception ex)
        {
            return (false, $"Dosya kaydedilirken hata oluştu: {ex.Message}");
        }
    }
}
