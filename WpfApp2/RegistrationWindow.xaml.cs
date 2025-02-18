using System.Linq;
using System.Windows;
using WpfApp2.DBmodel; // Привязка к EF-модели

namespace WpfApp2
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            using (var db = new ShopDBEntities())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Login == username);
                if (existingUser != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.");
                    return;
                }

                Users newUser = new Users
                {
                    Login = username,
                    Pass = password
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }

            MessageBox.Show("Пользователь успешно зарегистрирован!");

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void SwitchToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
