using System;

namespace ControleTarefa.Data.Entidades
{
    public class Atividade
    {
        public Guid ID { get; set; }
        public Guid TarefaID { get; set; }
        public Tarefa Tarefa { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
    }
}