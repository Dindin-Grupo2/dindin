# dindin

Repositório com fins acadêmicos criado durante a extensão do Anima Tech. Curso ministrado pela Gama Academy

## Front-End App

A correta instalação e configuração do front-end depende dos seguintes passos:

### Node e NPM

Download: [NodeJS](https://nodejs.org/en/download)

### Vue JS

```sh
npm install vue
```

### Instalando Vue CLI

```sh
npm install -g @vue/cli
```

### Executando o projeto

```sh
cd frontend
npm i
npm run serve
```

### Acesso

Ao executar o serve o acesso se dá pela porta: [localhost:8080](http://localhost:8080)

## 
<h1 align="center">
    API Dindin.Web

## 💻 Sobre o projeto

Dindin = Regra de Negócio / Repositório

Dindin.Web = Api REST

## ▶️ Executando o projeto

dindin/backend/Dindin
  
Solução: Dindin.sln

## 🌍 Endpoints

### 1. GET /api/Curso

Endpoint para listagem de todos os cursos cadastrados.

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NotFound

#### Exemplo Retorno:

```
[{
    "id": 1,
    "titulo": "Curso",
    "capa": "https/www.sou-img.com",
    "nomeProfessor": "Nome do Professor",
    "descricao": "Alguma descrição"
  },
  {
    "id": 2,
    "titulo": "Curso Dois",
    "capa": "https/www.sou-img.com",
    "nomeProfessor": "Nome do Professor",
    "descricao": "Alguma descrição"
  }
]
```

### 2. GET /api/Curso/{id}

Endpoint para obter um único Curso pelo seu ID

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

#### Exemplo Retorno:

```
{
  "id": 1,
  "titulo": "Curso",
  "capa": "https/www.sou-img.com",
  "nomeProfessor": "Nome do Professor",
  "descricao": "Alguma descrição"
}
```

### 3. GET /api/Curso/AulasDoCurso/{id}

Endpoint para listar todas as aulas referente ao ID de um curso

#### Exemplo Body:

```
[
  {
    "titulo": "Aula Um",
    "link": "https/www.sou-um-link.com",
    "descricao": "descricao"
  },
  {
    "titulo": "Aula Dois",
    "link": "https/www.sou-um-link.com",
    "descricao": "descricao"
  }
]
```

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

### 4. POST /api/Curso

Endpoint para cadastrar um novo Curso

#### Exemplo Body:

```
{
  "titulo": "Curso",
  "capa": "https/www.sou-img.com",
  "nomeProfessor": "Nome do Professor",
  "descricao": "Alguma descrição"
}
```

Códigos Http de Retorno Possíveis:

- 201 - CREATED
- 400 - BAD REQUEST ()

### 5. POST /api/Curso/AulaDoCurso?titulo=Titulo-Curso

Endpoint para cadastrar aulas de um curso

⚠️ 
  
ATENÇÃO: A cada espaço do titulo do Curso, deve ser substituido por (-).
  
Exemplo: Primeiro Curso = Primeiro-Curso

#### Exemplo Body:

```
[
   {
    "titulo": "Aula Um",
    "link": "https/www.sou-um-link.com-01",
	  "descricao": "descricao"
  },
{
    "titulo": "Aula Dois",
    "link": "https/www.sou-um-link.com-02",
    "descricao": "descricao"
  }
]
```

Códigos Http de Retorno Possíveis:

- 201 - CREATED
- 400 - BAD REQUEST ()

### 6. PUT /api/Curso/{id}

Endpoint para atualizar um Curso

#### Exemplo Body:

```
{
  "titulo": "Curso",
  "capa": "https/www.sou-img.com.uuu",
  "nomeProfessor": "Nome do Professor",
  "descricao": "Alguma descrição"
}
```

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

### 7. PUT /api/Curso/AulaDoCurso?titulo=Primeiro-Curso&tituloAula=Primeira-Aula

Endpoint para atualizar uma Aula

⚠️ 
  
ATENÇÃO: A cada espaço do titulo do Curso quanto ao titulo da Aula, deve ser substituido por (-).
  
Exemplo: Primeiro Curso = Primeiro-Curso / Primeira Aula = Primeira-Aula

#### Exemplo Body:

```
{
 {
    "titulo": "Update Aula",
    "link": "https/www.sou-um-link.com",
    "descricao": "descricao"
  }
}
```

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

### 8. DELETE /api/Curso/{id}

Endpoint para excluir um Curso e as aulas referentes

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT

### 9. DELETE /api/Curso/AulaDoCurso?id=Value&tituloAula=Primeira-Aula

Endpoint para excluir uma aula

⚠️ 
  
ATENÇÃO: A cada espaço do titulo da Aula, deve ser substituido por (-).
  
Primeira Aula = Primeira-Aula

Códigos Http de Retorno Possíveis:

- 200 - OK
- 404 - NOT FOUND

```

## 🦸

```

