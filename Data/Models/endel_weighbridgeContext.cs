using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class endel_weighbridgeContext : DbContext
    {
        public endel_weighbridgeContext()
        {
        }

        public endel_weighbridgeContext(DbContextOptions<endel_weighbridgeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Applicationsetting> Applicationsettings { get; set; } = null!;
        public virtual DbSet<Barcodeimage> Barcodeimages { get; set; } = null!;
        public virtual DbSet<Barcodesetting> Barcodesettings { get; set; } = null!;
        public virtual DbSet<Camera> Cameras { get; set; } = null!;
        public virtual DbSet<Cameraimage> Cameraimages { get; set; } = null!;
        public virtual DbSet<Customfield> Customfields { get; set; } = null!;
        public virtual DbSet<Customvalue> Customvalues { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Emailsetup> Emailsetups { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<Gate> Gates { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Masterfield> Masterfields { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Smssetup> Smssetups { get; set; } = null!;
        public virtual DbSet<Stampcertificate> Stampcertificates { get; set; } = null!;
        public virtual DbSet<Template> Templates { get; set; } = null!;
        public virtual DbSet<Templatepermission> Templatepermissions { get; set; } = null!;
        public virtual DbSet<Transactiondatum> Transactiondata { get; set; } = null!;
        public virtual DbSet<Transactiondetail> Transactiondetails { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<Usermaster> Usermasters { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<Weighbridge> Weighbridges { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=192.168.1.253;database=endel_weighbridge;uid=sa;pwd=xc2H3PzxyB(D5oEZ", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountCode).HasMaxLength(50);

                entity.Property(e => e.AccountName).HasColumnType("text");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.City).HasMaxLength(45);

                entity.Property(e => e.ContactNo).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.Gstno)
                    .HasMaxLength(50)
                    .HasColumnName("GSTNO");

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.Pincode).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Applicationsetting>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PRIMARY");

                entity.ToTable("applicationsettings");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModuleName).HasMaxLength(100);

                entity.Property(e => e.SettingName).HasMaxLength(100);

                entity.Property(e => e.SettingType).HasMaxLength(50);

                entity.Property(e => e.SettingValue).HasMaxLength(8000);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Barcodeimage>(entity =>
            {
                entity.ToTable("barcodeimage");

                entity.Property(e => e.BarcodeImageId).HasColumnName("BarcodeImageID");

                entity.Property(e => e.BarcodeString).HasMaxLength(8000);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ImagePath).HasMaxLength(100);

                entity.Property(e => e.ReceiptTicketId).HasColumnName("ReceiptTicketID");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Barcodesetting>(entity =>
            {
                entity.ToTable("barcodesetting");

                entity.Property(e => e.BarcodeSettingId).HasColumnName("BarcodeSettingID");

                entity.Property(e => e.BarcodeDisplayName).HasMaxLength(50);

                entity.Property(e => e.BarcodeFieldName).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Camera>(entity =>
            {
                entity.ToTable("camera");

                entity.Property(e => e.CameraId).HasColumnName("CameraID");

                entity.Property(e => e.CameraName).HasMaxLength(100);

                entity.Property(e => e.CameraPassword).HasMaxLength(50);

                entity.Property(e => e.CameraType).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(20)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.Port).HasMaxLength(10);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.VideosourceUrl)
                    .HasMaxLength(200)
                    .HasColumnName("VideosourceURL");

                entity.Property(e => e.WeightBridgeId).HasColumnName("WeightBridgeID");
            });

            modelBuilder.Entity<Cameraimage>(entity =>
            {
                entity.ToTable("cameraimage");

                entity.HasIndex(e => e.CameraId, "CameraID");

                entity.HasIndex(e => e.TransactionDetailId, "TransactionDetailID");

                entity.Property(e => e.CameraImageId).HasColumnName("CameraImageID");

                entity.Property(e => e.CameraId).HasColumnName("CameraID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ImageLocation).HasMaxLength(500);

                entity.Property(e => e.TransactionDetailId).HasColumnName("TransactionDetailID");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Camera)
                    .WithMany(p => p.Cameraimages)
                    .HasForeignKey(d => d.CameraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cameraimage_ibfk_1");

                entity.HasOne(d => d.TransactionDetail)
                    .WithMany(p => p.Cameraimages)
                    .HasForeignKey(d => d.TransactionDetailId)
                    .HasConstraintName("cameraimage_ibfk_2");
            });

            modelBuilder.Entity<Customfield>(entity =>
            {
                entity.ToTable("customfield");

                entity.Property(e => e.CustomFieldId).HasColumnName("CustomFieldID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customvalue>(entity =>
            {
                entity.ToTable("customvalue");

                entity.Property(e => e.CustomValueId).HasColumnName("CustomValueID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.CustomFieldId).HasColumnName("CustomFieldID");

                entity.Property(e => e.CustomValue1)
                    .HasMaxLength(50)
                    .HasColumnName("CustomValue");

                entity.Property(e => e.ReceiptTicketId)
                    .HasMaxLength(50)
                    .HasColumnName("ReceiptTicketID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DriverName).HasMaxLength(250);

                entity.Property(e => e.IdproofNo)
                    .HasMaxLength(50)
                    .HasColumnName("IDProofNo");

                entity.Property(e => e.IdproofScan)
                    .HasMaxLength(300)
                    .HasColumnName("IDProofScan");

                entity.Property(e => e.IdproofType)
                    .HasMaxLength(50)
                    .HasColumnName("IDProofType");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.Photo).HasMaxLength(300);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Emailsetup>(entity =>
            {
                entity.ToTable("emailsetup");

                entity.Property(e => e.EmailSetupId).HasColumnName("EmailSetupID");

                entity.Property(e => e.ColumnSelection).HasColumnType("text");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.EmailBody).HasColumnType("text");

                entity.Property(e => e.EmailBodyEnding).HasColumnType("text");

                entity.Property(e => e.EmailSubject).HasColumnType("text");

                entity.Property(e => e.EmailTo).HasColumnType("text");

                entity.Property(e => e.EmailType).HasMaxLength(50);

                entity.Property(e => e.FilterDetail).HasColumnType("text");

                entity.Property(e => e.Filterstring).HasColumnType("text");

                entity.Property(e => e.NextRunTime).HasColumnType("datetime");

                entity.Property(e => e.ScheduleDescription).HasColumnType("text");

                entity.Property(e => e.ScheduleName).HasMaxLength(50);

                entity.Property(e => e.ScheduleTime).HasMaxLength(200);

                entity.Property(e => e.ScheduleType).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WhereClause).HasColumnType("text");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("feature");

                entity.Property(e => e.FeatureId).HasColumnName("FeatureID");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.FeatureName).HasMaxLength(50);

                entity.Property(e => e.ParentFeatureId).HasColumnName("ParentFeatureID");

                entity.Property(e => e.SortOrder).HasPrecision(9, 3);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Gate>(entity =>
            {
                entity.ToTable("gate");

                entity.Property(e => e.GateId).HasColumnName("GateID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.GateName).HasMaxLength(45);

                entity.Property(e => e.GateType).HasMaxLength(10);

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Exception).HasMaxLength(8000);

                entity.Property(e => e.Level).HasMaxLength(50);

                entity.Property(e => e.Logger).HasMaxLength(255);

                entity.Property(e => e.Message).HasMaxLength(4000);

                entity.Property(e => e.Thread).HasMaxLength(255);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Masterfield>(entity =>
            {
                entity.ToTable("masterfield");

                entity.Property(e => e.MasterFieldId).HasColumnName("MasterFieldID");

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.ProductCode).HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(250);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Smssetup>(entity =>
            {
                entity.ToTable("smssetup");

                entity.Property(e => e.SmssetupId)
                    .ValueGeneratedNever()
                    .HasColumnName("SMSSetupID");

                entity.Property(e => e.ColumnSelection).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.FilterDetail).HasMaxLength(50);

                entity.Property(e => e.Filterstring).HasMaxLength(50);

                entity.Property(e => e.NextRunTime).HasColumnType("datetime");

                entity.Property(e => e.ScheduleDescription).HasMaxLength(8000);

                entity.Property(e => e.ScheduleName).HasMaxLength(50);

                entity.Property(e => e.ScheduleTime).HasMaxLength(1000);

                entity.Property(e => e.ScheduleType).HasMaxLength(50);

                entity.Property(e => e.Smsbody)
                    .HasMaxLength(2000)
                    .HasColumnName("SMSBody");

                entity.Property(e => e.Smssubject)
                    .HasMaxLength(2000)
                    .HasColumnName("SMSSubject");

                entity.Property(e => e.Smsto)
                    .HasMaxLength(2000)
                    .HasColumnName("SMSTo");

                entity.Property(e => e.Smstype)
                    .HasMaxLength(50)
                    .HasColumnName("SMSType");

                entity.Property(e => e.Template).HasMaxLength(255);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WhereClause).HasMaxLength(50);
            });

            modelBuilder.Entity<Stampcertificate>(entity =>
            {
                entity.HasKey(e => e.StampId)
                    .HasName("PRIMARY");

                entity.ToTable("stampcertificate");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.IssuedAuth).HasMaxLength(100);

                entity.Property(e => e.StampName).HasMaxLength(100);

                entity.Property(e => e.StampPdf).HasMaxLength(4000);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("template");

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.TemplateName).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Templatepermission>(entity =>
            {
                entity.ToTable("templatepermission");

                entity.Property(e => e.TemplatePermissionId).HasColumnName("TemplatePermissionID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.FeatureId).HasColumnName("FeatureID");

                entity.Property(e => e.IsCreate).HasColumnName("isCreate");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.IsExecute).HasColumnName("isExecute");

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.Property(e => e.IsUpdate).HasColumnName("isUpdate");

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Transactiondatum>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PRIMARY");

                entity.ToTable("transactiondata");

                entity.HasIndex(e => e.DisplayTicketId, "DisplayTicketID")
                    .IsUnique();

                entity.HasIndex(e => e.ReceiptTicketId, "ReceiptTicketID")
                    .IsUnique();

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountName).HasMaxLength(50);

                entity.Property(e => e.Charges).HasPrecision(18, 2);

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DisplayTicketId).HasColumnName("DisplayTicketID");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.DriverName).HasMaxLength(50);

                entity.Property(e => e.FirstTime).HasColumnType("datetime");

                entity.Property(e => e.FirstWb)
                    .HasMaxLength(50)
                    .HasColumnName("FirstWB");

                entity.Property(e => e.FirstWeight).HasPrecision(18, 2);

                entity.Property(e => e.GrossWeight).HasPrecision(18, 2);

                entity.Property(e => e.Grosstime).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.ReceiptTicketId)
                    .HasMaxLength(100)
                    .HasColumnName("ReceiptTicketID");

                entity.Property(e => e.SecondTime).HasColumnType("datetime");

                entity.Property(e => e.SecondWb)
                    .HasMaxLength(50)
                    .HasColumnName("SecondWB");

                entity.Property(e => e.SecondWeight).HasPrecision(18, 2);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TareTime).HasColumnType("datetime");

                entity.Property(e => e.TareWeight).HasPrecision(18, 2);

                entity.Property(e => e.TransactionCreatedBy).HasMaxLength(50);

                entity.Property(e => e.TransactionMode).HasMaxLength(10);

                entity.Property(e => e.TransactionType).HasMaxLength(32);

                entity.Property(e => e.TransporterId).HasColumnName("TransporterID");

                entity.Property(e => e.TransporterName).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.VehicleNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Transactiondetail>(entity =>
            {
                entity.ToTable("transactiondetail");

                entity.Property(e => e.TransactionDetailId).HasColumnName("TransactionDetailID");

                entity.Property(e => e.CaptureTime).HasColumnType("datetime");

                entity.Property(e => e.CaptureWeight).HasPrecision(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.GateId).HasColumnName("GateID");

                entity.Property(e => e.GateName).HasMaxLength(50);

                entity.Property(e => e.GrossTime).HasColumnType("datetime");

                entity.Property(e => e.GrossWeight).HasPrecision(10);

                entity.Property(e => e.NetWeight).HasPrecision(10);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.ReceiptTicketId).HasColumnName("ReceiptTicketID");

                entity.Property(e => e.TareTime).HasColumnType("datetime");

                entity.Property(e => e.TareWeight).HasPrecision(10);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WeighmentType).HasMaxLength(32);

                entity.Property(e => e.WeightBridgeId).HasColumnName("WeightBridgeID");

                entity.Property(e => e.WeightBridgeName).HasMaxLength(50);

                entity.Property(e => e.WeightUnit).HasMaxLength(20);
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.HasKey(e => e.TransporterId)
                    .HasName("PRIMARY");

                entity.ToTable("transport");

                entity.Property(e => e.TransporterId).HasColumnName("TransporterID");

                entity.Property(e => e.Active).HasColumnType("bit(50)");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .HasColumnName("Company Name");

                entity.Property(e => e.ContactNo).HasColumnName("Contact No");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasMaxLength(50)
                    .HasColumnName("GSTNO");

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.Property(e => e.Pincode).HasMaxLength(50);

                entity.Property(e => e.TransporterCode).HasColumnName("Transporter Code");

                entity.Property(e => e.TransporterName)
                    .HasMaxLength(50)
                    .HasColumnName("Transporter Name");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("unit");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.UnitName).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Usermaster>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("usermaster");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CannotLoginUntilDate).HasColumnType("datetime");

                entity.Property(e => e.ContactNo).HasMaxLength(45);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(45);

                entity.Property(e => e.Notes).HasMaxLength(8000);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Salt).HasMaxLength(500);

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.MaxWeight).HasPrecision(18, 2);

                entity.Property(e => e.MinWeight).HasPrecision(18, 2);

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.TareTime).HasColumnType("datetime");

                entity.Property(e => e.TareWeight).HasPrecision(18, 4);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.VehicleNumber).HasMaxLength(50);

                entity.Property(e => e.VehicleType).HasMaxLength(50);
            });

            modelBuilder.Entity<Weighbridge>(entity =>
            {
                entity.ToTable("weighbridge");

                entity.Property(e => e.BaudRate).HasMaxLength(20);

                entity.Property(e => e.Comport)
                    .HasMaxLength(10)
                    .HasColumnName("COMPort");

                entity.Property(e => e.ConnectionType).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Format).HasMaxLength(50);

                entity.Property(e => e.Handshake).HasMaxLength(50);

                entity.Property(e => e.IncrementSize).HasMaxLength(50);

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(40)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.Ipport)
                    .HasMaxLength(10)
                    .HasColumnName("IPPort");

                entity.Property(e => e.MaxCapacity).HasMaxLength(50);

                entity.Property(e => e.Parity).HasMaxLength(10);

                entity.Property(e => e.ScaleName).HasMaxLength(250);

                entity.Property(e => e.StartStringChar).HasMaxLength(50);

                entity.Property(e => e.StopBits).HasMaxLength(50);

                entity.Property(e => e.StringStartingValue).HasMaxLength(50);

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WeightLength).HasMaxLength(45);

                entity.Property(e => e.WeightStartFrom).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
