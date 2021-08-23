using System;
using System.Collections.Generic;

namespace ControleTarefa.Data.Entidades
{
    public class Tarefa
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Finalizado { get; set; }
        public List<Atividade> Atividades { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
    }
}
