using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public ObservableCollection<Hipermarket> Hipermarketlist { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Hipermarketlist = new ObservableCollection<Hipermarket>();

            this.TypesCombobox.ItemsSource = Enum.GetValues(typeof(Hipermarket.Types)).Cast<Hipermarket.Types>();
            this.TypesCombobox.SelectedIndex = 0;
            this.MarksCombobox.ItemsSource = Enum.GetValues(typeof(Hipermarket.Marks)).Cast<Hipermarket.Marks>();
            this.MarksCombobox.SelectedIndex = 0;
            this.SpecificationCombobox.ItemsSource = Enum.GetValues(typeof(Hipermarket.Specification1)).Cast<Hipermarket.Specification1>();
            this.SpecificationCombobox.SelectedIndex = 0;

        }

        private  void AddButton_Click(object sender, RoutedEventArgs e)
        {


            string product = this.ProductTextbox.Text;
            float prize = float.Parse(this.PrizeTextbox.Text);
            Hipermarket.Types type = (Hipermarket.Types)Enum.Parse(typeof(Hipermarket.Types), this.TypesCombobox.Text);
            Hipermarket.Marks mark = (Hipermarket.Marks)Enum.Parse(typeof(Hipermarket.Marks), this.MarksCombobox.Text);
            Hipermarket.Specification1 sp1 = (Hipermarket.Specification1)Enum.Parse(typeof(Hipermarket.Specification1), this.SpecificationCombobox.Text);
            //Hipermarket.Specification1 sp2 = (Hipermarket.Specification2)Enum.Parse(typeof(Hipermarket.Specification2), this.SpecificationCombobox.Text);
              //tu pojawia się problem
     
                        
            Hipermarket hipermarket = new Hipermarket(product, prize, type, mark, sp1);



          

            Hipermarketlist.Add(hipermarket);

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hipermarketlist.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (Exception ex)
            {
                 MessageBox.Show("First select product" , "Delete Product");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "HipermarketListofproducts";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml*";

            Nullable<bool> result = dlg.ShowDialog();
            if( result == true)
            {
                string filePath = dlg.FileName;

                ListToXMlFile(filePath);
            }
        }

        private void ListToXMlFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Hipermarket>));
                serializer.Serialize(sw, Hipermarketlist);
            }
        }
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml*";

            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;
            }
            if (File.Exists(filename))
            {
                XmlFiletoList(filename);
            }
            else
            {
                MessageBox.Show(@"Such file doesn't exist");
            }
            }

        private void XmlFiletoList(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                var deserializer = new XmlSerializer(typeof(ObservableCollection<Hipermarket>));
                ObservableCollection<Hipermarket> tmplist = (ObservableCollection<Hipermarket>)deserializer.Deserialize(sr);
                foreach(var item in tmplist)
                {
                    Hipermarketlist.Add(item);
                }
            }
        }

        private void TypesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TypesCombobox.SelectedIndex)
            {
                case (int)Hipermarket.Types.Food:
                    this.SpecificationCombobox.ItemsSource = Enum.GetValues(typeof(Specification.Specification1));
                    this.SpecificationCombobox.SelectedIndex = 0; break;

               case (int)Hipermarket.Types.Drink:
                    this.SpecificationCombobox.ItemsSource = Enum.GetValues(typeof(Specification.Specification2));
                    this.SpecificationCombobox.SelectedIndex = 0; break;
                case (int)Hipermarket.Types.Stationery:
                    this.SpecificationCombobox.ItemsSource = Enum.GetValues(typeof(Specification.Specification3));
                    this.SpecificationCombobox.SelectedIndex = 0; break;
                case (int)Hipermarket.Types.RTV:
                    this.SpecificationCombobox.ItemsSource = Enum.GetValues(typeof(Specification.Specification4));
                    this.SpecificationCombobox.SelectedIndex = 0; break;
                case (int)Hipermarket.Types.AGD:
                    this.SpecificationCombobox.ItemsSource = Enum.GetValues(typeof(Specification.Specification5));
                    this.SpecificationCombobox.SelectedIndex = 0; break;

            }
        }

        private void SpecificationCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

