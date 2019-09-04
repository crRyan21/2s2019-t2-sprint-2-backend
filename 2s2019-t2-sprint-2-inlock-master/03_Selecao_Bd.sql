SELECT * FROM Usuarios;
SELECT * FROM Estudios;
SELECT * FROM Jogos;
SELECT Jogos.*, Estudios.*
FROM Jogos
JOIN Estudios
ON Jogos.EstudioId = Estudios.EstudioId
SELECT UsuarioId, Email, Senha, PermissaoUsuario from Usuarios where Email = 'admin@admin.com';
SELECT UsuarioId, Email, Senha, PermissaoUsuario from Usuarios where Senha = 'cliente';
SELECT JogoId, NomeJogo, Descricao, DataLancamento, Valor, EstudioId from Jogos where JogoId = 2
SELECT EstudioId, NomeEstudio, PaisOrigem, DataCriacao, UsuarioId from Estudios where EstudioId = 3