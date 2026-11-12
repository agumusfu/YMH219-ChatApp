namespace ChatApp.Server;

static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ServerForm());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Sunucu Başlatma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
