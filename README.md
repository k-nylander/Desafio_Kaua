Desafio Backend - API de Consulta de CEP (Negocie Online)Este projeto foi desenvolvido como parte do processo seletivo para a vaga de Desenvolvedor Fullstack na Negocie Online. Trata-se de uma API RESTful em ASP.NET 8 para consulta e armazenamento de informações de CEP.Principais Características e Critérios AtendidosO projeto foi estruturado para atender aos critérios de avaliação propostos, com foco em boas práticas e qualidade de código:Arquitetura Limpa (Clean Architecture): A solução é organizada em camadas (Domain, Application, Infrastructure, API), promovendo a separação de responsabilidades e o desacoplamento.Princípios SOLID: Os princípios de design do SOLID foram aplicados para garantir um código mais legível, manutenível e extensível.Padrão de Projeto (Repository Pattern): O acesso a dados é abstraído através do padrão de repositório, facilitando a testabilidade e a troca da tecnologia de persistência.Boas Práticas REST: A API segue os padrões REST, utilizando corretamente os verbos HTTP, os códigos de status e um roteamento claro para os recursos.Documentação com Swagger: A API possui uma documentação interativa gerada automaticamente pelo Swagger, facilitando o teste e a compreensão dos endpoints.Validações e Tratamento de Erros: Foram implementadas validações nos dados de entrada e um tratamento de erros consistente para fornecer respostas claras ao cliente.Tecnologias Utilizadas.NET 8 e ASP.NET CoreEntity Framework Core 8 como ORMPostgreSQL como banco de dadosSwagger (Swashbuckle) para documentação da APIComo ExecutarPré-requisitos.NET 8 SDKUm cliente de banco de dados para PostgreSQL (DBeaver, pgAdmin, etc.).Liberação do seu endereço de IP para acesso ao banco de dados, conforme solicitado no desafio.1. Configuração do Banco de DadosAs tabelas do projeto precisam ser criadas manualmente. Utilize um cliente de banco de dados para se conectar ao servidor da Negocie Online e execute o script SQL fornecido no arquivo Database/script.sql (ou o script que criamos juntos). Este script irá:Criar as tabelas estados_kaua, cidades_kaua e enderecos_kaua.Ativar o Row-Level Security (RLS) e as políticas de acesso necessárias.2. Configuração da AplicaçãoClone este repositório.Na raiz do projeto Desafio_Kaua, renomeie o arquivo appsettings.Example.json para appsettings.Development.json.Abra o arquivo appsettings.Development.json e insira a string de conexão fornecida no desafio:{
  "ConnectionStrings": {
    "TestConnection": "Host=no-db-dev-101.negocieonline.com.br;Database=db_selecao_imdb;Username=usr_teste;Password=SEU_PASSWORD_AQUI"
  }
}
Atenção: O arquivo appsettings.Development.json está no .gitignore e não deve ser enviado para o repositório.3. Executando a APIAbra um terminal na pasta raiz do projeto e execute o comando:dotnet run
A API estará disponível em https://localhost:<porta> e a documentação Swagger em https://localhost:<porta>/swagger.Endpoints da APIGET /api/Endereco/{cep}Retorna as informações de um CEP que já foi armazenado no banco de dados local.Parâmetros: cep (string, 8 dígitos)Retorno de Sucesso (200 OK):{
  "cep": "01001000",
  "logradouro": "Praça da Sé",
  "complemento": "lado ímpar",
  "bairro": "Sé",
  "cidade": "São Paulo",
  "uf": "SP",
  "ddd": "11"
}
Retorno de Erro (404 Not Found):{
  "message": "CEP não consta na base de dados."
}
POST /api/EnderecoConsulta um CEP na API externa ViaCEP, armazena o resultado no banco de dados (se for um CEP novo) e retorna os dados.Corpo da Requisição (Body):{
  "cep": "01001000"
}
Retorno de Sucesso (201 Created): Retorna o mesmo corpo do endpoint GET, com um cabeçalho Location apontando para o novo recurso.Retorno de Erro (404 Not Found): Se o CEP não for encontrado na API do ViaCEP.Retorno de Erro (400 Bad Request): Se o CEP enviado no corpo da requisição for inválido.
