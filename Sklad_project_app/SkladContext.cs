namespace Sklad_project_app
{
    public class SkladContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<Supplies> Supplies { get; set; }
        public DbSet<SuppliesItem> SuppliesItems { get; set; }
        public DbSet<StockBatch> StockBatches { get; set; }
        public DbSet<WriteOff> WriteOffs { get; set; }
        public DbSet<Blacklist> Blacklist { get; set; }
        public DbSet<CityWeather> CitiesWeather { get; set; }

        public SkladContext() { }

        public SkladContext(DbContextOptions<SkladContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(DbConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //roles
            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<Role>().HasKey(role => role.Id);
            modelBuilder.Entity<Role>().Property(role => role.Id).HasColumnName("id");
            modelBuilder.Entity<Role>().Property(role => role.RoleName).HasColumnName("role");

            //users
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            modelBuilder.Entity<User>().Property(user => user.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(user => user.Name).HasColumnName("name");
            modelBuilder.Entity<User>().Property(user => user.Surname).HasColumnName("surname");
            modelBuilder.Entity<User>().Property(user => user.Patronymic).HasColumnName("patronymic");
            modelBuilder.Entity<User>().Property(user => user.Role_id).HasColumnName("role_id");
            modelBuilder.Entity<User>().Property(user => user.Login).HasColumnName("login");
            modelBuilder.Entity<User>().Property(user => user.Password).HasColumnName("password");
            modelBuilder.Entity<User>()
                .HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.Role_id);

            //categories
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().HasKey(category => category.Id);
            modelBuilder.Entity<Category>().Property(category => category.Id).HasColumnName("id");
            modelBuilder.Entity<Category>().Property(category => category.Name).HasColumnName("name");

            //units
            modelBuilder.Entity<Unit>().ToTable("units");
            modelBuilder.Entity<Unit>().HasKey(unit => unit.Id);
            modelBuilder.Entity<Unit>().Property(unit => unit.Id).HasColumnName("id");
            modelBuilder.Entity<Unit>().Property(unit => unit.Name).HasColumnName("name");

            //Products
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(product => product.Id);
            modelBuilder.Entity<Product>().Property(product => product.Id).HasColumnName("id");
            modelBuilder.Entity<Product>().Property(product => product.Article).HasColumnName("article");
            modelBuilder.Entity<Product>().Property(product => product.Name).HasColumnName("name");
            modelBuilder.Entity<Product>().Property(product => product.CategoryId).HasColumnName("category_id");
            modelBuilder.Entity<Product>().Property(product => product.UnitId).HasColumnName("unit_id");
            modelBuilder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId);
            modelBuilder.Entity<Product>()
                .HasOne(product => product.Unit)
                .WithMany(unit => unit.Products)
                .HasForeignKey(product => product.UnitId);

            //stock
            modelBuilder.Entity<Stock>().ToTable("stock");
            modelBuilder.Entity<Stock>().HasKey(stock => stock.Id);
            modelBuilder.Entity<Stock>().Property(stock => stock.Id).HasColumnName("id");
            modelBuilder.Entity<Stock>().Property(stock => stock.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<Stock>().Property(stock => stock.PurchasePrice).HasColumnName("purchase_price");
            modelBuilder.Entity<Stock>().Property(stock => stock.Rest).HasColumnName("rest");
            modelBuilder.Entity<Stock>()
                .HasOne(stock => stock.Product)
                .WithOne(product => product.Stock)
                .HasForeignKey<Stock>(stock => stock.ProductId);

            //clients
            modelBuilder.Entity<Client>().ToTable("clients");
            modelBuilder.Entity<Client>().HasKey(client => client.Id);
            modelBuilder.Entity<Client>().Property(client => client.Id).HasColumnName("id");
            modelBuilder.Entity<Client>().Property(client => client.Name).HasColumnName("name");

            //shipments
            modelBuilder.Entity<Shipment>().ToTable("shipments");
            modelBuilder.Entity<Shipment>().HasKey(shipment => shipment.Id);
            modelBuilder.Entity<Shipment>().Property(shipment => shipment.Id).HasColumnName("id");
            modelBuilder.Entity<Shipment>().Property(shipment => shipment.ClientId).HasColumnName("client_id");
            modelBuilder.Entity<Shipment>().Property(shipment => shipment.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Shipment>().Property(shipment => shipment.ShipmentDate).HasColumnName("shipment_date");
            modelBuilder.Entity<Shipment>()
                .HasOne(shipment => shipment.Client)
                .WithMany(client => client.Shipments)
                .HasForeignKey(shipment => shipment.ClientId);

            //shipment_items
            modelBuilder.Entity<ShipmentItem>().ToTable("shipment_items");
            modelBuilder.Entity<ShipmentItem>().HasKey(item => item.Id);
            modelBuilder.Entity<ShipmentItem>().Property(item => item.Id).HasColumnName("id");
            modelBuilder.Entity<ShipmentItem>().Property(item => item.ShipmentId).HasColumnName("shipment_id");
            modelBuilder.Entity<ShipmentItem>().Property(item => item.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<ShipmentItem>().Property(item => item.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<ShipmentItem>().Property(item => item.Amount).HasColumnName("amount");
            modelBuilder.Entity<ShipmentItem>()
                .HasOne(item => item.Shipment)
                .WithMany(shipment => shipment.ShipmentItems)
                .HasForeignKey(item => item.ShipmentId);
            modelBuilder.Entity<ShipmentItem>()
                .HasOne(item => item.Product)
                .WithMany()
                .HasForeignKey(item => item.ProductId);

            //supplies
            modelBuilder.Entity<Supplies>().ToTable("supplies");
            modelBuilder.Entity<Supplies>().HasKey(s => s.Id);
            modelBuilder.Entity<Supplies>().Property(s => s.Id).HasColumnName("id");
            modelBuilder.Entity<Supplies>().Property(s => s.SuppliesDate).HasColumnName("supply_date");
            modelBuilder.Entity<Supplies>().Property(s => s.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Supplies>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);
            //supplies_items
            modelBuilder.Entity<SuppliesItem>().ToTable("supplies_items");
            modelBuilder.Entity<SuppliesItem>().HasKey(item => item.Id);
            modelBuilder.Entity<SuppliesItem>().Property(item => item.Id).HasColumnName("id");
            modelBuilder.Entity<SuppliesItem>().Property(item => item.SuppliesId).HasColumnName("supplies_id");
            modelBuilder.Entity<SuppliesItem>().Property(item => item.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<SuppliesItem>().Property(item => item.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<SuppliesItem>().Property(item => item.PurchasePrice).HasColumnName("purchase_price");
            modelBuilder.Entity<SuppliesItem>()
                .HasOne(i => i.Supplies)
                .WithMany(s => s.SuppliesItems)
                .HasForeignKey(i => i.SuppliesId);
            modelBuilder.Entity<SuppliesItem>()
                .HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId);

            //StockBatch
            modelBuilder.Entity<StockBatch>().ToTable("stock_batches");
            modelBuilder.Entity<StockBatch>().HasKey(b => b.Id);
            modelBuilder.Entity<StockBatch>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<StockBatch>().Property(b => b.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<StockBatch>().Property(b => b.SuppliesId).HasColumnName("supplies_id");
            modelBuilder.Entity<StockBatch>().Property(b => b.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<StockBatch>().Property(b => b.PurchasePrice).HasColumnName("purchase_price");
            modelBuilder.Entity<StockBatch>().Property(b => b.ExpiryDate).HasColumnName("expiry_date");
            modelBuilder.Entity<StockBatch>().Property(b => b.DiscountPercent).HasColumnName("discount_percent");
            modelBuilder.Entity<StockBatch>().Property(b => b.IsWrittenOff).HasColumnName("is_written_off");
            modelBuilder.Entity<StockBatch>().Property(b => b.TotalDays).HasColumnName("total_days");

            modelBuilder.Entity<StockBatch>()
                .HasOne(b => b.Product)
                .WithMany()
                .HasForeignKey(b => b.ProductId);

            modelBuilder.Entity<StockBatch>()
                .HasOne(b => b.Supply)
                .WithMany()
                .HasForeignKey(b => b.SuppliesId);

            //WriteOffs
            modelBuilder.Entity<WriteOff>().ToTable("write_offs");
            modelBuilder.Entity<WriteOff>().HasKey(w => w.Id);
            modelBuilder.Entity<WriteOff>().Property(w => w.Id).HasColumnName("id");
            modelBuilder.Entity<WriteOff>().Property(w => w.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<WriteOff>().Property(w => w.BatchId).HasColumnName("batch_id");
            modelBuilder.Entity<WriteOff>().Property(w => w.WriteOffDate).HasColumnName("write_off_date");
            modelBuilder.Entity<WriteOff>().Property(w => w.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<WriteOff>().Property(w => w.LossAmount).HasColumnName("loss_amount");
            modelBuilder.Entity<WriteOff>().Property(w => w.Reason).HasColumnName("reason");

            modelBuilder.Entity<WriteOff>()
                .HasOne(w => w.Product)
                .WithMany()
                .HasForeignKey(w => w.ProductId);

            modelBuilder.Entity<WriteOff>()
                .HasOne(w => w.StockBatch)
                .WithMany()
                .HasForeignKey(w => w.BatchId);

            // Blacklist
            modelBuilder.Entity<Blacklist>().ToTable("blacklist");
            modelBuilder.Entity<Blacklist>().HasKey(b => b.Id);
            modelBuilder.Entity<Blacklist>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<Blacklist>().Property(b => b.Inn).HasColumnName("inn");
            modelBuilder.Entity<Blacklist>().Property(b => b.Name).HasColumnName("name");
            modelBuilder.Entity<Blacklist>().Property(b => b.Reason).HasColumnName("reason");
            modelBuilder.Entity<Blacklist>().Property(b => b.AddedDate).HasColumnName("added_date");

            // CitiesWeather
            modelBuilder.Entity<CityWeather>().ToTable("cities_weather");
            modelBuilder.Entity<CityWeather>().HasKey(c => c.Id);
            modelBuilder.Entity<CityWeather>().Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<CityWeather>().Property(c => c.CityName).HasColumnName("city_name");
            modelBuilder.Entity<CityWeather>().Property(c => c.Region).HasColumnName("region");
            modelBuilder.Entity<CityWeather>().Property(c => c.TemperatureMin).HasColumnName("temperature_min");
            modelBuilder.Entity<CityWeather>().Property(c => c.TemperatureMax).HasColumnName("temperature_max");
            modelBuilder.Entity<CityWeather>().Property(c => c.WeatherDescription).HasColumnName("weather_description");
            modelBuilder.Entity<CityWeather>().Property(c => c.UpdatedAt).HasColumnName("updated_at");

            base.OnModelCreating(modelBuilder);
        }
    }
}