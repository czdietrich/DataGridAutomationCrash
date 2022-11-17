namespace TestDataGridEditing;

using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();

        RebuildColumns();

        DataGrid.ItemsSource = new ObservableCollection<Item> { new() };
            
        KeyDown += OnKeyDown;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.F5)
            RebuildColumns();
    }

    private void RebuildColumns()
    {
        DataGrid.Columns.Clear();
        DataGrid.Columns.Add(new DataGridTextColumn{Header = nameof(Item.Value1), Binding = new Binding(nameof(Item.Value1))});
        DataGrid.Columns.Add(new DataGridTextColumn{Header = nameof(Item.Value2), Binding = new Binding(nameof(Item.Value2))});
    }
}

public sealed class Item
{
    public string? Value1 { get; set; }
    public string? Value2 { get; set; }
}