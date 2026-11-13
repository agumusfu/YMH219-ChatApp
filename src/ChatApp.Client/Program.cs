namespace ChatApp.Client;

static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ClientForm());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
