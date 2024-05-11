using BaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        // General Department / Department / Section
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Section> Sections { get; set; }

        // Country / City / State
        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        // Authentication / Role / User Role / Refresh Token
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }

        // Other Tables: Vacation, Overtime, Doctor
        public DbSet<Vacation> Vacations { get; set; }

        public DbSet<VacationType> VacationTypes { get; set; }

        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<OvertimeType> OvertimeTypes { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
    }
}