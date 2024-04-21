using System.Threading.Tasks;
using Database.Models;
using Database.Utils;

namespace Business.Interfaces
{
    public interface IAlunoBusiness
    {
        public Task<OperationResult<Aluno>> GetListAlunosAsync();
        public Task<OperationResult<Aluno>> GetAlunoByIdAsync(int id);
        public Task<OperationResult<Aluno>> GetAlunoByNomeAsync(string nome);
        public Task<OperationResult<Aluno>> GetAlunoBySerieAsync(string serie);
        public Task<OperationResult<Aluno>> PostAlunoAsync(Aluno aluno);
        public Task<OperationResult<Aluno>> PutAlunoAsync(Aluno aluno);
        public Task<OperationResult<Aluno>> DeleteAlunoAsync(int id);
    }
}

