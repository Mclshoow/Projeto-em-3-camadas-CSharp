USE Aluno

-- Total de alunos cadastrados:
	SELECT COUNT(*) AS TotalDeAlunos
	FROM Aluno;

-- Total de alunos por s�rie:
	SELECT Serie, COUNT(*) AS TotalDeAlunosPorSerie
	FROM Aluno
	GROUP BY Serie;

-- Total de alunos por segmento:
	SELECT Segmento, COUNT(*) AS TotalDeAlunosPorSegmento
	FROM Aluno
	GROUP BY Segmento;

-- Quantidade e segmento de alunos entre 4 e 8 anos:
	SELECT Segmento, COUNT(*) AS TotalDeAlunosEntre4e8Anos
	FROM Aluno
	WHERE DATEDIFF(YEAR, CONVERT(DATE, Data_Nascimento, 103), GETDATE()) BETWEEN 4 AND 8
	GROUP BY Segmento;

-- Quantos e quais s�o irm�os (baseado no nome do Pai ou da M�e):
	SELECT Nome_Pai, Nome_Mae, COUNT(*) AS TotalDeAlunos
	FROM Aluno
	GROUP BY Nome_Pai, Nome_Mae
	HAVING COUNT(*) > 1;


	SELECT * FROM Aluno

	SELECT * FROM Endereco