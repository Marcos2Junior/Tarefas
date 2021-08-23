using System;

namespace ControleTarefa.Data.Entidades
{
    public class Agendamento
    {
        public Guid ID { get; set; }
        public Guid TarefaID { get; set; }
        public Tarefa Tarefa { get; set; }
        public string Observacao { get; set; }
        public DateTime DataAgendada { get; set; }
    }
}