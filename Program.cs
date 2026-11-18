using Rifad.ERP.Data;
using Rifad.ERP.UI;

namespace Rifad.ERP;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        DatabaseInitializer.Initialize();
        Application.Run(new MainForm());
    }
}
