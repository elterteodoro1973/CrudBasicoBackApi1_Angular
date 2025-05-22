using BackEndAngular.DTO;
using BackEndAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAngular.Repository
{
    public class FuncionarioRepository
    {
        readonly CorporacaoContext Context;
        readonly ILogger<FuncionarioRepository> Logger;
        public FuncionarioRepository(CorporacaoContext context, ILogger<FuncionarioRepository> logger)
        {
            Context = context;
            Logger = logger;
        }

        public async Task<Funcionario> GetFuncionarioById(int id)
        {
            try
            {
                var funcionario = await Context.Funcionarios.FindAsync(id);
                if (funcionario == null)
                {
                    Logger.LogWarning($"Funcionario não localizado pelo Id:  {id}.");
                    return null;
                }
                return funcionario;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error ao tentar bucar funcionario com id: {id}");
                throw;
            }
        }

        public async Task<IEnumerable<Funcionario>> GetAllFuncionarios()
        {
            try
            {
                var funcionarios = await Context.Funcionarios.ToListAsync();
                return funcionarios;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao listar funcionarios");
                throw;
            }
        }

        public async Task<Funcionario> AddFuncionario(Funcionario funcionario)
        {
            try
            {
                funcionario.Ativo = true;
                Context.Funcionarios.Add(funcionario);
                await Context.SaveChangesAsync();
                return funcionario; // Fix: Return the correctly created Funcionario object
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao adicionar funcionario");
                throw;
            }
        }

        public async Task<Funcionario> UpdateFuncionario(int id, FuncionarioDTO funcionario)
        {
            try
            {
                var funcionarioOld = await GetFuncionarioById(id);

                if (funcionarioOld == null)
                {
                    Logger.LogWarning($"Funcionario não localizado pelo Id: {id}.");
                    throw new Exception($"Funcionario não localizado pelo Id: {id}.");
                }

                // Update the existing entity with new values                
                funcionarioOld.Nome = funcionario.Nome;
                funcionarioOld.Endereco = funcionario.Endereco;
                funcionarioOld.DataNascimento = funcionario.DataNascimento;
                funcionarioOld.Ativo = funcionario.Ativo;


                // Save changes to the database
                Context.Funcionarios.Update(funcionarioOld);
                await Context.SaveChangesAsync();

                return funcionarioOld;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao atualizar funcionario");
                throw;
            }
        }

        public async Task<bool> DeleteFuncionario(int id)
        {
            try
            {
                var funcionario = await Context.Funcionarios.FindAsync(id);
                if (funcionario == null)
                {
                    Logger.LogWarning($"Funcionario não localizado pelo Id:  {id}.");
                    throw new Exception($"Funcionario não localizado pelo Id: {id}.");                    
                }

                Context.Funcionarios.Remove(funcionario);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao deletar funcionario");
                throw;
            }
        }
    }

    
}
