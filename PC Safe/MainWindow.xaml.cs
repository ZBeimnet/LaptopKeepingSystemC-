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

namespace PC_Safe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        pc_safeEntities dbObject = new pc_safeEntities();
        public static librarian currentLibrarian;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = username.Text;
            string pass = password.Password.ToString();
            bool isValidLabrarian = dbObject.librarians.Any(i => i.Username == user);

            if(user.Equals("") && pass.Equals(""))
            {
                validation.Text = "Username and Password Fields are Empty!";
            }
            else if(user.Equals(""))
            {
                validation.Text = "Empty Username Field!";
            }
            else if (pass.Equals(""))
            {
                validation.Text = "Empty Password Field!";
            }
            else
            {
                if (isValidLabrarian)
                {
                    currentLibrarian = dbObject.librarians.Find(user);
                    if (currentLibrarian.Password.Equals(pass))
                    {
                        Window1 p = new Window1();
                        p.Show();
                        this.Close();
                    }
                    else
                    {
                        validation.Text = "Wrong Password!";
                    }
                }
                else
                {
                    validation.Text = "Wrong Username";
                }
            }
            
        }
           
    }
 }

