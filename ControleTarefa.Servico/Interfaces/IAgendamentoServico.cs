using System.Threading.Tasks;
using System.Collections.Generic;
using ControleTarefa.Data.Entidades;

namespace ControleTarefa.Servico.Interfaces
{
    public interface IAgendamentoServico
    {
        Task<Agendamento> SelecionaProximoAgendamentoAsync();
        Task<List<Agendamento>> SelecionaAgendamentosAtrasadosAsync();

        /// <summary>
        /// Define um novo agendamento para a tarefa
        /// 
        /// possivel criar quantos agendamentos quiser para a mesma tarefa, porém apenas o ultimo será válido
        /// os anteriores irá servir apenas para exibir a quantidade de vezes que uma tarefa foi reagendada
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        Task<bool> NovoAgendamentoAsync(Agendamento agendamento);
    }
}
