namespace Sklad_project_app
{
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            using (var db = new SkladContext())
            {
                var categories = db.Categories.ToList();
                lstCategories.Items.Clear();
                foreach (var category in categories)
                {
                    lstCategories.Items.Add(category.Name);
                }
            }
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            var name = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(AppResources.MsgFillFields);
                return;
            }

            using (var db = new SkladContext())
            {
                var existing = db.Categories
                    .Where(category => category.Name == name)
                    .FirstOrDefault();

                if (existing != null)
                {
                    MessageBox.Show(AppResources.MsgCategoryExists);
                    return;
                }

                var newCategory = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = name
                };

                try
                {
                    db.Categories.Add(newCategory);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(AppResources.MsgSaveError + ex.Message);
                    return;
                }
            }

            txtCategoryName.Text = "";
            LoadCategories();
        }

        private void btnEditCat_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedIndex < 0)
            {
                MessageBox.Show(AppResources.MsgSelectProduct);
                return;
            }

            var oldName = lstCategories.SelectedItem.ToString();
            var newName = txtCategoryName.Text.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show(AppResources.MsgFillFields);
                return;
            }

            using (var db = new SkladContext())
            {
                var foundCategory = db.Categories
                    .Where(category => category.Name == oldName)
                    .FirstOrDefault();

                if (foundCategory == null)
                {
                    return;
                }

                foundCategory.Name = newName;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(AppResources.MsgSaveError + ex.Message);
                    return;
                }
            }

            txtCategoryName.Text = "";
            LoadCategories();
        }

        private void btnDeleteCat_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedIndex < 0)
            {
                MessageBox.Show(AppResources.MsgSelectProduct);
                return;
            }

            var categoryName = lstCategories.SelectedItem.ToString();

            var result = MessageBox.Show(
                AppResources.MsgDeleteConfirm,
                AppResources.MsgDeleteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            using (var db = new SkladContext())
            {
                try
                {
                    var foundCategory = db.Categories
                        .Where(category => category.Name == categoryName)
                        .FirstOrDefault();

                    if (foundCategory == null)
                    {
                        return;
                    }
                    var hasProducts = db.Products
                        .Where(product => product.CategoryId == foundCategory.Id)
                        .Any();

                    if (hasProducts)
                    {
                        //WARN-08 — Попытка удалить категорию с привязанными товарами 
                        int productCount = db.Products.Count(p => p.CategoryId == foundCategory.Id);

                        Logger.Warn($"WARN-08: Попытка удалить категорию, содержащую товары.\n" +
                                    $"Пользователь: {CurrentUser.User?.Login}\n" +
                                    $"CategoryId: {foundCategory.Id} | Название: {foundCategory.Name}\n" +
                                    $"Количество товаров в категории: {productCount}\n" +
                                    $"Операция отменена.");
                        MessageBox.Show(AppResources.MsgCategoryHasProducts);
                        return;
                    }

                    try
                    {
                        db.Categories.Remove(foundCategory);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(AppResources.MsgSaveError + ex.Message);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"ERROR-10: Не удалось удалить категорию.\n" +
                                 $"Пользователь: {CurrentUser.User?.Login}\n" +
                                 $"Категория: {categoryName}\n" +
                                 $"Исключение: {ex.GetType()} --- {ex.Message}\n" +
                                 $"Стек: {ex.StackTrace}", ex);
                    MessageBox.Show(AppResources.MsgSaveError + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            LoadCategories();
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategories.SelectedIndex >= 0)
            {
                txtCategoryName.Text = lstCategories.SelectedItem.ToString();
            }
        }
    }
}