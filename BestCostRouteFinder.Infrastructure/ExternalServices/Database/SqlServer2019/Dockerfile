FROM mcr.microsoft.com/mssql/server:2019-latest

USER root

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Copy initialization scripts
COPY . /usr/src/app

# Grant permissions for the initialize-db script to be executable
RUN chmod +x /usr/src/app/initialize-db.sh

# Set environment variables, not to have to write them with docker run command
ENV SA_PASSWORD="123@Password"
ENV MSSQL_PID="Express"
ENV ACCEPT_EULA="Y"

# Expose port 1433 in case accesing from other container
EXPOSE 1433

# Run Microsoft SQl Server and initialization script (at the same time)
CMD /bin/bash ./entrypoint.sh