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
using System.Data.Entity;

namespace PC_Safe
{
    /// <summary>
    /// Interaction logic for UserControlHistory.xaml
    /// </summary>
    public partial class UserControlHistory : UserControl
    {
        private pc_safeEntities dbObj = new pc_safeEntities();

        public UserControlHistory()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            CollectionViewSource historyViewSource =
                    ((CollectionViewSource)(this.FindResource("historyViewSource")));

            dbObj.histories.Load();
            historyViewSource.Source = dbObj.histories.Local;

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void HistoryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
