# Differ Project

API para diffs!

## Como funciona?

1. Envie o dado da esquerda para o endpoint ```/v1/diff/left```

    ```bash
    curl --request POST \
      --url https://localhost:44304/v1/Diff/left \
      --header 'content-type: application/json' \
      --data '{
      "LeftData": "abc"
        }'
    ```
	A resposta será o ID gerado. Ex.: ```"16a1dbec-6055-4623-d423-08d823b34d5d"```

2. Envie o dado da direita e o ID gerado anteriormente para o endpoint ```/v1/diff/right```

    ```bash
    curl --request POST \
      --url https://localhost:44304/v1/Diff/right \
      --header 'content-type: application/json' \
      --data '{
    	"id": "16a1dbec-6055-4623-d423-08d823b34d5d", 
    	"RightData": "xbc"
        }'
    ```

3. Receba o resultado enviando o ID para o endpoint ```/v1/diff```

    ```bash
    curl --request POST \
      --url https://localhost:44304/v1/Diff \
      --header 'content-type: application/json' \
      --data '{
    	"id": "16a1dbec-6055-4623-d423-08d823b34d5d"
        }'
    ```
	
	A resposta será:
	```javascript
	{
	  "id": "16a1dbec-6055-4623-d423-08d823b34d5d",
	  "message": "There is 1 difference",
	  "differences": [
	    {
	      "offset": 0,
	      "length": 1
	    }
	  ]
	}
	```

Mais detalhes na página do swagger ao executar o projeto ( caminho padrão https://localhost:44304/swagger/index.html )

## Requisitos para executar

- .NET Core 3.1
- SQL Server Express 2016 LocalDB
- Visual Studio, se não quiser executar pela linha de comando.

## Como executar?

### Pelo Visual Studio

Abra o projeto pelo Visual Studio e execute em modo Debug.
Neste caso o Visual Studio inicia o IIS Express.

### Pelo terminal

Navegue até a raíz do projeto e execute
```bash
dotnet build
dotnet run -p .\src\Differ.Services.Api\
```
Neste caso a aplicação é "Self Hosted", e fica disponível nas portas 5000 e 5001(ssl).

## Testes

Navegue até a raíz do projeto e execute
```bash
dotnet build
dotnet test
```
