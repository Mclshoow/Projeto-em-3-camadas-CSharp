using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Business;
using Database.Interfaces;
using Database.Models;
using Moq;
using Xunit;

namespace AlunoTests
{
    public class AlunoTests
    {
        [Fact]
        public async Task GetListAlunosAsync_ListaEncontrada()
        {
            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .GetListAlunosAsync())
                        .ReturnsAsync(new List<Aluno>
                            {
                                new Aluno
                                {
                                    Matricula = 1,
                                    Nome = "Aluno1",
                                    Data_Nascimento = new DateTime(2017, 4, 9),
                                    Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                                    Serie = "G1",
                                    Segmento = "Infantil",
                                    Nome_Pai = "Pai do Aluno1",
                                    Nome_Mae = "Mãe do Aluno1"
                                }
                            }
                        );

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.GetListAlunosAsync();

            // Assert
            Assert.True(result.Success);
            Assert.NotEmpty(result.Datas);
        }

        [Fact]
        public async Task GetListAlunosAsync_ListaNaoEncontrada()
        {
            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .GetListAlunosAsync())
                        .ReturnsAsync(new List<Aluno>());

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.GetListAlunosAsync();

            // Assert
            Assert.False(result.Success);
            Assert.Null(result.Datas);
        }

        [Fact]
        public async Task GetAlunoByIdAsync_AlunoPorIdEncontrado()
        {
            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .GetAlunoByIdAsync(1))
                        .ReturnsAsync(
                                new Aluno
                                {
                                    Matricula = 1,
                                    Nome = "Aluno1",
                                    Data_Nascimento = new DateTime(2017, 4, 9),
                                    Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                                    Serie = "G1",
                                    Segmento = "Infantil",
                                    Nome_Pai = "Pai do Aluno1",
                                    Nome_Mae = "Mãe do Aluno1"
                                }
                        );

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.GetAlunoByIdAsync(1);

            // Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task GetAlunoByIdAsync_AlunoPorIdNaoEncontrado()
        {
            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .GetAlunoByIdAsync(0))
                        .ReturnsAsync((Aluno)null);

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.GetAlunoByIdAsync(0);

            // Assert
            Assert.False(result.Success);
            Assert.Null(result.Data);
        }

        [Fact]
        public async Task GetAlunoByNomeAsync_AlunoPorNomeEncontrado()
        {
            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .GetAlunoByNomeAsync("Marcelo"))
                        .ReturnsAsync(
                                new Aluno
                                {
                                    Matricula = 1,
                                    Nome = "Marcelo",
                                    Data_Nascimento = new DateTime(2017, 4, 9),
                                    Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                                    Serie = "G1",
                                    Segmento = "Infantil",
                                    Nome_Pai = "Pai do Aluno1",
                                    Nome_Mae = "Mãe do Aluno1"
                                }
                        );

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.GetAlunoByNomeAsync("Marcelo");

            // Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task GetAlunoByNomeAsync_AlunoPorNomeNaoEncontrado()
        {
            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .GetAlunoByNomeAsync("Marcelo"))
                        .ReturnsAsync((Aluno)null);

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.GetAlunoByNomeAsync("Marcelo");

            // Assert
            Assert.False(result.Success);
            Assert.Null(result.Data);
        }

        [Fact]
        public async Task GetAlunoBySerieAsync_AlunoPorSerieEncontrado()
        {
            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .GetAlunoBySerieAsync("G1"))
                        .ReturnsAsync(
                            new List<Aluno>
                            {
                                new Aluno
                                {
                                    Matricula = 1,
                                    Nome = "Marcelo",
                                    Data_Nascimento = new DateTime(2017, 4, 9),
                                    Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                                    Serie = "G1",
                                    Segmento = "Infantil",
                                    Nome_Pai = "Pai do Aluno1",
                                    Nome_Mae = "Mãe do Aluno1"
                                }
                            }
                        );

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.GetAlunoBySerieAsync("G1");

            // Assert
            Assert.True(result.Success);
            Assert.NotEmpty(result.Datas);
        }

        [Fact]
        public async Task GetAlunoBySerieAsync_AlunoPorSerieNaoEncontrado()
        {
            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .GetAlunoBySerieAsync("G1"))
                        .ReturnsAsync((List<Aluno>)null);

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.GetAlunoBySerieAsync("G1");

            // Assert
            Assert.False(result.Success);
            Assert.Null(result.Datas);
        }

        [Fact]
        public async Task PostAlunoAsync_AlunoCadastrado()
        {
            var alunoAdicionar = new Aluno
            {
                Matricula = 1,
                Nome = "Aluno1",
                Data_Nascimento = new DateTime(2020, 4, 9),
                Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                Serie = "G1",
                Segmento = "Infantil",
                Nome_Pai = "Pai do Aluno1",
                Nome_Mae = "Mãe do Aluno1"
            };

            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .PostAlunoAsync(alunoAdicionar))
                        .ReturnsAsync(alunoAdicionar);

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.PostAlunoAsync(alunoAdicionar);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Aluno adicionado com sucesso!", result.Message);
        }

        [Fact]
        public async Task PostAlunoAsync_AlunoNaoCadastrado()
        {
            var alunoNaoAdicionar = new Aluno
            {
                Matricula = 1,
                Nome = "Aluno1",
                Data_Nascimento = new DateTime(2017, 4, 9),
                Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                Serie = "G1",
                Segmento = "Infantil",
                Nome_Pai = "Pai do Aluno1",
                Nome_Mae = "Mãe do Aluno1"
            };

            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .PostAlunoAsync(alunoNaoAdicionar))
                        .ReturnsAsync(alunoNaoAdicionar);

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.PostAlunoAsync(alunoNaoAdicionar);

            // Assert
            Assert.False(result.Success);
            Assert.NotEqual("Aluno adicionado com sucesso!", result.Message);
        }

        [Fact]
        public async Task PutAlunoAsync_AlunoEditado()
        {
            var alunoEditar = new Aluno
            {
                Matricula = 1,
                Nome = "Aluno1",
                Data_Nascimento = new DateTime(2020, 4, 9),
                Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                Serie = "G1",
                Segmento = "Infantil",
                Nome_Pai = "Pai do Aluno1",
                Nome_Mae = "Mãe do Aluno1"
            };

            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .PutAlunoAsync(alunoEditar))
                        .ReturnsAsync(alunoEditar);

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.PutAlunoAsync(alunoEditar);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Aluno atualizado com sucesso!", result.Message);
        }

        [Fact]
        public async Task PutAlunoAsync_AlunoNaoEditado()
        {
            var alunoNaoEditar = new Aluno
            {
                Matricula = 1,
                Nome = "Aluno1",
                Data_Nascimento = new DateTime(2017, 4, 9),
                Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                Serie = "G1",
                Segmento = "Infantil",
                Nome_Pai = "Pai do Aluno1",
                Nome_Mae = "Mãe do Aluno1"
            };

            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .PutAlunoAsync(alunoNaoEditar))
                        .ReturnsAsync(alunoNaoEditar);

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.PutAlunoAsync(alunoNaoEditar);

            // Assert
            Assert.False(result.Success);
            Assert.NotEqual("Aluno atualizado com sucesso!", result.Message);
        }
        [Fact]
        public async Task DeleteAlunoAsync_AlunoDeletado()
        {
            var alunoDeletar = new Aluno
            {
                Matricula = 1,
                Nome = "Aluno1",
                Data_Nascimento = new DateTime(2020, 4, 9),
                Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                Serie = "G1",
                Segmento = "Infantil",
                Nome_Pai = "Pai do Aluno1",
                Nome_Mae = "Mãe do Aluno1"
            };

            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .GetAlunoByIdAsync(1))
                        .ReturnsAsync(alunoDeletar);

            mockRepository.Setup(repo => repo
                        .DeleteAlunoAsync(alunoDeletar))
                        .ReturnsAsync(alunoDeletar);

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.DeleteAlunoAsync(1);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Aluno deletado com sucesso!", result.Message);
        }

        [Fact]
        public async Task DeleteAlunoAsync_AlunoNaoDeletado()
        {
            var alunoNaoDeletar = new Aluno
            {
                Matricula = 1,
                Nome = "Aluno1",
                Data_Nascimento = new DateTime(2017, 4, 9),
                Endereco = new List<Endereco>
                                    {
                                        new Endereco { Tipo = "residencial", Rua = "Rua dos calçados3", Numero = 123,
                                        CEP = "82222-585", Complemento = "casa 3" },
                                        new Endereco { Tipo = "cobrança", Rua = "Rua dos pés3", Numero = 456,
                                        CEP = "82222-585", Complemento = "casa 2" }
                                    },
                Serie = "G1",
                Segmento = "Infantil",
                Nome_Pai = "Pai do Aluno1",
                Nome_Mae = "Mãe do Aluno1"
            };

            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();
            mockRepository.Setup(repo => repo
                        .DeleteAlunoAsync(alunoNaoDeletar))
                        .ReturnsAsync(alunoNaoDeletar);

            var service = new AlunoBusiness(mockRepository.Object);

            // Act
            var result = await service.DeleteAlunoAsync(1);

            // Assert
            Assert.False(result.Success);
            Assert.NotEqual("Aluno deletado com sucesso!", result.Message);
        }
    }
}
