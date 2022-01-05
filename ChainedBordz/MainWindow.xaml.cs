using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChainedBordz.Entities;
using System.Text.Json;

namespace ChainedBordz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Node prevNode = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddKeyValueBtn_Click(object sender, RoutedEventArgs e)
        {
            if(TxtKey.Text.Length>0&& TxtKeyValue.Text.Length > 0)
            {
                Node n = Node.CreateNode(TxtKeyValue.Text, TxtKey.Text, prevNode);
                prevNode = n;
                Label lbl = new Label();
                lbl.Content = n.Data;
                blockPanel.Children.Add(lbl);
            }
            
        }

        private void SeeJsonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Node? currentNode = prevNode;
            IList<Node> nodes = new List<Node>();
           
            txtJson.Text = JsonSerializer.Serialize(prevNode);
        }
    }
}
