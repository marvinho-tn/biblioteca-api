# Projeto: Sistema de Gerenciamento de Biblioteca

## Descrição:
Sistema de gerenciamento de biblioteca. O sistema permitirá que os usuários registrem, visualizem, atualizem e excluam livros, além de gerenciar empréstimos de livros. Também terá integração com um serviço externo para consultar informações sobre os autores via Refit, utilizará Apache Kafka para comunicação assíncrona e YARP como um proxy reverso para rotear as solicitações.

## Estrutura do Projeto:
API de Biblioteca (LibraryAPI)

- FastEndpoints: Para criar endpoints rápidos e eficientes.
- Arquitetura Vertical Slice: Cada funcionalidade (e.g., Criar Livro, Atualizar Livro, Gerenciar Empréstimos) será implementada em seu próprio slice.
- MongoDB: Para armazenar os dados dos livros e empréstimos.
- Apache Kafka: Para enviar notificações sobre eventos de empréstimos.
- Refit: Para integrar com um serviço externo de informações de autores.
- Testes de Unidade: Para garantir a qualidade do código.
- Serviço de Autores (AuthorService)
