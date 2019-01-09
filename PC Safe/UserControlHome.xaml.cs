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
    /// Interaction logic for UserControlHome.xaml
    /// </summary>

    public partial class UserControlHome : UserControl
    {
        pc_safeEntities dbObject = new pc_safeEntities();
        
        public UserControlHome()
        {
            InitializeComponent();
            displayedCard.Visibility = Visibility.Collapsed;
            displayEntryConfirmation.Visibility = Visibility.Collapsed;
            //li.IsActive = false;
        }

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            //string identification_num = idTextBox.Text;

            //bool isValidStudent = dbObject.students.Any(i => i.Id == identification_num);
            //bool inCurrentUsers = dbObject.currentusers.Any(i => i.Id == identification_num);

            //if (isValidStudent)
            //{
            //    AddOrRemoveCurrentUser(inCurrentUsers, identification_num);
            //}
            //else
            //{
            //    confirmationMessage.Text = "Student Not Registered!";
            //    displayEntryConfirmation.Visibility = Visibility.Visible;
            //    confirmationButton.Focus();
            //}
        }

        private void AddOrRemoveCurrentUser(bool inCurrentUsers, string identification_num)
        {
            student currentStud = dbObject.students.Find(identification_num);
            string laptop_user;
            if(currentStud.Laptop_serial_num != null)
            {
                laptop_user = "YES";
            }
            else
            {
                laptop_user = "NO";
            }
            if (!inCurrentUsers)
            {
                currentuser currentU = new currentuser
                {
                    Id = identification_num,
                    Name = currentStud.Name,
                    Entry_time = DateTime.Now.TimeOfDay,
                    Laptop_user = laptop_user,
                };

                dbObject.currentusers.Add(currentU);
                dbObject.SaveChanges();
                confirmationMessage.Foreground = new SolidColorBrush(Colors.Green);
                confirmationButton.Background = new SolidColorBrush(Colors.Green);
                confirmationMessage.Text = "Student added to current users.";
                displayEntryConfirmation.Visibility = Visibility.Visible;
                //confirmationButton.Focus();
            }

            else
            {
                currentuser leavingU = dbObject.currentusers.First(i => i.Id == identification_num);
                string id = leavingU.Id;
                history history = new history
                {
                    Id = leavingU.Id,
                    Name = currentStud.Name,
                    Entry_time = leavingU.Entry_time,
                    Leaving_time = DateTime.Now.TimeOfDay,
                    Laptop_user = laptop_user,
                };
                dbObject.histories.Add(history);
                dbObject.currentusers.Remove(leavingU);
                dbObject.SaveChanges();

                student leavingStud = dbObject.students.Find(id);
                byte[] studPhoto = leavingStud.Stud_photo;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(studPhoto))
                {
                    var imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = ms;
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.EndInit();

                    studentPhoto.Source = imageSource;
                }

                string haveLaptop = "";
                if (leavingStud.Laptop_serial_num != null)
                {
                    string laptopBrand = leavingStud.Laptop_brand;
                    brand.Text = laptopBrand;
                    haveLaptop = $"{leavingStud.Laptop_serial_num}";
                    
                    byte[] laptopPhoto = leavingStud.Laptop_photo;
                    
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(laptopPhoto))
                    {
                        var imageSource = new BitmapImage();
                        imageSource.BeginInit();
                        imageSource.StreamSource = ms;
                        imageSource.CacheOption = BitmapCacheOption.OnLoad;
                        imageSource.EndInit();

                        pcPhoto.Source = imageSource;
                    }
                }
                else
                {
                    pcPhoto.Source = null;
                    brand.Text = null;
                    haveLaptop = "No Laptop";
                }

               
                studentName.Text = leavingStud.Name;
                studentId.Text = leavingStud.Id;
                studentDepartment.Text = leavingStud.Department;
                laptopSerialNo.Text = haveLaptop;
                displayedCard.Visibility = Visibility.Visible;
                //checkButton.Focus();

            }
        }

        private void ButtonChecked_Click(object sender, RoutedEventArgs e)
        {
            displayedCard.Visibility = Visibility.Collapsed;
            idTextBox.Text = "";
            idTextBox.Focus();
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            displayEntryConfirmation.Visibility = Visibility.Collapsed;
            idTextBox.Text = "";
            idTextBox.Focus();
        }


        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string identification_num = idTextBox.Text;

            //if(idTextBox.IsFocused == true)
            //{
            //    li.IsActive = true;
            //}

            if (identification_num.Length == 11)
            {
                
                bool isValidStudent = dbObject.students.Any(i => i.Id == identification_num);
                bool inCurrentUsers = dbObject.currentusers.Any(i => i.Id == identification_num);

                if (isValidStudent)
                {
                    AddOrRemoveCurrentUser(inCurrentUsers, identification_num);
                }
                else
                {
                    confirmationButton.Background = new SolidColorBrush(Colors.Red);
                    confirmationMessage.Foreground = new SolidColorBrush(Colors.Red);
                    confirmationMessage.Text = "Student Not Registered!";
                    displayEntryConfirmation.Visibility = Visibility.Visible; 
                    //confirmationButton.Focus();
                }
            }
        }
    }
}
