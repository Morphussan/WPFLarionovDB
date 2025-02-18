using System.Linq;
using System.Windows;
using WpfApp2.DBmodel;

namespace WpfApp2
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using (var db = new ShopDBEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.Login == username && u.Pass == password);

                if (user != null)
                {
                    MessageBox.Show("НАШ СЛОНЯРА!!!!!!!!!!!");

                    ProductManagerWindow productManagerWindow = new ProductManagerWindow();
                    productManagerWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Хотел продукты добавлять? А вот нефиг всё забывать");
                }
            }
        }

        private void RegisterSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
