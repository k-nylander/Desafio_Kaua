# Desafio Backend - API de Consulta de CEP (Negocie Online)

Este projeto foi desenvolvido como parte do processo seletivo para a vaga de Desenvolvedor Fullstack na Negocie Online. Trata-se de uma API RESTful em ASP.NET 8 para consulta e armazenamento de informações de CEP.

---

## 🧩 Principais Características e Critérios Atendidos

O projeto foi estruturado para atender aos critérios de avaliação propostos, com foco em boas práticas e qualidade de código:

- **Arquitetura Limpa (Clean Architecture):** A solução é organizada em camadas (`Domain`, `Application`, `Infrastructure`, `API`), promovendo a separação de responsabilidades e o desacoplamento.

- **Princípios SOLID:** Os princípios de design do SOLID foram aplicados para garantir um código mais legível, manutenível e extensível.

- **Padrão de Projeto (Repository Pattern):** O acesso a dados é abstraído através do padrão de repositório, facilitando a testabilidade e a troca da tecnologia de persistência.

- **Boas Práticas REST:** A API segue os padrões REST, utilizando corretamente os verbos HTTP, os códigos de status e um roteamento claro para os recursos.

- **Documentação com Swagger:** A API possui uma documentação interativa gerada automaticamente pelo Swagger, facilitando o teste e a compreensão dos endpoints.

- **Validações e Tratamento de Erros:** Foram implementadas validações nos dados de entrada e um tratamento de erros consistente para fornecer respostas claras ao cliente.

---

## 🛠️ Tecnologias Utilizadas

- [.NET 8 e ASP.NET Core]
- [Entity Framework Core 8]
- [PostgreSQL]
- [Swagger (Swashbuckle)]

---

## 🚀 Como Executar

### ✅ Pré-requisitos

- [.NET 8 SDK]
- Um cliente de banco de dados para PostgreSQL (como DBeaver ou pgAdmin)
- Liberação do seu IP para acesso ao banco de dados (conforme instruções do desafio)

---

### 1. Configuração do Banco de Dados

As tabelas do projeto precisam ser criadas manualmente. Utilize um cliente de banco de dados para se conectar ao servidor da Negocie Online e execute o script SQL disponível em `Database/script.sql`.

Este script irá:

- Criar as tabelas `estados_kaua`, `cidades_kaua` e `enderecos_kaua`
- Ativar o **Row-Level Security (RLS)** e definir as políticas de acesso necessárias

---

### 2. Configuração da Aplicação

1. Clone este repositório.
2. Na raiz do projeto `Desafio_Kaua`, renomeie o arquivo `appsettings.Example.json` para `appsettings.Development.json`.
3. Abra o `appsettings.Development.json` e insira a string de conexão fornecida no desafio:

```json
{
  "ConnectionStrings": {
    "TestConnection": "string_de_conexão"
  }
}
