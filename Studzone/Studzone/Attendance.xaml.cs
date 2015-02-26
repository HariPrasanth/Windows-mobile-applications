using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Net.NetworkInformation;
using System.IO;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Media;

namespace Studzone
{
    public partial class Attendance : PhoneApplicationPage
    {
        static String php_file;
        public static string Data = "null";       
        static String rollno;
        static String url,pagetitle;
        static int pos;
        static string name,rollnum,status,course,semester;        
        public Attendance()
        {
            InitializeComponent();
            php_file = MainPage.link;
            rollno = MainPage.rollno;
            pos = MainPage.pos;
            pagetitle = MainPage.title;
            title.Text = pagetitle;
            url = Links.URL + php_file;            
            progress.Visibility = Visibility.Visible;
            progress.IsIndeterminate = true; 
            if(isNetworkConnected()){
                httpPost();
            }
            else
            {
                MessageBox.Show("Check Internet Connectivity!!!");
            }
        }

        bool isNetworkConnected()
        {
            if (DeviceNetworkInformation.IsNetworkAvailable)
            {
                return true;                
            }
            else
            {
                return false;
            }
        }        
        async void httpPost()
        {                        
            var values = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("rollno", rollno),                    
                };
            var httpClient = new HttpClient(new HttpClientHandler());
            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(url, new FormUrlEncodedContent(values));
                response.EnsureSuccessStatusCode();                 
                string responseString = await response.Content.ReadAsStringAsync();                
                var jobj = JObject.Parse(responseString);
                status = (String)jobj[Links.STATUS];
                rollnum= (String)jobj[Links.ROLLNO];
                name = (String)jobj[Links.STUD_NAME];
                course = (String)jobj[Links.COURSE];
                semester = (String)jobj[Links.SEMESTER];
                var token = (JArray)jobj.SelectToken(Links.STUD_CA_LIST);
                progress.Visibility = Visibility.Collapsed;
                progress.IsIndeterminate = false;
                ContentPanel.Opacity = 1;
                if (status.Equals("404")||responseString==null)
                {
                    detailstext.Visibility = Visibility.Visible;
                    rollvisible.Visibility = Visibility.Collapsed;
                    rolltext.Visibility = Visibility.Collapsed;
                    namevisible.Visibility = Visibility.Collapsed;
                    nametext.Visibility = Visibility.Collapsed;
                    coursevisible.Visibility = Visibility.Collapsed;
                    coursetext.Visibility = Visibility.Collapsed;
                    sem.Visibility = Visibility.Collapsed;
                    semtext.Visibility = Visibility.Collapsed;
                }
                else
                {
                    rolltext.FontWeight = FontWeights.Normal;
                    rolltext.Text = rollnum;
                    nametext.FontWeight = FontWeights.Normal;
                    nametext.Text = name;
                    coursetext.FontWeight = FontWeights.Normal;
                    coursetext.Text = course;
                    if (pos == 1 || pos == 2)
                    {
                        semtext.FontWeight = FontWeights.Normal;
                        semtext.Text = semester;
                    }
                    else
                    {
                        sem.Visibility = Visibility.Collapsed;
                        semtext.Visibility = Visibility.Collapsed;
                    }                   
                    List<List<string>> caList = new List<List<string>>();
                    JArray StudCAList = token as JArray;
                    gridcontent.ShowGridLines = true;
                    int noOf = 0;
                    for (int j = 0; j < StudCAList.Count; j++)
                    {                                        
                        JArray item = StudCAList.ElementAt(j) as JArray;
                        JArray item1 = StudCAList.ElementAt(0) as JArray;                                                
                            for (int i = 0; i < item.Count; i++)
                            {                                
                                JArray item2 = item.ElementAt(i) as JArray;                                
                                RowDefinition gridRow1 = new RowDefinition();                                
                                gridRow1.Height = GridLength.Auto;                                                                
                                for (int k = 0; k < item2.Count; k++)
                                {
                                    string x = item2.ElementAt(k).ToString();
                                    ColumnDefinition gridCol1 = new ColumnDefinition();
                                    gridCol1.Width = GridLength.Auto;
                                    gridcontent.ColumnDefinitions.Add(gridCol1);
                                    TextBlock txtBlock1 = new TextBlock();
                                    txtBlock1.Text = x;
                                    txtBlock1.FontSize = 24;
                                    if (i == 0)
                                    {
                                        txtBlock1.FontWeight = FontWeights.Bold;
                                        txtBlock1.Foreground = new SolidColorBrush(Colors.Black);                                        
                                    }
                                    else
                                    {
                                        txtBlock1.FontWeight = FontWeights.SemiBold;
                                        txtBlock1.Foreground = new SolidColorBrush(Colors.Blue);
                                    }
                                    txtBlock1.VerticalAlignment = VerticalAlignment.Center;
                                    txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
                                    Grid.SetRow(txtBlock1, noOf);
                                    Grid.SetColumn(txtBlock1, k);
                                    gridcontent.Children.Add(txtBlock1);                                    
                                }
                                noOf++;
                                gridcontent.RowDefinitions.Add(gridRow1);
                            }                                                                                                                                                    
                    }
                    caList.ToList();
                }                
            }
            catch(HttpRequestException e)
            {                
                progress.Visibility = Visibility.Collapsed;
                progress.IsIndeterminate = false;
                MessageBox.Show("Check Internet Connectivity!!!");
            }catch(JsonReaderException e){                
                progress.Visibility = Visibility.Collapsed;
                progress.IsIndeterminate = false;
                detailstext.Visibility = Visibility.Visible;
                rollvisible.Visibility = Visibility.Collapsed;
                rolltext.Visibility = Visibility.Collapsed;
                namevisible.Visibility = Visibility.Collapsed;
                nametext.Visibility = Visibility.Collapsed;
                coursevisible.Visibility = Visibility.Collapsed;
                coursetext.Visibility = Visibility.Collapsed;
                sem.Visibility = Visibility.Collapsed;
                semtext.Visibility = Visibility.Collapsed;
            }
        }        
    }
}