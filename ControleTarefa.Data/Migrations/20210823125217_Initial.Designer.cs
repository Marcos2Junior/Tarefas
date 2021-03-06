// <auto-generated />
using System;
using ControleTarefa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleTarefa.Data.Migrations
{
    [DbContext(typeof(TarefasDataContext))]
    [Migration("20210823125217_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControleTarefa.Data.Entidades.Agendamento", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataAgendada")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Observacao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("TarefaID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("TarefaID");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("ControleTarefa.Data.Entidades.Atividade", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Final")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("TarefaID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("TarefaID");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("ControleTarefa.Data.Entidades.Tarefa", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Finalizado")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("ControleTarefa.Data.Entidades.Agendamento", b =>
                {
                    b.HasOne("ControleTarefa.Data.Entidades.Tarefa", "Tarefa")
                        .WithMany("Agendamentos")
                        .HasForeignKey("TarefaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ControleTarefa.Data.Entidades.Atividade", b =>
                {
                    b.HasOne("ControleTarefa.Data.Entidades.Tarefa", "Tarefa")
                        .WithMany("Atividades")
                        .HasForeignKey("TarefaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
