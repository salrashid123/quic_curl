#FROM mcr.microsoft.com/dotnet/sdk:6.0 
FROM debian:10

RUN apt-get update && \
  apt-get install -y curl gnupg  software-properties-common apt-transport-https

RUN curl -sSL https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
  apt-add-repository https://packages.microsoft.com/debian/10/prod 

RUN apt-get update && \
   apt-get -y install libmsquic

RUN  apt-get install -y dotnet-sdk-6.0 aspnetcore-runtime-6.0

ADD . /app 

WORKDIR /app 

RUN dotnet restore 

# allow weak certificates (certificate signed with SHA1)
# by downgrading OpenSSL security level from 2 to 1
RUN sed -i 's/SECLEVEL=2/SECLEVEL=1/g' /etc/ssl/openssl.cnf

EXPOSE 8443
ENTRYPOINT ["dotnet", "run"]