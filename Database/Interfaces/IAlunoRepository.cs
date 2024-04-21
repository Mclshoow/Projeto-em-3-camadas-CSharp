using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Models;

namespace Database.Interfaces
{
    public interface IAlunoRepository
    {
        public Task<List<Aluno>> GetListAlunosAsync();
        public Task<Aluno> GetAlunoByIdAsync(int id);
        public Task<Aluno> GetAlunoByNomeAsync(string nome);
        public Task<List<Aluno>> GetAlunoBySerieAsync(string serie);
        public Task<Aluno> PostAlunoAsync(Aluno aluno);
        public Task<Aluno> PutAlunoAsync(Aluno aluno);
        public Task<Aluno> DeleteAlunoAsync(Aluno aluno);
    }
}

