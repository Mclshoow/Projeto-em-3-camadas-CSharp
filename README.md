Teste Programador Positivo
Implemente um CRUD, em uma API, para cadastros de alunos com os seguintes campos:
1)
Número da Matricula (Gerado automaticamente no primeiro cadastro);
2)
Nome completo;
3)
Data de nascimento;
4)
Tipo Endereço:
a.
Cobrança;
b.
Residencial;
c.
Correspondência;
5)
Endereço:
a.
Rua;
b.
CEP;
c.
Numero;
d.
Complemento;
6)
Série:
a.
G1 ao G3: Alunos entre 3 e 5 anos respectivamente;
b.
1º ao 5º ano: Alunos entre 6 e 10 anos respectivamente;
c.
6º ao 9º: ano: Alunos entre 11 e 14 anos respectivamente;
d.
1º ao 3º ano ensino médio: Alunos entre 15 e 17 anos respectivamente;
7)
Segmento:
a.
Se a série for de G1 a G5: Infantil;
b.
Se a série for de 1º ao 5º ano: Anos iniciais;
c.
Se a série for de 6º ao 9º ano: Anos finais;
d.
Caso contrário, será Ensino Médio;
8)
Nome do Pai;
9)
Nome da Mãe;
Ao salvar, o Backend deve fazer a validação para garantir que não há alunos fora da faixa de idade frente à série e segmento escolhido.
A API deve permitir os métodos GET, POST e PUT. Para os métodos GET deve-se trazer o aluno por ID, por nome, por série ou todos. Não é necessário criar um método de autenticação na API.
Além da API, entregar SQL (em um arquivo a parte) as seguintes consultas:
•
Total de alunos cadastrados;
•
Total de alunos por série;
•
Total de alunos por segmento;
•
Quantidade e segmento de alunos entre 4 e 8 anos;
•
Quantos e quais são irmãos (baseado no nome do Pai ou da Mãe);
O que é permitido:
•
Backend: Linguagem C# (.NET Core) ou Python (3.9 ou superior);
•
Database: Mysql ou SQL Server (a modelagem fica por conta do candidato);
•
Qualquer tecnologia complementar as citadas anteriormente são permitidas desde que seu uso seja justificável (ex: ORM)
O que entregar:
•
Código fonte do Backend com o passo a passo para execução;
•
Cópia da base de dados utilizada;
•
Arquivos SQL com a consultas;
•
Testes automatizados (2 para cada endpoint criada simulando uma situação de sucesso e uma situação de erro);
Como entregar:
Criar um repositório privado no Github com os códigos e compartilhar com o usuário ‘ctomasini (ctomasini@positivo.com.br)’. O Readme.md deve ser o currículo do candidato.
Auxiliar:
Json formatado para demonstrar o cadastro:
{
"nome":"Aluno1",
"data_nascimento": "2011-03-18",
"endereco":
[
{
"tipo": "residencial",
"rua":"Rua dos calçados",
"numero":"123",
"cep":"82222-585",
"complemento":"casa 1"
},
{
"tipo": "cobrança",
"rua":"Rua dos pés",
"numero":"456",
"cep":"82222-585",
"complemento":"casa 3"
},
],
"serie":"G1",
"segmento":"Infantil",
"nome_pai": "Pai do Aluno1",
"nome_mae": "Mãe do Aluno1"
}
