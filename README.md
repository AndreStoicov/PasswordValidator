# O que é

=====================

Password Validator - É uma API Rest para validação de senha.

Critérios:

- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial

## Tecnologias

- .NET Core 2.2

## Requisitos dev

- VS, VS Code ou Rider
- .NET Core SDK

## Executando

- Todas as bibliotecas nuget utilizadas são do nuget.org, então é
  possivel buildar a solution normalmente (basta uma conexão com
  internet)

- Utilizando seu editor de código de preferencia, execute o projeto com
  a solution PasswordValidatorAPI configurada como startup Project

- Para Testar basta utilizar o Postman e realizar uma requisição do tipo:

 POST -> <http://localhost:5051/password/validate>
 
 Payload:
 
```metadata json
{
	"Password" : "string"
}
```
Ou pode utilizar o link do Swagger <http://localhost:5051/swagger/index.html> 

Na solução também existe a opção de utilizar Docker com base na receita do arquivo Dockerfile
para isso basta executar os comandos:

```sh
$ docker build -t password_validator:prod_0.0.1 -f ./Dockerfile .
$ docker push password_validator:prod_0.0.1
$ docker run -d -p 8080:80 --name myapp password_validator:prod_0.0.1
```

Para acessar a aplicação basta executar no navegador <http://localhost:8080/swagger/index.html>
ou utilizar o postman como nos exemplos acima.


