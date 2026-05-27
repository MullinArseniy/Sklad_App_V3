namespace Sklad_project_app
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Очищает поля при выходе
        /// </summary>
        public void ClearFields()
        {
            txtLogin.Text = "";
            txtPassword.Text = "";
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SkladContext())
                {
                    db.Database.CanConnect();
                    MessageBox.Show(AppResources.MsgConnectOk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(AppResources.MsgConnectError + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var login = txtLogin.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(AppResources.MsgConnectError);
                return;
            }

            using (var db = new SkladContext())
            {
                var allUsers = db.Users.Include("Role").ToList();
                User foundUser = null;


                foreach (var user in allUsers)
                {
                    var userLogin = "";
                    var userPassword = "";

                    if (user.Login != null)
                    {
                        userLogin = user.Login.Trim();
                    }
                    if (user.Password != null)
                    {
                        userPassword = user.Password.Trim();
                    }

                    if (userLogin == login && PasswordHasher.VerifyPassword(password, userPassword))
                    {
                        foundUser = user;
                        break;
                    }
                }

                if (foundUser == null)
                {
                    MessageBox.Show(AppResources.MsgWrongLogin);
                    var userExists = allUsers.Any(u => u.Login != null && u.Login.Trim() == login);
                    if (userExists)
                    {
                        Logger.Warn($"WARN-01: Неудачная попытка авторизации --- неверный пароль.\n" +
                                    $"Логин: {login}\n" +
                                    $"Время: {DateTime.Now}");
                    }
                    else
                    {
                        Logger.Warn($"WARN-02: Неудачная попытка авторизации --- логин не найден.\n" +
                                    $"Введённый логин: {login}\n" +
                                    $"Время: {DateTime.Now}");
                    }
                    return;
                }
                Logger.Debug($"DEBUG-01: Пользователь успешно авторизован.\n" +
                    $"Логин: {foundUser.Login} | Роль: {foundUser.Role.RoleName} | UserId: {foundUser.Id}\n" +
                    $"Время: {DateTime.Now}");
                CurrentUser.User = foundUser;
                CurrentUser.RoleName = foundUser.Role.RoleName;

                if (CurrentUser.IsAdmin)
                {
                    var adminForm = new AdminCatalogForm();
                    adminForm.Show();
                }
                else
                {
                    var storeForm = new StorekeeperCatalogForm();
                    storeForm.Show();
                }

                this.Hide();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var regForm = new RegisterForm();
            regForm.ShowDialog();
        }
    }
}