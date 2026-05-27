namespace Sklad_project_app
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked)
            {
                chkStorekeeper.Checked = false;
            }
        }

        private void chkStorekeeper_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStorekeeper.Checked)
            {
                chkAdmin.Checked = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var fio = txtFio.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(AppResources.MsgWrongLogin);
                return;
            }

            if (!chkAdmin.Checked && !chkStorekeeper.Checked)
            {
                MessageBox.Show(AppResources.MsgSelectRole);
                return;
            }

            var parts = fio.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var surname = "";
            var name = "";
            var patronymic = "";

            if (parts.Length > 0)
            {
                surname = parts[0];
            }
            if (parts.Length > 1)
            {
                name = parts[1];
            }
            if (parts.Length > 2)
            {
                patronymic = parts[2];
            }

            using (var db = new SkladContext())
            {
                var allUsers = db.Users.ToList();
                foreach (var u in allUsers)
                {
                    var userLogin = "";
                    if (u.Login != null)
                    {
                        userLogin = u.Login.Trim();
                    }

                    if (userLogin == fio)
                    {
                        // WARN-07: Попытка регистрации с уже существующим логином
                        Logger.Warn($"WARN-07: Попытка регистрации с уже существующим логином.\n" +
                                    $"Введённый логин: {fio}\n" +
                                    $"Время: {DateTime.Now}");
                        MessageBox.Show(AppResources.MsgUserExists);
                        return;
                    }
                }

                var roleName = "";
                if (chkAdmin.Checked)
                {
                    roleName = AppResources.RegisterAdmin;
                }
                else
                {
                    roleName = AppResources.RegisterStorekeeper;
                }

                var allRoles = db.Roles.ToList();
                Role foundRole = null;

                foreach (var role in allRoles)
                {
                    if (role.RoleName == roleName)
                    {
                        foundRole = role;
                        break;
                    }
                }

                if (foundRole == null)
                {
                    MessageBox.Show(AppResources.RegisterStorekeeper);
                    return;
                }

                var hashedPassword = PasswordHasher.HashPassword(password);

                var newUser = new User
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Login = fio,
                    Password = hashedPassword,
                    Role_id = foundRole.Id
                };

                try
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    Logger.Debug($"DEBUG-02: Новый пользователь зарегистрирован.\n" +
                            $"Логин: {fio} | ФИО: {surname} {name} {patronymic}\n" +
                            $"Роль: {roleName} | UserId: {newUser.Id}\n" +
                            $"Время: {DateTime.Now}");
                    MessageBox.Show(AppResources.MsgRegSuccess + fio);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(AppResources.MsgSaveError + ex.Message);
                }
            }
        }
    }
}