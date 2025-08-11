# Protocolo HTTP

O **HTTP (HyperText Transfer Protocol)** é um protocolo de comunicação baseado em texto, utilizado para a troca de informações entre cliente e servidor. Ele segue o modelo **Client-Server**, onde o cliente realiza **requisições (requests)** e o servidor responde com **respostas (responses)**.

## 📤 Request (Requisição)

Uma requisição HTTP é composta por:

- **Linha de requisição**:
  - `verbo / uri / versão HTTP`
  - Exemplo: `GET /produtos HTTP/1.1`
- **Cabeçalho da requisição (Request Header)**:
  - Informações adicionais como tipo de conteúdo, autenticação, etc.
- **Corpo da requisição (Request Body)**:
  - Dados enviados pelo cliente, como formulários ou JSON.

## 📥 Response (Resposta)

Uma resposta HTTP é composta por:

- **Linha de status**:
  - `código de resposta / versão HTTP`
  - Exemplo: `200 OK HTTP/1.1`
- **Cabeçalho da resposta (Response Header)**:
  - Informações como cookies, tokens JWT, tipo de conteúdo, etc.
- **Corpo da resposta (Response Body)**:
  - Conteúdo retornado pelo servidor, como uma página HTML, uma lista de produtos, etc.

## 🔁 Comunicação Client-Server

A interação entre cliente e servidor ocorre da seguinte forma:

1. O cliente envia uma **requisição HTTP**.
2. O servidor processa a requisição.
3. O servidor envia uma **resposta HTTP**.

---

# Arquitetura REST

## Representational State Transfer (REST)
Padrão de arquitetura para sistemas distribuídos, especialmente utilizado em APIs Web. Definido por Roy Fielding em sua tese de doutorado em 2000.

### Princípios do REST
- **Cliente-servidor**: Separa a interface do usuário da lógica de armazenamento.
- **Sem estado (stateless)**: Cada requisição é independente.
- **Cacheável**: Respostas podem ser armazenadas para melhorar desempenho.
- **Interface uniforme**: Recursos são acessados de forma padronizada.
- **Sistema em camadas**: Permite intermediários entre cliente e servidor.

---

# Criação da API Web

```bash
dotnet new webapi -n MinhaPrimeiraAPI -controllers
```
O parâmetro `-controllers` é útil para não criar uma API mínima.

## Comando para rodar

```bash
dotnet watch run
```

---

# Estrutura do Projeto - API

Aplicação ASP.NET Core trabalhando no modelo WebApi:

- **Pacotes Nuget**
- **Properties**: `launchSettings.json` para definir perfis, portas, IIS, etc.
- **Controllers**: Herda de `ControllerBase`. Uso de atributos como `[ApiController]`, `[Route]`, métodos HTTP.
- **Program.cs**: Arquivo principal para rodar a aplicação.
- **appsettings**: Connection strings, chaves de acesso...
- **Startup.cs**: Configura toda a aplicação: `AddMvc`, Middlewares, `UseMvc`, etc.

---

# Controllers diferenciadas

A controller é a coluna cervical de uma API.
A controller da WebApi herda de `ControllerBase`, que implementa funcionalidades básicas. Apenas `ControllerBase` não implementa tudo que é necessário, por isso o atributo `[ApiController]` complementa com funcionalidades extras (`ControllerContext`, `Validator`, `UrlHelper`, `ModelMetadata`...). Mesmo usando essas duas funcionalidades juntas, ainda são menos funcionalidades do que a controller tradicional do MVC.

# Rotas

`[Route("api/[controller]")]`- útil para definir nomes de controllers 
`[HttpGet]`
`[Route("{id:int}")]`
`[HttpGet("{id:int}")]`- dessa maneira evita repetição desnecessária 

exemplo 
`[HttpGet("obter-por-id/{id}")]` 
http://localhost:5188/api/values/obter-por-id/1 

# ActionResult 
É um tipo de retorno que pode retornar um tipo de dado (ex IEnumerable string) OU/E o result (ok 200)
Se não utilizarmos o ActionResult, não podemos retornar os códigos (bad request, not found, forbidden..), SÓ poderiamos retornar o tipo de dado definido.
Porém, se eu tiver um ActionResult SEM especificação do tipo de dado retornado, ele apenas retorna o result (código).
A melhor opção hoje é `ActionResult <IEnumerable<string>>`, pois podemos retornar apenas o result(code) ou/e os valores/tipo.

# Modificadores

`[FromBody]` vem do corpo do Request 
`[FromRoute]`vem da rota 
`[FromForm]`vem de um formulário de request FormData
Quando temos um tipo complexo (ex Produto) não é preciso declarar que é FromBody porque já é implicito 
`[FromHeader]`recebe através do header
`[FromQuery]`não recebe direto da rota, mas recebe via query 
`[FromServices]`Serve para injetar alguma classe vi Injeção de Dependência


# Modificadores - formatadores de respostas

`[HttpPost]`
`[ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]`
`[ProducesResponseType(StatusCodes.Status400BadRequest)]`

# Formatadores de Response Personalizado 
BaseController: O BaseController serve como uma classe base para outros controllers na API. Ele centraliza funcionalidades comuns, como o método Respond, que padroniza as respostas da API:


<img width="1888" height="707" alt="image" src="https://github.com/user-attachments/assets/780e3f72-3c0e-4950-a9aa-4744aec3e6bd" />

