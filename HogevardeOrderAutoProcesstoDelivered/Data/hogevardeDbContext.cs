using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HogevardeOrderAutoProcesstoDelivered.Models;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Data
{
    public partial class hogevardeDbContext : DbContext
    {
        public hogevardeDbContext()
        {
        }

        public hogevardeDbContext(DbContextOptions<hogevardeDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-L8E5PL3\\SQLEXPRESS; Database=hogevardedb; Trusted_Connection=True; MultipleActiveResultSets=true;");
            }
        }

        public virtual DbSet<Activity> Activitys { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<CabinType> CabinTypes { get; set; }
        public virtual DbSet<CleaningOrder> CleaningOrders { get; set; }
        public virtual DbSet<CleaningOrderDetail> CleaningOrderDetails { get; set; }
        public virtual DbSet<CleaningOrderHistory> CleaningOrderHistorys { get; set; }
        public virtual DbSet<CleaningType> CleaningTypes { get; set; }
        public virtual DbSet<CleaningTypeArea> CleaningTypeAreas { get; set; }
        public virtual DbSet<DeviceInfo> DeviceInfos { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<FirewoodOrder> FirewoodOrders { get; set; }
        public virtual DbSet<FirewoodOrderDetail> FirewoodOrderDetails { get; set; }
        public virtual DbSet<FirewoodOrderHistory> FirewoodOrderHistorys { get; set; }
        public virtual DbSet<Help> Helps { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PaymentHistory> PaymentHistorys { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<SearchKey> SearchKeys { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<SnowPlowingOrder> SnowPlowingOrders { get; set; }
        public virtual DbSet<SnowPlowingOrderDetail> SnowPlowingOrderDetails { get; set; }
        public virtual DbSet<SnowPlowingOrderHistory> SnowPlowingOrderHistorys { get; set; }
        public virtual DbSet<SnowPlowingPayment> SnowPlowingPayments { get; set; }
        public virtual DbSet<TblAccessTokenRequest> TblAccessTokenRequests { get; set; }
        public virtual DbSet<TblApprovePayment> TblApprovePayments { get; set; }
        public virtual DbSet<TblCapturePayment> TblCapturePayments { get; set; }
        public virtual DbSet<TblInitiatePayment> TblInitiatePayments { get; set; }
        public virtual DbSet<TblOrderCancel> TblOrderCancels { get; set; }
        public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }
        public virtual DbSet<TblOrderStatus> TblOrderStatuses { get; set; }
        public virtual DbSet<TblPaymentCallBack> TblPaymentCallBacks { get; set; }
        public virtual DbSet<TblRefundPayment> TblRefundPayments { get; set; }
        public virtual DbSet<TempCabinDatum> TempCabinData { get; set; }
        public virtual DbSet<TestOrder> TestOrders { get; set; }
        public virtual DbSet<TestOrderDetail> TestOrderDetails { get; set; }
        public virtual DbSet<VoucherSetup> VoucherSetups { get; set; }
        public virtual DbSet<YearlyServiceFee> YearlyServiceFees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Charge).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 16)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 16)");
            });

            modelBuilder.Entity<CabinType>(entity =>
            {
                entity.Property(e => e.Charge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.YearlyFee).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CleaningOrder>(entity =>
            {
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CleaningOrderDetail>(entity =>
            {
                entity.Property(e => e.CleaningTypeAreaId).HasColumnName("CleaningTypeAreaID");

                entity.Property(e => e.CleaningTypeAreaPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CleaningTypeId).HasColumnName("CleaningTypeID");

                entity.Property(e => e.DeliveryCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DueAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<CleaningTypeArea>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasIndex(e => new { e.CreatedBy, e.ActivityId }, "IX_Favorites_CreatedBy_ActivityId")
                    .IsUnique()
                    .HasFilter("([CreatedBy] IS NOT NULL AND [ActivityId] IS NOT NULL)");

                entity.HasIndex(e => new { e.CreatedBy, e.ServiceId }, "IX_Favorites_CreatedBy_ServiceId")
                    .IsUnique()
                    .HasFilter("([CreatedBy] IS NOT NULL AND [ServiceId] IS NOT NULL)");
            });

            modelBuilder.Entity<FirewoodOrder>(entity =>
            {
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<FirewoodOrderDetail>(entity =>
            {
                entity.Property(e => e.DeliveryCharge).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DueAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.IsRead)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<PaymentHistory>(entity =>
            {
                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.Dob).HasColumnName("DOB");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.DeleveryLatitude).HasColumnType("decimal(18, 16)");

                entity.Property(e => e.DeleveryLongitude).HasColumnType("decimal(18, 16)");

                entity.Property(e => e.EmergencyDeleveryCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RegularDeleveryCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceCharge).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.Property(e => e.YearlyServiceFee).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SnowPlowingOrder>(entity =>
            {
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SnowPlowingOrderDetail>(entity =>
            {
                entity.Property(e => e.CabinCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmergencyDeleveryCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IsEmergencyDelevery)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.NeedDeliver)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ServiceCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SnowPlowingPayment>(entity =>
            {
                entity.HasIndex(e => new { e.OrderId, e.StartDate, e.EndDate }, "IX_SnowPlowingPayments_OrderId_StartDate_EndDate")
                    .IsUnique()
                    .HasFilter("([OrderId] IS NOT NULL)");

                entity.Property(e => e.PayAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblAccessTokenRequest>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tbl_AccessTokenRequest");

                entity.Property(e => e.TransId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTime).HasColumnType("datetime");

                entity.Property(e => e.RequestUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RequestURL");

                entity.Property(e => e.Response)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseTime).HasColumnType("datetime");

                entity.Property(e => e.TokenType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblApprovePayment>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tbl_ApprovePayment");

                entity.Property(e => e.TransId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.ApproveToken)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.RequestBody)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTime).HasColumnType("datetime");

                entity.Property(e => e.ResponseBody)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCapturePayment>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tbl_CapturePayment");

                entity.Property(e => e.TransId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CapturedAmount)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.RequestBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTime).HasColumnType("datetime");

                entity.Property(e => e.ResponseBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");
            });

            modelBuilder.Entity<TblInitiatePayment>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tbl_InitiatePayment");

                entity.Property(e => e.TransId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AuthToken)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.RequestBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTime).HasColumnType("datetime");

                entity.Property(e => e.ResponseBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Initiate')");
            });

            modelBuilder.Entity<TblOrderCancel>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tbl_OrderCancel");

                entity.Property(e => e.TransId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.RequestBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseTime).HasColumnType("datetime");

                entity.Property(e => e.ResquestTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");
            });

            modelBuilder.Entity<TblOrderDetail>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tbl_OrderDetails");

                entity.Property(e => e.TransId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.ResponseBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseTime).HasColumnType("datetime");

                entity.Property(e => e.ResquestTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");
            });

            modelBuilder.Entity<TblOrderStatus>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tbl_OrderStatus");

                entity.Property(e => e.TransId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.ResponseBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseTime).HasColumnType("datetime");

                entity.Property(e => e.ResquestTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");
            });

            modelBuilder.Entity<TblPaymentCallBack>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tbl_PaymentCallBack");

                entity.Property(e => e.TransId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAdressOne)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingCity)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingCost)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingCountry)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingMethod)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransTimeStamp)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserFirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.UserLastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserSsn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("UserSSN");
            });

            modelBuilder.Entity<TblRefundPayment>(entity =>
            {
                entity.HasKey(e => e.TransId);

                entity.ToTable("tbl_RefundPayment");

                entity.Property(e => e.TransId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TransID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CapturedAmount)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.RequestBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTime).HasColumnType("datetime");

                entity.Property(e => e.ResponseBody)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");
            });

            modelBuilder.Entity<TempCabinDatum>(entity =>
            {
                entity.Property(e => e.Bnr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cabintype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cabintype");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Felt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gnr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plot)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("plot");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<TestOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test_orders");

                entity.Property(e => e.CabinId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Month)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderFor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Session)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SessionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Week)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestOrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test_order_details");

                entity.Property(e => e.CabinType).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasMaxLength(255);

                entity.Property(e => e.CurrentStatus).HasMaxLength(255);

                entity.Property(e => e.DeliveryDate).HasMaxLength(255);

                entity.Property(e => e.Id).HasMaxLength(255);

                entity.Property(e => e.Issue).HasMaxLength(255);

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.OrderFor).HasMaxLength(255);

                entity.Property(e => e.OrderId).HasMaxLength(255);

                entity.Property(e => e.ServiceId).HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasMaxLength(255);
            });

            modelBuilder.Entity<YearlyServiceFee>(entity =>
            {
                entity.Property(e => e.PayAmount).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
