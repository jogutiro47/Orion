﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orion.API.Data;

namespace Orion.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211125204035_Nueva")]
    partial class Nueva
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Orion.API.Data.Entities.T_Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEstadoCitaId")
                        .HasColumnType("int");

                    b.Property<int>("Id_MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("Id_UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstadoCitaId");

                    b.HasIndex("Id_MedicoId");

                    b.HasIndex("Id_UsuarioId");

                    b.ToTable("t_Citas");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_EPS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescEPS")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("DescEPS")
                        .IsUnique()
                        .HasFilter("[DescEPS] IS NOT NULL");

                    b.ToTable("t_Eps");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_EstadoCita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc_EstadoCita")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Desc_EstadoCita")
                        .IsUnique();

                    b.ToTable("T_EstadoCitas");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_FuenteContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc_fuente_contacto")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Desc_fuente_contacto")
                        .IsUnique();

                    b.ToTable("t_FuenteContactos");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescGenero")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("DescGenero")
                        .IsUnique();

                    b.ToTable("T_Generos");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreMedico")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("NombreMedico")
                        .IsUnique();

                    b.ToTable("t_Medicos");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("DescripcionDocumento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DescripcionDocumento")
                        .IsUnique();

                    b.ToTable("T_TipoDocumentos");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_TipoVinculation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescTipoVinculacion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("DescTipoVinculacion")
                        .IsUnique();

                    b.ToTable("t_TipoVinculations");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Tratamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc_Tratamiento")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("Desc_Tratamiento")
                        .IsUnique();

                    b.ToTable("t_Tratamientos");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDocumentoId")
                        .HasColumnType("int");

                    b.Property<int?>("IdEpsId")
                        .HasColumnType("int");

                    b.Property<int>("IdFuenteContactoId")
                        .HasColumnType("int");

                    b.Property<int>("IdGeneroId")
                        .HasColumnType("int");

                    b.Property<int>("IdTratamientoId")
                        .HasColumnType("int");

                    b.Property<int?>("IdVinculacionId")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nro_Documento")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdDocumentoId");

                    b.HasIndex("IdEpsId");

                    b.HasIndex("IdFuenteContactoId");

                    b.HasIndex("IdGeneroId");

                    b.HasIndex("IdTratamientoId");

                    b.HasIndex("IdVinculacionId");

                    b.HasIndex("Nro_Documento")
                        .IsUnique();

                    b.ToTable("T_Usuarios");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Cita", b =>
                {
                    b.HasOne("Orion.API.Data.Entities.T_EstadoCita", "IdEstadoCita")
                        .WithMany("T_Citas")
                        .HasForeignKey("IdEstadoCitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orion.API.Data.Entities.T_Medico", "Id_Medico")
                        .WithMany("T_Citas")
                        .HasForeignKey("Id_MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orion.API.Data.Entities.T_Usuario", "Id_Usuario")
                        .WithMany("T_Citas")
                        .HasForeignKey("Id_UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Id_Medico");

                    b.Navigation("Id_Usuario");

                    b.Navigation("IdEstadoCita");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Usuario", b =>
                {
                    b.HasOne("Orion.API.Data.Entities.T_TipoDocumento", "IdDocumento")
                        .WithMany("T_Usuario")
                        .HasForeignKey("IdDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orion.API.Data.Entities.T_EPS", "IdEps")
                        .WithMany("T_Usuario")
                        .HasForeignKey("IdEpsId");

                    b.HasOne("Orion.API.Data.Entities.T_FuenteContacto", "IdFuenteContacto")
                        .WithMany("T_Usuario")
                        .HasForeignKey("IdFuenteContactoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orion.API.Data.Entities.T_Genero", "IdGenero")
                        .WithMany("T_Usuario")
                        .HasForeignKey("IdGeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orion.API.Data.Entities.T_Tratamiento", "IdTratamiento")
                        .WithMany("T_Usuario")
                        .HasForeignKey("IdTratamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Orion.API.Data.Entities.T_TipoVinculation", "IdVinculacion")
                        .WithMany("T_Usuario")
                        .HasForeignKey("IdVinculacionId");

                    b.Navigation("IdDocumento");

                    b.Navigation("IdEps");

                    b.Navigation("IdFuenteContacto");

                    b.Navigation("IdGenero");

                    b.Navigation("IdTratamiento");

                    b.Navigation("IdVinculacion");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_EPS", b =>
                {
                    b.Navigation("T_Usuario");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_EstadoCita", b =>
                {
                    b.Navigation("T_Citas");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_FuenteContacto", b =>
                {
                    b.Navigation("T_Usuario");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Genero", b =>
                {
                    b.Navigation("T_Usuario");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Medico", b =>
                {
                    b.Navigation("T_Citas");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_TipoDocumento", b =>
                {
                    b.Navigation("T_Usuario");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_TipoVinculation", b =>
                {
                    b.Navigation("T_Usuario");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Tratamiento", b =>
                {
                    b.Navigation("T_Usuario");
                });

            modelBuilder.Entity("Orion.API.Data.Entities.T_Usuario", b =>
                {
                    b.Navigation("T_Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
