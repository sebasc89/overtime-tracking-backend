using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistecredito.OvertimeTracking.Core.Entities;
using Sistecredito.OvertimeTracking.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OvertimeRequest> OvertimeRequests { get; set; }
        public DbSet<PayrollReport> PayrollReports { get; set; }
        public DbSet<LeaderArea> LeaderAreas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure and Map Entities

            base.OnModelCreating(modelBuilder);

            // Configure primary keys
            modelBuilder.Entity<Area>()
            .HasKey(a => a.AreaId);

            modelBuilder.Entity<Position>()
                .HasKey(p => p.PositionId);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<OvertimeRequest>()
            .HasKey(o => o.RequestId);

            modelBuilder.Entity<OvertimeRequest>()
             .Property(o => o.OvertimeHours)
             .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ApprovalStatus>()
            .HasKey(a => a.StatusId);

            modelBuilder.Entity<PayrollReport>()
            .HasKey(a => a.ReportId);

            modelBuilder.Entity<PayrollReport>()
             .Property(o => o.OverTimeConceptValue)
             .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<LeaderArea>()
            .HasKey(la => la.Id);

            // Configure relationships 
            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Area)
            .WithMany()
            .HasForeignKey(e => e.AreaId);

            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Leader)
            .WithMany()
            .HasForeignKey(e => e.LeaderId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<Employee>()
            .HasOne(e => e.ApplicationUser)
            .WithOne()
            .HasForeignKey<Employee>(e => e.ApplicationUserId);

            modelBuilder.Entity<OvertimeRequest>()
           .HasOne(o => o.Employee)
           .WithMany()
           .HasForeignKey(o => o.EmployeeId);

            modelBuilder.Entity<OvertimeRequest>()
                .HasOne(o => o.ApprovalStatus)
                .WithMany()
                .HasForeignKey(o => o.ApprovalStatusId);

            modelBuilder.Entity<PayrollReport>()
            .HasOne(o => o.Employee)
            .WithMany()
            .HasForeignKey(o => o.EmployeeId);

            modelBuilder.Entity<LeaderArea>()
            .HasOne(la => la.Leader)
            .WithMany()
            .HasForeignKey(la => la.LeaderId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaderArea>()
                .HasOne(la => la.Area)
                .WithMany()
                .HasForeignKey(la => la.AreaId);
        }
    }
}
