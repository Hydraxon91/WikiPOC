FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /publish
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .

#COPY ./wait-for-it.sh /wait-for-it.sh 
#RUN chmod +x /wait-for-it.sh
#Uncomment these if your PC is too slow to start the DB before the backend tries to access it, don't forget docker compose.yml

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "wiki-backend.dll"]