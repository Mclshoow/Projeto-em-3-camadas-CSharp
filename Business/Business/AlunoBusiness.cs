using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Database.Interfaces;
using Database.Models;
using Database.Utils;

namespace Business.Business
{
    public class AlunoBusiness : IAlunoBusiness
    {
        string[] seriesG1AoG3 = { "G1", "G2", "G3" };
        string[] series1Ao5 = { "1", "2", "3", "4", "5" };
        string[] series6Ao9 = { "6", "7", "8", "9" };
        string[] series1Ao3Medio = { "1EM", "2EM", "3EM" };
        private readonly IAlunoRepository _repository;
        public AlunoBusiness(IAlunoRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<Aluno>> GetListAlunosAsync()
        {
            var result = new OperationResult<Aluno>();

            try
            {
                var alunos = await _repository.GetListAlunosAsync(); ;

                if (alunos.Count() <= 0)
                    throw new Exception("Lista de alunos não encontrada!");

                result.Success = true;
                result.Datas = alunos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar encontrar lista de alunos: {ex.Message}");

                result.Success = false;
                result.Message = $"Erro ao tentar encontrar lista de alunos: {ex.Message}";
            }

            return result;
        }
        public async Task<OperationResult<Aluno>> GetAlunoByIdAsync(int id)
        {
            var result = new OperationResult<Aluno>();

            try
            {
                var alunoId = await _repository.GetAlunoByIdAsync(id);

                if (alunoId == null)
                    throw new Exception("Id não encontrado!");

                result.Success = true;
                result.Data = alunoId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar encontrar por id: {ex.Message}");

                result.Success = false;
                result.Message = $"Erro ao tentar encontrar por id: {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult<Aluno>> GetAlunoByNomeAsync(string nome)
        {
            var result = new OperationResult<Aluno>();

            try
            {
                var alunoNome = await _repository.GetAlunoByNomeAsync(nome);

                if (alunoNome == null)
                    throw new Exception("Nome não encontrado!");

                result.Success = true;
                result.Data = alunoNome;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar encontrar por nome: {ex.Message}");

                result.Success = false;
                result.Message = $"Erro ao tentar encontrar por nome: {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult<Aluno>> GetAlunoBySerieAsync(string serie)
        {
            var result = new OperationResult<Aluno>();

            try
            {
                var alunosSerie = await _repository.GetAlunoBySerieAsync(serie);

                if (alunosSerie.Count() <= 0)
                    throw new Exception("Série não encontrada!");

                result.Success = true;
                result.Datas = alunosSerie;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar encontrar por série: {ex.Message}");

                result.Success = false;
                result.Message = $"Erro ao tentar encontrar por série: {ex.Message}";
            }

            return result;
        }
        public async Task<OperationResult<Aluno>> PostAlunoAsync(Aluno alunoAdicionar)
        {
            var result = new OperationResult<Aluno>();

            try
            {
                ValidarIdadeESegmentoAluno(alunoAdicionar);

                await _repository.PostAlunoAsync(alunoAdicionar);

                result.Success = true;
                result.Data = alunoAdicionar;
                result.Message = "Aluno adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar adicionar Aluno: {ex.Message}");

                result.Success = false;
                result.Message = $"Erro ao tentar adicionar Aluno: {ex.Message}";
            }

            return result;
        }
        public async Task<OperationResult<Aluno>> PutAlunoAsync(Aluno alunoEditar)
        {
            var result = new OperationResult<Aluno>();

            try
            {
                ValidarIdadeESegmentoAluno(alunoEditar);
                await _repository.PutAlunoAsync(alunoEditar);

                result.Success = true;
                result.Message = "Aluno atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar atualizar Aluno: {ex.Message}" + $"ID Aluno: {alunoEditar.Matricula}");

                result.Success = false;
                result.Message = $"Erro ao tentar atualizar Aluno: {ex.Message}";
            }

            return result;
        }
        public async Task<OperationResult<Aluno>> DeleteAlunoAsync(int id)
        {
            var result = new OperationResult<Aluno>();

            try
            {
                var alunoDeletar = await _repository.GetAlunoByIdAsync(id);

                if (alunoDeletar == null)
                    throw new Exception("Aluno não encontrado!");
                    
                await _repository.DeleteAlunoAsync(alunoDeletar);

                result.Success = true;
                result.Message = "Aluno deletado com sucesso!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar deletar Aluno: {ex.Message}" + $"ID Aluno: {id}");
                result.Success = false;
                result.Message = $"Erro ao tentar deletar Aluno: {ex.Message}";
            }
            return result;
        }

        private void ValidarIdadeESegmentoAluno(Aluno aluno)
        {
            int idade = DateTime.Today.Year - aluno.Data_Nascimento.Year;

            if (DateTime.Today < aluno.Data_Nascimento)
            {
                idade--;
            }

            if (idade < 3 || idade > 17)
            {
                throw new ValidationException("Idade fora da faixa esperada (3 a 17 anos).");
            }

            if (seriesG1AoG3.Any(s => aluno.Serie.Contains(s)))
            {
                if (idade < 3 || idade > 5)
                    throw new ValidationException("Idade inválida para as séries G1 a G3.");
                if (aluno.Segmento != "Infantil")
                    throw new ValidationException("Segmento incorreto para as séries G1 a G3 (deve ser 'Infantil').");
            }
            else if (series1Ao5.Any(s => aluno.Serie.Contains(s)))
            {
                if (idade < 6 || idade > 10)
                    throw new ValidationException("Idade inválida para as séries do 1º ao 5º ano.");
                if (aluno.Segmento != "Anos iniciais")
                    throw new ValidationException("Segmento incorreto para as séries do 1º ao 5º ano (deve ser 'Anos iniciais').");
            }
            else if (series6Ao9.Any(s => aluno.Serie.Contains(s)))
            {
                if (idade < 11 || idade > 14)
                    throw new ValidationException("Idade inválida para as séries do 6º ao 9º ano.");
                if (aluno.Segmento != "Anos finais")
                    throw new ValidationException("Segmento incorreto para as séries do 6º ao 9º ano (deve ser 'Anos finais').");
            }
            else if (series1Ao3Medio.Any(s => aluno.Serie.Contains(s)))
            {
                if (idade < 15 || idade > 17)
                    throw new ValidationException("Idade inválida para as séries do 1º ao 3º ano do ensino médio.");
                if (aluno.Segmento != "Ensino Médio")
                    throw new ValidationException("Segmento incorreto para as séries do 1º ao 3º ano do ensino médio (deve ser 'Ensino Médio').");
            }
            else
            {
                throw new ValidationException("Série inválida.");
            }
        }
    }
}
