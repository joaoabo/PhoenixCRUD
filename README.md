# PhoenixCRUD
## API em C# com SqlClient, Dapper e Dapper.Contrib
Esta API foi desenvolvida em C# com o objetivo de realizar operações CRUD em um banco de dados usando SqlClient para a conexão e Dapper e Dapper.Contrib para as operações no banco de dados.

## Requisitos
Antes de rodar a API, é necessário que o ambiente possua o .NET Core 3.1 ou superior e um banco de dados SQL Server. Além disso, deve ser feita a instalação dos seguintes pacotes NuGet:

Microsoft.Data.SqlClient
Dapper
Dapper.Contrib
## Configuração do Banco de Dados
Para configurar a conexão com o banco de dados, é necessário editar a string de conexão na ``` classe ProdutoRepositorios.cs:```
```csharp
public ProdutoRepositorios()
{
    _conexao = new SqlConnection("data source=SERVIDOR; initial catalog=DATABASE; user id=USERNAME ; password=PASSWORD; multipleactiveresultsets=true;");
}
```
```Substitua os valores SERVIDOR, DATABASE, USERNAME e PASSWORD pelos valores corretos da sua conexão com o banco de dados.```
## Execução
Após a configuração do banco de dados, compile e execute a API. A API possui os seguintes endpoints:

``` GET /api/produtos:``` Retorna uma lista com todos os produtos no banco de dados.
``` GET /api/produtos/{id}:``` Retorna o produto com o ID especificado.
``` POST /api/produtos:``` Adiciona um novo produto no banco de dados.
``` PUT /api/produtos:``` Atualiza as informações do produto com o ID especificado.
``` DELETE /api/produtos/{id}:``` Remove o produto com o ID especificado do banco de dados.
Para cada endpoint, é necessário enviar os parâmetros necessários no corpo da requisição em formato JSON.

## Contribuindo
Sinta-se à vontade para contribuir com a API, fazendo pull requests e reportando issues. A API é um projeto aberto e qualquer ajuda é bem-vinda!
