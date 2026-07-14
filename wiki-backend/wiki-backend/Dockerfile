# Stage 1: Build frontend
FROM node:22 AS frontend-build
WORKDIR /app/frontend
COPY wiki-frontend/package*.json ./
RUN npm install --legacy-peer-deps
COPY wiki-frontend/ .
ARG VITE_API_URL
ENV VITE_API_URL=$VITE_API_URL
RUN npm run build

# Stage 2: Build backend
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS backend-build
WORKDIR /src
COPY wiki-backend/wiki-backend/*.csproj .
RUN dotnet restore
COPY wiki-backend/wiki-backend/ .
COPY --from=frontend-build /app/frontend/dist ./wwwroot/
RUN dotnet publish -c Release -o /publish

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /publish
COPY --from=backend-build /publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "wiki-backend.dll"]
