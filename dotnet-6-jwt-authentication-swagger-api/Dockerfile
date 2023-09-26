# Define a imagem base que será usada como ponto de partida para a construção do contêiner.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# Define o diretório de trabalho dentro do contêiner como /app.
WORKDIR /app

# Expõe a porta 5070 para que o aplicativo possa ser acessado externamente.
EXPOSE 5068

# Define uma variável de ambiente para configurar o ASP.NET Core para escutar em todas as interfaces na porta 5070.
ENV ASPNETCORE_URLS=http://+:5068

# Cria um usuário não-root com um UID específico (5678) e desabilita a senha.
# Em seguida, concede permissões para acessar o diretório /app.
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app

# Define o usuário padrão para appuser, que é o usuário não-root que foi criado anteriormente.
USER appuser

# Define a próxima etapa de construção do Dockerfile.
# Neste caso, a próxima etapa será nomeada como 'build'.
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Define o argumento 'configuration' com o valor padrão 'Release'.
ARG configuration=Release

# Define o diretório de trabalho como /src.
WORKDIR /src

# Copia o arquivo .csproj do projeto para o diretório atual (/src) no contêiner.
COPY ["./WebApi.csproj", "./"]

# Executa 'dotnet restore' para restaurar as dependências do projeto.
RUN dotnet restore

# Copia todos os arquivos do projeto para o diretório atual (/src) no contêiner.
COPY . .

# Define o diretório de trabalho de volta para /src.
WORKDIR /src

# Executa 'dotnet build' para compilar o projeto e gera a saída no diretório /app/build.
RUN dotnet build "WebApi.csproj" -c $configuration -o /app/build

# Define a próxima etapa de construção do Dockerfile.
# Neste caso, a próxima etapa será nomeada como 'publish'.
FROM build AS publish

# Define novamente o argumento 'configuration' com o valor padrão 'Release'.
ARG configuration=Release

# Executa 'dotnet publish' para publicar o projeto e gera a saída no diretório /app/publish.
RUN dotnet publish "WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Define a próxima etapa de construção do Dockerfile.
# Neste caso, a próxima etapa será nomeada como 'final'.
FROM base AS final

# Define o diretório de trabalho como /app.
WORKDIR /app

# Copia os arquivos publicados do diretório /app/publish (da etapa 'publish') para o diretório atual (/app) no contêiner.
COPY --from=publish /app/publish .

# Define o comando de entrada que será executado quando o contêiner for iniciado.
# Neste caso, ele inicia o aplicativo ASP.NET Core.
ENTRYPOINT ["dotnet", "WebApi.dll"]
