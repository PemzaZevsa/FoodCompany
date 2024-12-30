using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace FoodCompany.Models;

public partial class FoodCompanyContext : DbContext
{
    public FoodCompanyContext()
    {
    }

    public FoodCompanyContext(DbContextOptions<FoodCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Deliverystatus> Deliverystatuses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productorder> Productorders { get; set; }

    public virtual DbSet<Productsale> Productsales { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Salesnfo> Salesnfos { get; set; }

    public virtual DbSet<Timeinterval> Timeintervals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=food_company;user=root;password=rootroot", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.17-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.IdCategory)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_category");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasMany(d => d.IdProducts).WithMany(p => p.IdCategories)
                .UsingEntity<Dictionary<string, object>>(
                    "Productcategory",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcategory_ibfk_2"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcategory_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdCategory", "IdProduct")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("productcategory");
                        j.HasIndex(new[] { "IdProduct" }, "id_product");
                        j.IndexerProperty<uint>("IdCategory")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("id_category");
                        j.IndexerProperty<uint>("IdProduct")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("id_product");
                    });
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.Property(e => e.IdCustomer)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_customer");
            entity.Property(e => e.CustomerDiscount)
                .HasPrecision(10, 2)
                .HasColumnName("customer_discount");
            entity.Property(e => e.PurchaseSum)
                .HasPrecision(10, 2)
                .HasColumnName("purchase_sum");

            entity.HasOne(d => d.IdCustomerNavigation).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_ibfk_1");
        });

        modelBuilder.Entity<Deliverystatus>(entity =>
        {
            entity.HasKey(e => e.IdDeliveryStatus).HasName("PRIMARY");

            entity.ToTable("deliverystatus");

            entity.Property(e => e.IdDeliveryStatus)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_delivery_status");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.IdPosition, "id_position");

            entity.HasIndex(e => e.Login, "login_ix");

            entity.Property(e => e.IdEmployee)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_employee");
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("hire_date");
            entity.Property(e => e.IdPosition)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_position");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Salary)
                .HasPrecision(10, 2)
                .HasColumnName("salary");

            entity.HasOne(d => d.IdEmployeeNavigation).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_ibfk_1");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_ibfk_2");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IdIngredient).HasName("PRIMARY");

            entity.ToTable("ingredient");

            entity.Property(e => e.IdIngredient)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_ingredient");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.IdCustomer, "id_customer");

            entity.HasIndex(e => e.IdDeliveryStatus, "id_delivery_status");

            entity.HasIndex(e => e.IdEmployee, "id_employee");

            entity.Property(e => e.IdOrder)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_order");
            entity.Property(e => e.DeliveryStatusChange)
                .HasColumnType("datetime")
                .HasColumnName("delivery_status_change");
            entity.Property(e => e.FinalCost)
                .HasPrecision(10, 2)
                .HasColumnName("final_cost");
            entity.Property(e => e.IdCustomer)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_customer");
            entity.Property(e => e.IdDeliveryStatus)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_delivery_status");
            entity.Property(e => e.IdEmployee)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_employee");
            entity.Property(e => e.OrderCost)
                .HasPrecision(10, 2)
                .HasColumnName("order_cost");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchase_date");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_1");

            entity.HasOne(d => d.IdDeliveryStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdDeliveryStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_3");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_2");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("PRIMARY");

            entity.ToTable("person");

            entity.Property(e => e.IdPerson)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_person");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasColumnType("text")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("PRIMARY");

            entity.ToTable("position");

            entity.Property(e => e.IdPosition)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_position");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.IdSale, "id_sale");

            entity.Property(e => e.IdProduct)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_product");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.IdSale)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_sale");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Weight)
                .HasPrecision(10, 2)
                .HasColumnName("weight");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSale)
                .HasConstraintName("product_ibfk_1");

            entity.HasMany(d => d.IdIngredients).WithMany(p => p.IdProducts)
                .UsingEntity<Dictionary<string, object>>(
                    "Productingredient",
                    r => r.HasOne<Ingredient>().WithMany()
                        .HasForeignKey("IdIngredient")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productingredient_ibfk_3"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productingredient_ibfk_2"),
                    j =>
                    {
                        j.HasKey("IdProduct", "IdIngredient")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("productingredient");
                        j.HasIndex(new[] { "IdIngredient" }, "id_ingredient");
                        j.IndexerProperty<uint>("IdProduct")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("id_product");
                        j.IndexerProperty<uint>("IdIngredient")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("id_ingredient");
                    });
        });

        modelBuilder.Entity<Productorder>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdProduct })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("productorder");

            entity.HasIndex(e => e.IdProduct, "id_product");

            entity.HasIndex(e => e.IdSale, "id_sale");

            entity.Property(e => e.IdOrder)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_order");
            entity.Property(e => e.IdProduct)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_product");
            entity.Property(e => e.Amount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("amount");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.DiscountCost)
                .HasPrecision(10, 2)
                .HasColumnName("discount_cost");
            entity.Property(e => e.IdSale)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_sale");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Productorders)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productorder_ibfk_1");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Productorders)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productorder_ibfk_2");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.Productorders)
                .HasForeignKey(d => d.IdSale)
                .HasConstraintName("productorder_ibfk_3");
        });

        modelBuilder.Entity<Productsale>(entity =>
        {
            entity.HasKey(e => e.IdProductsale).HasName("PRIMARY");

            entity.ToTable("productsale");

            entity.HasIndex(e => e.IdProduct, "id_product");

            entity.HasIndex(e => e.IdSale, "id_sale");

            entity.Property(e => e.IdProductsale)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_productsale");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.IdProduct)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_product");
            entity.Property(e => e.IdSale)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_sale");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Productsales)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productsale_ibfk_1");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.Productsales)
                .HasForeignKey(d => d.IdSale)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productsale_ibfk_2");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.IdReport).HasName("PRIMARY");

            entity.ToTable("report");

            entity.HasIndex(e => e.IdTimeInterval, "id_time_interval");

            entity.Property(e => e.IdReport)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_report");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.IdTimeInterval)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_time_interval");
            entity.Property(e => e.PopularCategories)
                .HasMaxLength(765)
                .HasColumnName("popular_categories");
            entity.Property(e => e.PopularProducts)
                .HasMaxLength(765)
                .HasColumnName("popular_products");
            entity.Property(e => e.PopularProductsProfit)
                .HasPrecision(10, 2)
                .HasColumnName("popular_products_profit");
            entity.Property(e => e.PopularProductsProfitPercentage)
                .HasPrecision(6, 2)
                .HasColumnName("popular_products_profit_percentage");
            entity.Property(e => e.Profit)
                .HasPrecision(10, 2)
                .HasColumnName("profit");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.IdTimeIntervalNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdTimeInterval)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("report_ibfk_1");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("PRIMARY");

            entity.ToTable("sale");

            entity.Property(e => e.IdSale)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_sale");
            entity.Property(e => e.Discount)
                .HasPrecision(10, 2)
                .HasColumnName("discount");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Salesnfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("salesnfo");

            entity.Property(e => e.Amount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("amount");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.CustomerNameSurname)
                .HasMaxLength(201)
                .HasDefaultValueSql("''")
                .HasColumnName("customer_name_surname");
            entity.Property(e => e.Discount)
                .HasPrecision(10, 2)
                .HasColumnName("discount");
            entity.Property(e => e.EmployeeNameSurname)
                .HasMaxLength(201)
                .HasDefaultValueSql("''")
                .HasColumnName("employee_name_surname");
            entity.Property(e => e.FinalCost)
                .HasPrecision(10, 2)
                .HasColumnName("final_cost");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchase_date");
            entity.Property(e => e.SaleName)
                .HasMaxLength(255)
                .HasColumnName("sale_name");
            entity.Property(e => e.Weight)
                .HasPrecision(10, 2)
                .HasColumnName("weight");
        });

        modelBuilder.Entity<Timeinterval>(entity =>
        {
            entity.HasKey(e => e.IdTimeInterval).HasName("PRIMARY");

            entity.ToTable("timeinterval");

            entity.Property(e => e.IdTimeInterval)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_time_interval");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
