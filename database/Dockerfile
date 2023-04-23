FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA='Y'
ENV SA_PASSWORD='Nw7l=U>{}vi}0^?'

# Create a config directory
RUN mkdir -p /usr/config
WORKDIR /usr/config

# Bundle config source
COPY . /usr/config

USER root

# Grant permissions for to our scripts to be executable
RUN chmod +x /usr/config/entrypoint.sh
RUN chmod +x /usr/config/configure-db.sh

# SQL Server trusted connection problem
RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

USER mssql

ENTRYPOINT ["./entrypoint.sh"]