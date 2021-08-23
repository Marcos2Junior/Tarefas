using System.Threading.Tasks;
using ControleTarefa.Data.Entidades;

namespace ControleTarefa.Servico.Interfaces
{
    public interface IAtividadeServico
    {
        /// <summary>
        /// Seleciona a atividade que ainda não possui final, ou seja, o usuario está executando essa atividade
        /// </summary>
        /// <returns></returns>
        Task<Atividade> SelecionaAtividadeAtualAsync();

        /// <summary>
        /// Cria uma nova atividade e já iniciar o contador para a tarefa passada por parametro
        /// </summary>
        /// <param name="tarefaID"></param>
        /// <returns></returns>
        Task<bool> IniciaAtividadeAsync(string tarefaID);

        /// <summary>
        /// define o fim da atividade atual
        /// </summary>
        /// <returns></returns>
        Task<bool> FinalizaAtividadeAtualAsync();
    }
}
