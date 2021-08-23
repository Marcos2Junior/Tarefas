using ControleTarefa.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefa.Data
{
    public class TarefasDataContext : DbContext
    {
        public TarefasDataContext(DbContextOptions<TarefasDataContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
