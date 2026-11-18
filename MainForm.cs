namespace Rifad.ERP.UI;

internal sealed class MainForm : Form
{
    public MainForm()
    {
        Text = "رِفاد ERP | نظام الحسابات والمخازن";
        StartPosition = FormStartPosition.CenterScreen;
        Width = 1100;
        Height = 720;
        MinimumSize = new Size(900, 600);
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        BackColor = Color.FromArgb(245, 247, 250);
        Font = new Font("Segoe UI", 10F);

        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 88,
            BackColor = Color.FromArgb(25, 43, 70),
            Padding = new Padding(24, 12, 24, 12)
        };

        var title = new Label
        {
            Dock = DockStyle.Fill,
            Text = "رِفاد ERP\nنظام إدارة الحسابات والمخازن",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 17F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleRight
        };
        header.Controls.Add(title);

        var body = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(24),
            ColumnCount = 2,
            RowCount = 2,
            BackColor = BackColor
        };
        body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        body.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        body.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

        AddModuleCard(body, "الحسابات العامة", "دليل الحسابات والقيود وميزان المراجعة", 0, 0);
        AddModuleCard(body, "الخزينة", "متابعة المقبوضات والمدفوعات", 1, 0);
        AddModuleCard(body, "العملاء والموردون", "بيانات الأطراف والأرصدة", 0, 1);
        AddModuleCard(body, "المخازن", "الأصناف وحركة المخزون", 1, 1);

        Controls.Add(body);
        Controls.Add(header);
    }

    private static void AddModuleCard(TableLayoutPanel parent, string heading, string description, int column, int row)
    {
        var card = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            Margin = new Padding(10),
            Padding = new Padding(20),
            BorderStyle = BorderStyle.FixedSingle
        };

        var title = new Label
        {
            Dock = DockStyle.Top,
            Height = 42,
            Text = heading,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            ForeColor = Color.FromArgb(25, 43, 70),
            TextAlign = ContentAlignment.MiddleRight
        };

        var details = new Label
        {
            Dock = DockStyle.Fill,
            Text = description + "\n\nهذه الوحدة واجهة مبدئية وسيتم تنفيذ وظائفها واختبارها لاحقًا.",
            ForeColor = Color.DimGray,
            TextAlign = ContentAlignment.TopRight
        };

        card.Controls.Add(details);
        card.Controls.Add(title);
        parent.Controls.Add(card, column, row);
    }
}
