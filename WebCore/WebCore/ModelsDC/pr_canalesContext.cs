using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebCore.ModelsDC
{
    public partial class pr_canalesContext : DbContext
    {
        public pr_canalesContext()
        {
        }

        public pr_canalesContext(DbContextOptions<pr_canalesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentsEmployee> DepartmentsEmployees { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Enterprise> Enterprises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.DescriptionDep)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description_dep");

                entity.Property(e => e.IdEnterprise).HasColumnName("id_enterprise");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.NameDep)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_dep");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.StatusDep).HasColumnName("status_dep");

                entity.HasOne(d => d.IdEnterpriseNavigation)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.IdEnterprise)
                    .HasConstraintName("FK__departmen__id_en__1DEB03DA");
            });

            modelBuilder.Entity<DepartmentsEmployee>(entity =>
            {
                entity.ToTable("departments_employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.IdDepartment).HasColumnName("id_department");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.StatusDep).HasColumnName("status_dep");

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.DepartmentsEmployees)
                    .HasForeignKey(d => d.IdDepartment)
                    .HasConstraintName("FK__departmen__id_de__21BB94BE");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.DepartmentsEmployees)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__departmen__id_em__20C77085");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.NameEmp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_emp");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.StatusEmp).HasColumnName("status_emp");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Enterprise>(entity =>
            {
                entity.ToTable("enterprises");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressEnt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address_ent");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.NameEnt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_ent");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.StatusEnt).HasColumnName("status_ent");
            });

            modelBuilder.HasSequence("seq_ca_cuenta_cobro_dispositivo");

            modelBuilder.HasSequence("seq_ca_cuenta_cobro_dispositivo_his");

            modelBuilder.HasSequence("seq_ca_datos_cobro_dispositivo_tc");

            modelBuilder.HasSequence<int>("seq_ca_ti_beneficiario_local").StartsAt(1000);

            modelBuilder.HasSequence("seq_om_api_log_auditoria");

            modelBuilder.HasSequence("seq_om_api_pagos");

            modelBuilder.HasSequence("seq_om_api_propiedad_transaccion_segura");

            modelBuilder.HasSequence("seq_om_api_transaccion_segura");

            modelBuilder.HasSequence("seq_tmp_datos_cobro_dispositivo");

            modelBuilder.HasSequence("seq_tmp_datos_para_devolucion");

            modelBuilder.HasSequence("sq_ca_beneficiario_cuenta_bimo");

            modelBuilder.HasSequence("sq_ca_monedero_control_parametro");

            modelBuilder.HasSequence("sq_ca_monedero_cuenta");

            modelBuilder.HasSequence("sq_ca_monedero_tranferencias");

            modelBuilder.HasSequence("sq_ca_orden_retiro_bimo");

            modelBuilder.HasSequence("sq_om_historico_transaccion")
                .StartsAt(426134)
                .IsCyclic();
        }
    }
}
