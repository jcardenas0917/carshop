FROM ikemtz/sql_dacpac:latest as sql-temp
ENV SA_PASSWORD=SqlDockerRocks123! \
    ACCEPT_EULA=Y \
    NEW_DB_NAME=CarShop

COPY bin/Debug/CarShop.DB.dacpac /dacpac/db.dacpac
RUN sqlservr & sleep 20 \
    && sqlpackage /Action:Publish /TargetServerName:localhost /TargetUser:SA /TargetPassword:$SA_PASSWORD /SourceFile:/dacpac/db.dacpac /TargetDatabaseName:$NEW_DB_NAME /p:BlockOnPossibleDataLoss=false \
    && sleep 20 \
    && pkill sqlservr && sleep 10 \
    && sudo rm -rf /dacpac

FROM mcr.microsoft.com/mssql/server
LABEL author="@IkeMtz"
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=SqlDockerRocks123!
EXPOSE 1433
COPY --from=sql-temp /var/opt/mssql/data/ /var/opt/mssql/data/

USER root
RUN chown -R mssql /var/opt/mssql/data
USER mssql