using System;
using ControleTarefa.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ControleTarefa.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControleControleTarefa.App.Data.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly TarefasDataContext _context;

        public TarefaController(TarefasDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get")]
        public async Task<List<Tarefa>> Get()
        {
            return await _context.Tarefas.Include(x => x.Atividades).Include(x => x.Agendamentos).ToListAsync();
        }

        [HttpPost]
        [Route("create")]
        public async Task<bool> Create([FromBody] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.ID = Guid.NewGuid();
                tarefa.Finalizado = DateTime.MinValue;
                _context.Add(tarefa);
                try
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<Tarefa> Details(string id)
        {
            return await _context.Tarefas.Include(x => x.Agendamentos).Include(x => x.Atividades).FirstOrDefaultAsync(x => x.ID.ToString() == id);
        }

        [HttpPut]
        [Route("delete/{id}")]
        public async Task<bool> Edit(string id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.ID.ToString())
            {
                return false;
            }

            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> DeleteConfirmed(string id)
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.ID.ToString() == id);
            if (tarefa == null)
            {
                return false;
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
