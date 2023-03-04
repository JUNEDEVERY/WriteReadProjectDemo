using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WriteReadProjectDemo
{
    /// <summary>
    /// Логика взаимодействия для PageProducts.xaml
    /// </summary>
    public partial class PageProducts : Page
    {
        User user;
        Product product1 = new Product();
        public PageProducts(User user)
        {
            InitializeComponent();
            this.user = user;
            db.tbe = new Entities();
            lvProduct.ItemsSource = db.tbe.Product.ToList();

            tbNameUser.Text = user.FullName;
            
      
        }

        private void cmbSorted_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filtresMethod();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lvProduct_Loaded(object sender, RoutedEventArgs e)
        {
            //List<Product> product = db.tbe.Product.Where(x => x.ProductDiscountAmount > 15).ToList();
            //if (product1.ProductDiscountAmount > 15)
            //{
            //    SolidColorBrush solidColorBrush = new SolidColorBrush(Color.FromRgb(127, 255, 0));
            //    return solidColorBrush;
            //}
        }
        private void filtresMethod()
        {
            List<Product> products = db.tbe.Product.ToList();
            if(cmbSorted.SelectedItem != null)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)cmbSorted.SelectedItem;
                switch (comboBoxItem.Content)
                {
                     
                    case "По умолчанию":
                        {
                            products = products;
                            break;
                        }
                    case "По возрастанию стоимости":
                        {
                            products = products.OrderBy(x => x.ProductCost).ToList();
                            break;
                        }
                    case "По убыванию стоимости":
                        {

                            products = products.OrderByDescending(x => x.ProductCost).ToList();
                            break;
                        }
                }
             
              
            }
            lvProduct.ItemsSource = products;
        }
    }
}
