using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ControleTarefa.Data.Entidades;

namespace ControleTarefa.Servico.Interfaces
{
    public interface ITarefaServico
    {
        Task<Tarefa> NovaTarefaAsync(Tarefa tarefa);
        Task<Tarefa> SelecionaTarefaAsync(string id);
        Task<List<Tarefa>> SelecionaTarefaFinalizadaPorDataAsync(DateTime inicio, DateTime final);
        Task<List<Tarefa>> SelecionaTarefasPendentesAsync();
    }
}
