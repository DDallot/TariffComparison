#!/bin/bash
BASEDIR=$(dirname "$0") \
  && echo "setting current directory as $BASEDIR" \
  && cd $BASEDIR

apt update \
  && apt install -y docker.io sudo wget git

# Install dotnet 7 
declare repo_version=$(if command -v lsb_release &> /dev/null; then lsb_release -r -s; else grep -oP '(?<=^VERSION_ID=).+' /etc/os-release | tr -d '"'; fi) \
  && wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb \
  && sudo dpkg -i packages-microsoft-prod.deb \
  && rm packages-microsoft-prod.deb \
  && sudo apt update \
  && sudo apt install -y dotnet-sdk-7.0

dockerfile=$(find -iname Dockerfile -print -quit)

docker build Api.TariffComparison -f $dockerfile -t api.tariffcomparison:latest

docker run -e ASPNETCORE_ENVIRONMENT=Development -p "8088:80" api.tariffcomparison:latest