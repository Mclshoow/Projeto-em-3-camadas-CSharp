using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Dados
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;
        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetListAlunosAsync()
        {
            return await _context
                        .Aluno
                        .AsNoTracking()
                        .Include(a => a.Endereco)
                        .ToListAsync();
        }

        public async Task<Aluno> GetAlunoByIdAsync(int id)
        {
            return await _context
                        .Aluno
                        .AsNoTracking()
                        .Include(a => a.Endereco)
                        .FirstOrDefaultAsync(x => x.Matricula == id);
        }
        public async Task<Aluno> GetAlunoByNomeAsync(string nome)
        {
            return await _context
                        .Aluno
                        .AsNoTracking()
                        .Include(a => a.Endereco)
                        .Where(x => x.Nome == nome)
                        .FirstOrDefaultAsync();
        }
        public async Task<List<Aluno>> GetAlunoBySerieAsync(string serie)
        {
            return await _context
                        .Aluno
                        .AsNoTracking()
                        .Include(a => a.Endereco)
                        .Where(x => x.Serie == serie)
                        .ToListAsync();
        }

        public async Task<Aluno> PostAlunoAsync(Aluno aluno)
        {
            await _context
                .Aluno
                .AddAsync(aluno);

            await _context
                .SaveChangesAsync();

            return aluno;
        }

        public async Task<Aluno> PutAlunoAsync(Aluno aluno)
        {
            _context.Aluno.Update(aluno);

            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<Aluno> DeleteAlunoAsync(Aluno aluno)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                var enderecoDeletar = await _context.Endereco.Where(e => e.AlunoMatricula == aluno.Matricula).ToListAsync();

                if (enderecoDeletar.Any())
                {
                    _context.Endereco.RemoveRange(enderecoDeletar);

                    var enderecoExcluidos = await _context.SaveChangesAsync();

                    if (enderecoExcluidos != enderecoDeletar.Count)
                    {
                        throw new Exception("Erro ao excluir endereços associados ao aluno");
                    }
                }

                aluno.Endereco = new List<Endereco>();

                _context.Aluno.Remove(aluno);
                var alunoExcluido = await _context.SaveChangesAsync();

                if (alunoExcluido != 1)
                {
                    throw new Exception("Erro ao excluir aluno");
                }

                await transaction.CommitAsync();

                return aluno;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                Console.WriteLine("Erro: " + ex.Message);

                return null;
            }
        }
    }
}

