using GestorDePaciente.Core.Domain.Entities.Lab;
using GestorDePaciente.Core.Domain.Entities.Login;
using GestorDePaciente.Core.Domain.Entities.Office;
using GestorDePaciente.Core.Domain.Entities.Role;
using Microsoft.EntityFrameworkCore;

namespace GestorDePaciente.Infrastructure.Persistence.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    
    // Models
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorOffice> DoctorOffices { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<LabTests> LabTests { get; set; }
    public DbSet<ResultLabTest> ResultLabTests { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        // Creating tables
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<Doctor>().ToTable("Doctors");
        modelBuilder.Entity<DoctorOffice>().ToTable("DoctorOffices");
        modelBuilder.Entity<Patient>().ToTable("Patients");
        modelBuilder.Entity<Appointment>().ToTable("Appointments");
        modelBuilder.Entity<LabTests>().ToTable("LabTests");
        modelBuilder.Entity<ResultLabTest>().ToTable("ResultLabTests");
        
        // Primary keys
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Role>().HasKey(r => r.Id);
        modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
        modelBuilder.Entity<DoctorOffice>().HasKey(o => o.Id);
        modelBuilder.Entity<Patient>().HasKey(p => p.Id);
        modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
        modelBuilder.Entity<LabTests>().HasKey(lt => lt.Id);
        modelBuilder.Entity<ResultLabTest>().HasKey(rlt => rlt.Id);
        
        // Creating relationships
        modelBuilder.Entity<User>()
            .HasOne<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasOne<DoctorOffice>(u => u.DoctorOffice)
            .WithMany(o => o.Users)
            .HasForeignKey(u => u.DoctorOfficeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Doctor>()
            .HasOne<DoctorOffice>(d => d.DoctorOffice)
            .WithMany(o => o.Doctors)
            .HasForeignKey(d => d.IdDoctorOffice)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Patient>()
            .HasOne<DoctorOffice>(p => p.DoctorOffice)
            .WithMany(o => o.Patients)
            .HasForeignKey(p => p.IdDoctorOffice)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne<Patient>(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
            .HasOne<DoctorOffice>(a => a.DoctorOffice)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorOfficeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Appointment>()
            .HasOne<Doctor>(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.IdDoctor)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<LabTests>()
            .HasOne<DoctorOffice>(lt => lt.DoctorOffice)
            .WithMany(o => o.LabTests)
            .HasForeignKey(lt => lt.IdDoctorOffice)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<LabTests>()
            .HasOne<Patient>(lt => lt.Patient)
            .WithMany(p => p.LabTests)
            .HasForeignKey(lt => lt.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ResultLabTest>()
            .HasOne<LabTests>(rlt => rlt.LabTest)
            .WithMany(lt => lt.ResultLabTests)
            .HasForeignKey(rlt => rlt.IdLabTest)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ResultLabTest>()
            .HasOne<Patient>(rlt => rlt.Patient)
            .WithMany(p => p.ResultLabTests)
            .HasForeignKey(rlt => rlt.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        // Configuring properties
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<User>()
            .Property(u => u.RoleId)
            .HasDefaultValue(1)
            .IsRequired();
            
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Role>()
            .Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Role>()
            .Property(r => r.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Doctor>()
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        modelBuilder.Entity<Doctor>()
            .Property(d => d.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Doctor>()
            .Property(d => d.UrlProfilePicture)
            .HasDefaultValue("");

        modelBuilder.Entity<DoctorOffice>()
            .Property(o => o.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<DoctorOffice>()
            .Property(o => o.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Patient>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        modelBuilder.Entity<Patient>()
            .Property(d => d.UrlProfilePicture)
            .HasDefaultValue("");
        
        modelBuilder.Entity<Patient>()
            .Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<LabTests>()
            .Property(lt => lt.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<LabTests>()
            .Property(lts => lts.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<ResultLabTest>()
            .Property(rlt => rlt.Result)
            .IsRequired()
            .HasMaxLength(1000);
            
        modelBuilder.Entity<ResultLabTest>()
            .Property(rlt => rlt.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        // Seeding data
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Administrador" },
            new Role { Id = 2, Name = "Asistente" }
        );
        
        modelBuilder.Entity<DoctorOffice>().HasData(
            new DoctorOffice { Id = 1, Name = "Consultorio 1", Address = "Calle 1" },
            new DoctorOffice { Id = 2, Name = "Consultorio 2", Address = "Calle 2" },
            new DoctorOffice { Id = 3, Name = "Consultorio 3", Address = "Calle 3" },
            new DoctorOffice { Id = 4, Name = "Consultorio 4", Address = "Calle 4" }
        );
    }
    
}