sleep 15s

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 123@Password -d master -i start-up-db.sql