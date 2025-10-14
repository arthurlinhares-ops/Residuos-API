## 🧩 Como executar localmente com Docker

### 🔧 Pré-requisitos
- [Docker Desktop](https://www.docker.com/get-started)
- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (opcional, se quiser rodar localmente sem container)

### ▶️ Passos para subir a aplicação

1. Extraia o arquivo `.zip` do projeto.

2. Abra o terminal na pasta raiz do projeto (onde está o `docker-compose.yml`).

3. Suba os containers (aplicação + banco de dados):
   ```bash
   docker compose up -d
