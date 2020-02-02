From mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /source
EXPOSE 80
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
WORKDIR /app
COPY --from=build /source/out /app
ENTRYPOINT [ "dotnet","NameApi.dll" ]
