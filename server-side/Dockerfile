# Start with the official SQL Server image
FROM mcr.microsoft.com/mssql/server:2022-latest

# Switch to the root user to run commands with root privileges
USER root

# Update and configure the Microsoft SQL Server repository
RUN apt-get update && \
    apt-get install -y curl gnupg apt-transport-https && \
    curl -fsSL https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o /usr/share/keyrings/microsoft.asc.gpg && \
    echo "deb [arch=amd64 signed-by=/usr/share/keyrings/microsoft.asc.gpg] https://packages.microsoft.com/ubuntu/20.04/prod focal main" | tee /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Add sqlcmd to the PATH for convenience
RUN echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> /etc/bash.bashrc && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> /root/.bashrc

# Optionally switch back to the default `mssql` user after setup
USER mssql

# Set up SQL Server environment variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=YourPassword123!

# Expose SQL Server port
EXPOSE 1433

# Run SQL Server
CMD ["/opt/mssql/bin/sqlservr"]