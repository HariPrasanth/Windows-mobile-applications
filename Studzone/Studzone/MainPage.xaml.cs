using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Studzone.Resources;
using System.Windows.Media;

namespace Studzone
{    
    public partial class MainPage : PhoneApplicationPage
    {
        public static String link, rollno,title;
        public static int pos = 0;
        int succcess = 0;
        // Constructor
        public MainPage()
        {
            InitializeComponent();                         
            rollno = "";                        
            pos = 2;
            link = "getcamark.php";
            title = "CA Marks";
            attendance.Background = new SolidColorBrush(Colors.Gray);
            camarks.Background = new SolidColorBrush(Colors.Purple);
            Testtimetable.Background = new SolidColorBrush(Colors.Gray);
            ExamResult.Background = new SolidColorBrush(Colors.Gray);
            Semester.Background = new SolidColorBrush(Colors.Gray);
            Seat.Background = new SolidColorBrush(Colors.Gray);
            attendance.Foreground = new SolidColorBrush(Colors.Black);
            camarks.Foreground = new SolidColorBrush(Colors.White);
            Testtimetable.Foreground = new SolidColorBrush(Colors.Black);
            ExamResult.Foreground = new SolidColorBrush(Colors.Black);
            Semester.Foreground = new SolidColorBrush(Colors.Black);
            Seat.Foreground = new SolidColorBrush(Colors.Black);
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            attendance.Background = new SolidColorBrush(Colors.Purple);
            camarks.Background = new SolidColorBrush(Colors.Gray);
            Testtimetable.Background = new SolidColorBrush(Colors.Gray);
            ExamResult.Background = new SolidColorBrush(Colors.Gray);
            Semester.Background = new SolidColorBrush(Colors.Gray);
            Seat.Background = new SolidColorBrush(Colors.Gray);
            attendance.Foreground = new SolidColorBrush(Colors.White);
            camarks.Foreground = new SolidColorBrush(Colors.Black);
            Testtimetable.Foreground = new SolidColorBrush(Colors.Black);
            ExamResult.Foreground = new SolidColorBrush(Colors.Black);
            Semester.Foreground = new SolidColorBrush(Colors.Black);
            Seat.Foreground = new SolidColorBrush(Colors.Black);
            pos = 1;
            title = "Attendance";
            link = "getstudentattendance.php";            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pos = 2;
            link = "getcamark.php";
            title = "CA Marks";
            attendance.Background = new SolidColorBrush(Colors.Gray);
            camarks.Background = new SolidColorBrush(Colors.Purple);
            Testtimetable.Background = new SolidColorBrush(Colors.Gray);
            ExamResult.Background = new SolidColorBrush(Colors.Gray);
            Semester.Background = new SolidColorBrush(Colors.Gray);
            Seat.Background = new SolidColorBrush(Colors.Gray);
            attendance.Foreground = new SolidColorBrush(Colors.Black);
            camarks.Foreground = new SolidColorBrush(Colors.White);
            Testtimetable.Foreground = new SolidColorBrush(Colors.Black);
            ExamResult.Foreground = new SolidColorBrush(Colors.Black);
            Semester.Foreground = new SolidColorBrush(Colors.Black);
            Seat.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            pos = 3;
            link = "gettesttimetable.php";
            title = "Test Timetable";
            attendance.Background = new SolidColorBrush(Colors.Gray);
            camarks.Background = new SolidColorBrush(Colors.Gray);
            Testtimetable.Background = new SolidColorBrush(Colors.Purple);
            ExamResult.Background = new SolidColorBrush(Colors.Gray);
            Semester.Background = new SolidColorBrush(Colors.Gray);
            Seat.Background = new SolidColorBrush(Colors.Gray);
            attendance.Foreground = new SolidColorBrush(Colors.Black);
            camarks.Foreground = new SolidColorBrush(Colors.Black);
            Testtimetable.Foreground = new SolidColorBrush(Colors.White);
            ExamResult.Foreground = new SolidColorBrush(Colors.Black);
            Semester.Foreground = new SolidColorBrush(Colors.Black);
            Seat.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            pos = 4;
            link = "getexamresult.php";
            title = "Exam Result";
            attendance.Background = new SolidColorBrush(Colors.Gray);
            camarks.Background = new SolidColorBrush(Colors.Gray);
            Testtimetable.Background = new SolidColorBrush(Colors.Gray);
            ExamResult.Background = new SolidColorBrush(Colors.Purple);
            Semester.Background = new SolidColorBrush(Colors.Gray);
            Seat.Background = new SolidColorBrush(Colors.Gray);
            attendance.Foreground = new SolidColorBrush(Colors.Black);
            camarks.Foreground = new SolidColorBrush(Colors.Black);
            Testtimetable.Foreground = new SolidColorBrush(Colors.Black);
            ExamResult.Foreground = new SolidColorBrush(Colors.White);
            Semester.Foreground = new SolidColorBrush(Colors.Black);
            Seat.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            pos = 5;
            link = "getexamtimetable.php";
            title = "Semester";
            attendance.Background = new SolidColorBrush(Colors.Gray);
            camarks.Background = new SolidColorBrush(Colors.Gray);
            Testtimetable.Background = new SolidColorBrush(Colors.Gray);
            ExamResult.Background = new SolidColorBrush(Colors.Gray);
            Semester.Background = new SolidColorBrush(Colors.Purple);
            Seat.Background = new SolidColorBrush(Colors.Gray);
            attendance.Foreground = new SolidColorBrush(Colors.Black);
            camarks.Foreground = new SolidColorBrush(Colors.Black);
            Testtimetable.Foreground = new SolidColorBrush(Colors.Black);
            ExamResult.Foreground = new SolidColorBrush(Colors.Black);
            Semester.Foreground = new SolidColorBrush(Colors.White);
            Seat.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            pos = 6;
            link = "getseatingarrangement.php";
            title = "Seating";
            attendance.Background = new SolidColorBrush(Colors.Gray);
            camarks.Background = new SolidColorBrush(Colors.Gray);
            Testtimetable.Background = new SolidColorBrush(Colors.Gray);
            ExamResult.Background = new SolidColorBrush(Colors.Gray);
            Semester.Background = new SolidColorBrush(Colors.Gray);
            Seat.Background = new SolidColorBrush(Colors.Purple);
            attendance.Foreground = new SolidColorBrush(Colors.Black);
            camarks.Foreground = new SolidColorBrush(Colors.Black);
            Testtimetable.Foreground = new SolidColorBrush(Colors.Black);
            ExamResult.Foreground = new SolidColorBrush(Colors.Black);
            Semester.Foreground = new SolidColorBrush(Colors.Black);
            Seat.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (pos == 0)
            {
                MessageBox.Show("Please Choose One Option!!!");
            }
            else if (roll.Text.Equals(""))
            {
                MessageBox.Show("Please Enter RollNumber!!!");
            }
            else
            {
                rollno = roll.Text;
                NavigationService.Navigate(new Uri("/Attendance.xaml", UriKind.Relative));
            }
        }

    }
}